using HHGestureUnlocking.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHGestureUnlocking
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 九宫格的九个点
        /// </summary>
        public List<Point> NinePoints = new List<Point>();

        /// <summary>
        /// 绘制解锁点列表
        /// </summary>
        public List<Point> UnLockPoint = new List<Point>();

        /// <summary>
        /// 绘制九宫格圆心点的画笔
        /// </summary>
        public Pen DrawPen = new Pen(Color.FromArgb(18, 150, 219), 4);

        /// <summary>
        /// 是否开始绘制解锁（鼠标左键按下时开始）
        /// </summary>
        private bool _isDraw = false;
        /// <summary>
        /// 是否选中九宫格中的其中一个点
        /// </summary>
        private bool _isSelected = false;

        /// <summary>
        /// 绘制密码
        /// </summary>
        public string PasswordStr = "";
        /// <summary>
        /// 解锁密码
        /// </summary>
        public string UnlockPassword = "147569";

        public MainForm()
        {
            InitializeComponent();
            CreadtNinePoint();
        }

        /// <summary>
        /// 初始化九宫格的九个点
        /// </summary>
        public void CreadtNinePoint()
        {
            NinePoints.Clear();
            int pwith = pnlPassWord.Width / 3;
            int pheight = pnlPassWord.Height / 3;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    NinePoints.Add(new Point(pwith * x + pwith / 2, pheight * y + pheight / 2));
                }
            }
        }

        /// <summary>
        /// 绘制九宫格解锁图案
        /// </summary>
        public void ShowAreaAndLine()
        {
            try
            {
                //添加一块画布
                Bitmap backBit = new Bitmap(pnlPassWord.Width, pnlPassWord.Height);
                Graphics g = Graphics.FromImage(backBit);
                g.SmoothingMode = SmoothingMode.HighQuality;
                //清除Graphics
                g.Clear(pnlPassWord.BackColor);
                //绘制画布
                g.DrawImage(backBit, new Rectangle(0, 0, pnlPassWord.Width, pnlPassWord.Height),
                    new Rectangle(0, 0, pnlPassWord.Width, pnlPassWord.Height), GraphicsUnit.Pixel);
                //绘制九宫格的点
                for (int i = 0; i < NinePoints.Count; i++)
                {
                    g.DrawImage(Resources.pointsCircle, new Point(NinePoints[i].X - 20, NinePoints[i].Y - 20));
                }
                //绘制选中的解锁点
                int pointIndex = 1;
                Point pointEnd;
                Point pointStart = new Point(0, 0);
                for (int i = 0; i < UnLockPoint.Count; i++)
                {
                    //绘制选中点背景
                    if (i < UnLockPoint.Count - 1 || _isSelected)
                    {
                        //高亮绘制选中点
                        g.DrawImage(Resources.pointsSelect, new Point(UnLockPoint[i].X - 20, UnLockPoint[i].Y - 20));
                    }
                    pointEnd = UnLockPoint[i];
                    //绘制两点连接的直线
                    if (pointIndex > 1)
                    {
                        g.DrawLine(DrawPen, pointStart, pointEnd);
                    }
                    //绘制小圆，覆盖两条线段的连接处
                    if (i < UnLockPoint.Count - 1 || _isSelected)
                    {
                        //绘制区域（）
                        Rectangle rg = new Rectangle(UnLockPoint[i].X - 6, UnLockPoint[i].Y - 6, 11, 11);
                        g.DrawEllipse(DrawPen, rg);
                        //画空心圆
                        Brush bru = new SolidBrush(Color.FromArgb(18, 150, 219));
                        g.FillEllipse(bru, rg);
                        //填充空心圆，实心圆

                    }
                    pointStart = UnLockPoint[i];
                    pointIndex++;

                }
                g.Dispose();
                pnlPassWord.CreateGraphics().DrawImage(backBit, 0, 0);
                backBit.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "出错了");
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HHLockForm_Load(object sender, EventArgs e)
        {
            //添加一块画布
            Bitmap backBit = new Bitmap(pnlPassWord.Width, pnlPassWord.Height);
            Graphics g = Graphics.FromImage(backBit);
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清除Graphics
            g.Clear(pnlPassWord.BackColor);
            //绘制画布
            g.DrawImage(backBit, new Rectangle(0, 0, pnlPassWord.Width, pnlPassWord.Height),
                new Rectangle(0, 0, pnlPassWord.Width, pnlPassWord.Height), GraphicsUnit.Pixel);
            //绘制九宫格的点
            for (int i = 0; i < NinePoints.Count; i++)
            {
                g.DrawImage(Resources.pointsCircle, new Point(NinePoints[i].X - 20, NinePoints[i].Y - 20));
            }
            pnlPassWord.BackgroundImage = backBit;

            lblBack.ForeColor = Color.FromArgb(18, 150, 219);
            lblMsg.ForeColor = Color.FromArgb(18, 150, 219);
        }

        /// <summary>
        /// 传入一个点，判断是否是九宫格中的一个点，并处理
        /// </summary>
        /// <param name="p">点</param>
        public void AddPoint(Point p)
        {
            for (int i = 0; i < NinePoints.Count; i++)
            {
                //遍历九宫格的点，鼠标经过的点是否在其中一个九宫格的点的范围内
                if ((p.X > NinePoints[i].X - 20 && p.X < NinePoints[i].X + 20) && (p.Y > NinePoints[i].Y - 20 && p.Y < NinePoints[i].Y + 20))
                {
                    //判断九宫格的点是否已经选择过，若选择过则不处理
                    if (!(PasswordStr.IndexOf((i + 1).ToString()) > -1))
                    {
                        //若尚未选择过该点则添加
                        UnLockPoint[UnLockPoint.Count - 1] = (NinePoints[i]);
                        //追加密码字符串
                        PasswordStr = PasswordStr + (i + 1);
                        lblMsg.Text = string.Format("绘制密码顺序：{0}", PasswordStr);
                        _isSelected = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标点击左键且移动时开始绘制解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDraw)
            {
                //如果还未确定九宫格的点则实时改变最后一个点的坐标
                if (!_isSelected)
                {
                    UnLockPoint[UnLockPoint.Count - 1] = e.Location;

                }
                else//如果确定了则再添加一个改变点
                {
                    UnLockPoint.Add(e.Location);
                    _isSelected = false;
                }
                AddPoint(e.Location);

            }
            ShowAreaAndLine();
            GC.Collect();
        }
        /// <summary>
        /// 鼠标左键弹起时结束绘制九宫格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawMouseUp(object sender, MouseEventArgs e)
        {
            if (_isDraw)
            {
                //停止绘制标示
                _isDraw = false;
                //清除绘制的九宫格点
                UnLockPoint.Clear();
                //显示密码（可用来判断九宫格密码）
                if (PasswordStr.Length < 4)
                {
                    lblMsg.Text = string.Format("密码不能小于4位");
                }
                else
                {
                    if (PasswordStr == UnlockPassword)
                    {
                        //解锁成功
                        lblMsg.Text = string.Format("超哥流弊");
                    }
                    else
                    {
                        lblMsg.Text = string.Format("请重试");
                    }
                }
                PasswordStr = "";
                //绘制九宫格（此处相当于初始化九宫格）
                ShowAreaAndLine();
            }
        }

        /// <summary>
        /// 鼠标左键点击时触发开始绘制九宫格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawMouseDown(object sender, MouseEventArgs e)
        {
            //开始绘制标记
            _isDraw = true;
            //添加第一个点击的点
            UnLockPoint.Add(e.Location);
            //显示九宫格解锁图案
            ShowAreaAndLine();
        }

        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }
    }
}
