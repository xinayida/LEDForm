using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LEDForm
{
    public partial class ScreenShooter : Form
    {
        private ThreadWorker worker;//声明一个worker
        //private Point panelLocation, panelPrePos;
        private CaptureForm captureForm;//声明一个captureform
        public ScreenShooter()//constructor 相当于初始化
        {
            InitializeComponent();
            Init();//调用初始化函数
        }

        private void Init()//初始化函数
        {
            captureForm = new CaptureForm();//新建一个captureform
            captureForm.Show();//将captureform显示出来
            captureForm.posUpdateHandler += OnPosUpdate;//将onPosUpdate注册到posUpdateHandler，在CaptureForm_Move发生时可以更新onPosUpdate，也就是更新worker的截图位置
            InitWorker();//初始化worker
            UpdatePos(0, 0);//初始化captureform在加载时的位置，屏幕左上角
            this.StartPosition = FormStartPosition.CenterScreen;//初始化screen shooter在加载时的位置，居中
            //worker?.UpdateClipPos(captureForm.ClientRectangle.X, captureForm.ClientRectangle.Y);
        }

        private void StartBtn_Click(object sender, EventArgs e)//按下开始按钮
        {
            worker.Start();//worker开始工作
            StartBtn.Enabled = false;//开始按键失效
            StopBtn.Enabled = true;//结束按键生效
            
        }

        private void StopBtn_Click(object sender, EventArgs e)//按下停止按钮
        {
            StopBtn.Enabled = false;//开始按键生效
            StartBtn.Enabled = true;//结束按键失效
            if (worker != null && worker.IsInitalized())//如果worker不为空并且已经初始化过了
            {
                worker.Stop();//worker停止
                //worker.Release();
            }
        }

        private void OneShot_Click(object sender, EventArgs e)//按下只运行一次按钮
        {
            //if(worker == null || !worker.isInitalized())
            //{
            //    initWorker();
            //}
            worker.OneShot(ref pictureBox);//worker运行一次
        }

        private void UpdateClipImage(object sender, Bitmap bitmap)//更新在picturebox上的graphic截图，与worker联系在一起
        {
            Graphics g = pictureBox.CreateGraphics();//在picturebox上创建一个Graphics对象g
            g.DrawImage(bitmap, 0, 0);//将截图显示在Graphics对象g上
            g.Dispose();//GDI是非托管资源，需要手动dispose释放
            g = null;//g设为空MLT
        }

        //private void InitBtn_Click(object sender, EventArgs e)
        //{
        //    int w = int.Parse(wInput.Text);
        //    int h = int.Parse(hInput.Text);
        //    worker.InitClipBound(w, h);
        //    updateClipSize(w, h);
        //}

        private void UpdatePos(int x, int y)//更新captureform的位置
        {
            if (captureForm != null)
            {
                captureForm.Location = new Point(x, y);
            }
        }

        private void UpdateClipSize(int w, int h)//更新worker和captureform截图尺寸
        {
            worker.InitClipBound(w, h);//worker初始化截图的尺寸
            if (captureForm != null)//如果captureform不为空
            {
                for (int i = 0; i < 2; i++)//为什么是2？
                {
                    captureForm?.updateRegion(w, h); //captureform更新picturebox的size
                }
            }
        }

        private void OnPosUpdate(object sender, Point e)//已注册，在Captureform位置变化时更新worker的截图位置
        {
            //this.Invoke((EventHandler)delegate
            //{
                worker?.UpdateClipPos(e.X, e.Y);
            //});
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)//按下更新按钮时更新worker
        {
            InitWorker();//初始化worker
        }
        private void InitWorker()//更新worker函数
        {
            if (worker != null)//如果worker不为空
            {
                worker.Stop();//worker停止
            }
            else
            {
                worker = new ThreadWorker();//如果worker为空，新建worker
                worker.dataUpdateHandler += UpdateClipImage;//将更新graphic截图功能注册到dataUpdateHandler上，当capture转换数据时更新截图
            }
            string ipForm = textBoxIPFrom.Text;//读取IP
            int port = int.Parse(textBoxPort.Text);//读取端口号
            int row = int.Parse(textBoxRow.Text);//读取行
            int column = int.Parse(textBoxColumn.Text);//读取列
            int w = int.Parse(textBoxW.Text);//读取宽度
            int h = int.Parse(textBoxH.Text);//读取高度
            double gamma = double.Parse(textBoxGamma.Text);//读取gamma
            worker.InitSenderThreads(ipForm, port, row, column, gamma);//worker初始化发送队列
            worker.InitClipBound(w, h);//worker初始化截图尺寸
            worker.setFPS(int.Parse(textBoxFPS.Text));//worker设定fps
            UpdateClipSize(w, h);//更新worker和captureform截图尺寸
        }

        private void checkBoxGamma_CheckedChanged(object sender, EventArgs e)//如果gamma单选框有变化
        {
            worker?.switchGamma(checkBoxGamma.Checked);//worker改变gamma状态
        }
    }
}
