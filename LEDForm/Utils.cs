using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDForm
{
    class Utils
    {
        public static byte[] BitmapToByteArray(Bitmap src)//将bitmap值转换为数组
        {
            byte[] result = null;//建立空数组

            int w = src.Width;//得到bitmap的宽度
            int h = src.Height;//得到bitmap的高度
            int len = w * h * 3;//设定数组元素数量
            result = new byte[len];//初始化result
            Rectangle rect = new Rectangle(0, 0, w, h);//建立一个矩形
            BitmapData data = src.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);//将bitmap数据锁定在内存中
            System.IntPtr scan0 = data.Scan0;//得到bitmap数据的句柄
            System.Runtime.InteropServices.Marshal.Copy(scan0, result, 0, len);//将数据从托管数组复制到非托管内存指针，或从非托管内存指针复制到托管数组
            src.UnlockBits(data);//取消内存锁定
            return result;//返回数组
        }
    }
}
