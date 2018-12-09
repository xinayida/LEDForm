using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEDForm
{
    class ThreadWorker
    {
        private static readonly int CACHE_SIZE = 3;//截图缓冲区大小，为什么是3
        private static readonly object obj = new object();//不明白
        private Queue<byte[]> taskQueue = new Queue<byte[]>(CACHE_SIZE);
        private Bitmap bmp;//建立一个bitmap
        private int fpsLimit = 30;//帧率限制
        private int blocks;//分塊數量
        private int blockCount;//每帧分块数量
        private int clipX =0, clipY = 0;
        private int rows, columns;
        //事件等待句柄
        private EventWaitHandle _consumeEvent = new AutoResetEvent(false);
        private EventWaitHandle _produceEvent = new AutoResetEvent(false);
        private List<SendManager> sendManagers = new List<SendManager>();
        //private CountDownLatch latch;//用于同步发送数据，所有数据发送完成之后再发送下一组数据
        private bool _start;//线程开始flag
        public EventHandler<Bitmap> dataUpdateHandler;

        private int debugCountP, debugCountC;
        private int fpsCount;
        private long fpsTS;
        private bool gammaFlag;
        private double gamma;
        private bool oneShot;
        private int oneShotIndex;
 
        private byte[] Capture()//抓取屏幕指定区域并转为byte数组
        {
            if(bmp == null)
            {
                return null;
            }
            Graphics g = Graphics.FromImage(bmp);//从bmp得到graphics，也就是在bmp上画
            //int w = bmp.Width;
            //int h = bmp.Height;
            g.CopyFromScreen(new Point(clipX, clipY), new Point(0, 0), new Size(w, h));//从屏幕将图像传输到graphics上，(源矩阵左上角，目标矩阵左上角，区块大小)
                                                                                       //clipX和clipY的值会随取景框位置变化而变化
            dataUpdateHandler?.Invoke(this, bmp);//更新screen shooter上截图信息
            return Utils.BitmapToByteArray(bmp);//将bmp转换成数组
        }

        public void OneShot(ref System.Windows.Forms.PictureBox picture)
        {
            oneShot = true;
            byte[] data = Capture();    //得到数组
            sendData(data);             //发送数组
            //picture.Image = bmp;
            //picture.Update();
        }

        public void Start()//开始
        {
            fpsCount = 0;
            fpsTS = DateTime.Now.Ticks/10000;//DateTime.Now.Ticks 是指从DateTime.MinValue之后过了多少时间，10,000,000为一秒
            debugCountP = 0;
            debugCountC = 0;
            fpsCount = 0;
            _start = true;//开始标志位为1
            var pT = new Thread(Produce)
            {
                Name = "生产者"//线程名字叫“生产者”
            };//创建一个produce的线程pT
            pT.Start();//线程开始
            var cT = new Thread(Consume)
            {
                Name = "消费者"//线程名字叫“消费者”
            };//创建一个consume的线程cT
            cT.Start();//线程开始
        }

        public void Stop()//结束
        {
            _start = false;//开始标志位为0
            _consumeEvent.Set();//设置线程正常
            _produceEvent.Set();//设置线程正常
        }

        public void Release()//释放
        {
            lock (obj)
            {
                bmp.Dispose();
                bmp = null;
                sendManagers.Clear();
                sendManagers = null;
            }
        }

        public bool IsInitalized()
        {
            return bmp != null && sendManagers != null;
        }

        //抓取线程
        private void Produce()//将当前的数据压入queue中
        {
            while (_start)
            {
                if (taskQueue.Count < CACHE_SIZE)//如果taskqueue的数量小于3
                {
                    lock (obj)
                    {
                        oneShot = false;
                        taskQueue.Enqueue(Capture());//将当前的数据压入queue中
                        debugCountP += 1;
                        //Console.WriteLine("produce: " + debugCountP);
                    }
                    _consumeEvent.Set();//开始消费者线程
                }
                else//如果taskqueue的数量等于3
                {
                    _produceEvent.WaitOne();//不再生产，等待消费
                }
            }
            
        }
        //发送数据(多个)线程
        private void Consume()
        {
            while (_start) {
                long beforeMS = DateTime.Now.Ticks / 10000;//得到开始ms值
                if (taskQueue.Count > 0)//如果taskqueue内部有数据
                {
                    lock (obj)//锁定
                    {
                        byte[] srcData = taskQueue.Dequeue();//从queue中取出数据
                        if (srcData == null)//如果数据为空则推出
                        {
                            break;
                        }
                        //consume
                        //latch.reset();
                        //dataUpdateHandler?.Invoke(this, new Bitmap(bmp));
                        sendData(srcData);//将数据发送出去
                        //latch.Await();//等待所有线程发送完毕
                        debugCountC += 1;
                        //Console.WriteLine("consume: " + debugCountC);
                        long afterMS = DateTime.Now.Ticks / 10000;//得到结束ms值
                        long timeGap = afterMS - beforeMS;//得到间隔
                        //Console.WriteLine("timeGap: " + timeGap);
                        if (timeGap < fpsLimit)//如果事件间隔没有到
                        {
                            int sleepTime = (int)(fpsLimit - timeGap);//取得差值
                            //Console.WriteLine("sleep: " + sleepTime);
                            Thread.Sleep(sleepTime);//等待
                        }
                        if ((afterMS - fpsTS) > 1000)//每隔1s在console中更新fps值
                        {
                            fpsTS = afterMS;
                            int num = debugCountC - fpsCount;
                            fpsCount = debugCountC;
                            Console.WriteLine("FPS: " + num);
                        }
                    }
                    _produceEvent.Set();//开始生产者线程
                }
                else
                {
                    _consumeEvent.WaitOne();//如果queue中没有数据，消费者线程等待
                }
            }
        }

        private void sendData(byte[] srcData)
        {
            int totalLen = srcData.Length;
            int rowDataLen = totalLen / rows;
            int blockDataLen = rowDataLen / columns;
            int hob = h / rows;
            int wob = w / columns;
            int skipLen = rowDataLen / wob;
            int blockDataLenRow = blockDataLen / hob;
            //Console.WriteLine("hob" + hob + " wob " + wob);
            byte[] dstData = new byte[blockDataLen];
            int blocklen = blockDataLen / blockCount;
            byte[] sendData = new byte[4 + blockDataLen / blockCount];
            sendData[0] = 0xfa;
            sendData[1] = 0xce;
            sendData[2] = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    int start = r * rowDataLen + c * blockDataLenRow;
                    for (int s = 0; s < hob; s++)
                    {
                        Array.Copy(srcData, start + s * skipLen, dstData, blockDataLenRow * s, blockDataLenRow);
                    }
                    if (oneShot)
                    {
                        Console.WriteLine("onshot: index {0}, from {1}, blocklen {2}", oneShotIndex, oneShotIndex * blocklen,blocklen);
                        sendData[3] = (byte)oneShotIndex;
                        Array.Copy(dstData, oneShotIndex * blocklen, sendData, 4, blocklen);
                        sendManagers[r * columns + c].send(sendData, gammaFlag ? gamma : 1.0);
                        oneShotIndex++;
                        if(oneShotIndex >= blockCount)
                        {
                            oneShotIndex = 0;
                        }
                    }
                    else
                    {
                        for (int b = 0; b < blockCount; b++)
                        {
                            sendData[3] = (byte)b;
                            Array.Copy(dstData, b * blocklen, sendData, 4, blocklen);
                            sendManagers[r * columns + c].send(sendData, gammaFlag ? gamma : 1.0);
                        }
                    }
                }
            }
        }

        public void setFPS(int fps)
        {
            this.fpsLimit = 1000 / fps;
        }

        int w, h;
        //设置屏幕截取范围
        public void InitClipBound(int w, int h)
        {
            this.w = w;
            this.h = h;
            if(bmp != null)
            {
                bmp.Dispose();
            }
            bmp = new Bitmap(w, h);
            int blockSize = 64 * 64;
            blockCount = w * h / blockSize;
            Console.WriteLine("blockCount: " + blockCount);
        }

        //更新截屏位置
        public void UpdateClipPos(int x, int y)
        {
            this.clipX = x;
            this.clipY = y;
        }

        public void switchGamma(bool gs)
        {
            gammaFlag = gs;
        }

        //根据起始ip以及模组个数来初始化发送线程队列
        public void InitSenderThreads(string IPFrom, int port, int r, int c, double gamma)//生成发送队列
        {
            rows = r;
            columns = c;
            this.gamma = gamma;
            blocks = rows * columns;//得到有几个块，要分几个IP发送出去
            if (!ValidateIPAddress(IPFrom))
            {
                MessageBox.Show("IP不合法","error",MessageBoxButtons.OK);
                return;
            }
            string[] ip = IPFrom.Split('.');
            string IPBase = ip[0] + '.' + ip[1] + '.';//192.168.
            int ip3 = int.Parse(ip[2]);
            int ip4 = int.Parse(ip[3]);
            //latch = new CountDownLatch(count);
            string ipT = null;
            sendManagers.Clear();
            for (int i=0; i < blocks; i++)
            {
                ipT = IPBase + ((ip4 + i) / 256 + ip3) + '.' + (ip4 + i) % 256;//IP地址，注意这个算法不对
                Console.WriteLine("ipT: " + ipT);
                sendManagers.Add(new SendManager(ipT, port));//生成发送队列
            }
        }

        public static bool ValidateIPAddress(string ipAddress)
        {
            Regex validipregex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            return (ipAddress != "" && validipregex.IsMatch(ipAddress.Trim())) ? true : false;
        }

        private class SendManager//发送类
        {
            private Socket socket;
            //private CountDownLatch latch;
            private readonly IPEndPoint ipe;//MLT
            public SendManager(string ip, int port)//constructor 初始化
            {
                ipe = new IPEndPoint(IPAddress.Parse(ip), port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //this.latch = latch;
            }
            //真正的发送数据方法
            public void send(object o,double gamma =1.0d)
            {
                byte[] data = (byte[])o;
                if (gamma != 1.0)
                {
                    int len = data.Length;
                    for (int i = 0; i < len; i++)
                    {
                        double range = (double)data[i] / 255;
                        double correction = Math.Pow(range, gamma);
                        data[i] = (byte)(correction * 255);
                    }
                }
                //发送
                
                socket.SendTo(data, ipe);//将数据发送出去
                
                //latch.CountDown();
            }
        }
    }

}
