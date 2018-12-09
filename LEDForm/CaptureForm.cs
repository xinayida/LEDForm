using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEDForm
{
    public partial class CaptureForm : Form
    {
        private const uint WS_EX_LAYERED = 0x80000;//设置窗口风格，可透明化窗口
        private const int GWL_EXSTYLE = -20;
        private const int LWA_COLORKEY = 1;
        private const int BORDER = 15;//外框尺寸

        [DllImport("user32", EntryPoint = "SetWindowLong")]//使用P/Invoke，指明DLL名和函数名
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);

        public CaptureForm()//constructor,相当于初始化
        {
            InitializeComponent();
            this.TopMost = true;//将此窗体置于顶层
            SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_LAYERED);//将窗体设置为分层窗体
            SetLayeredWindowAttributes(this.Handle, 65280, 255, LWA_COLORKEY);//设置透明，因为picturebox本身是绿色的，65280可以将绿色设置为透明
        }

        private void CaptureForm_Load(object sender, EventArgs e)//窗体加载时
        {
            this.pictureBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);//将picturebox和form1绑定在一起
            this.Width += this.pictureBox1.Width;//窗体加picturebox?
            this.Height += this.pictureBox1.Height;//窗体加picturebox?
        }

        public void updateRegion(int w, int h)//更新captureform和picturebox的size，                  与外界有联系1
        {
            //this.pictureBox1.Location = new Point(BORDER, BORDER);
            this.pictureBox1.Size = new Size(w+2, h+2);//更新picturebox的size
            this.Size = new Size(w+2, h+2 + BORDER);//加上底部边框
        }

        private void CaptureForm_Move(object sender, EventArgs e)//当CaptureForm移动时              与外界有联系2
        {
            Point p = this.PointToScreen(new Point(1, 1));//将当前form的位置计算成屏幕坐标
            posUpdateHandler?.Invoke(this, p);//更新screenshooter里worker的位置，取点的位置？
            //Console.WriteLine("pos: x{0} y{1}", p.X, p.Y);
        }

        public EventHandler<Point> posUpdateHandler;

        private void CaptureForm_SizeChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("sizeChasnged: size{0}", this.Size);
        }

        private Point dragPoint;
        private void CaptureForm_MouseDown(object sender, MouseEventArgs e)//鼠标按下事件，取得鼠标的位置
        {
            if(e.Button == MouseButtons.Left)//如果左键按下
            {
                dragPoint = e.Location;//dragPoint的值就是鼠标的值
            }
        }

        private void CaptureForm_MouseMove(object sender, MouseEventArgs e)//鼠标移动事件，更新captureform的位置
        {
            if (e.Button == MouseButtons.Left)//如果左键按下
            {
                int x = e.Location.X - dragPoint.X;
                int y = e.Location.Y - dragPoint.Y;
                this.Location = new Point(this.Location.X + x, this.Location.Y + y);//更新取景框的位置,进入CaptureForm_Move事件
            }
        }
    }
}
