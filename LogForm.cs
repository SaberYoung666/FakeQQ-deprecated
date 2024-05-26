using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FakeQQ
{
	public partial class MainWindow : Form
	{

		public MainWindow()
		{
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			// 设置文本框提示信息
			UsernameTextBox.Cue = "输入QQ号";
			PasswordTextBox.Cue = "输入QQ密码";

			// 将图片框设为背景图片的透明色
			ClosePicture.Parent = BackgroundPicture;

			Controls.Add(UsernamePanel);
			Controls.Add(PasswordPanel);
			Controls.Add(BackgroundPicture);
		}

		// 绘制圆角窗体
		// 设置窗体的Region
		public void SetWindowRegion()
		{
			GraphicsPath FormPath;
			Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
			FormPath = GetRoundedRectPath(rect, 15);
			this.Region = new Region(FormPath);

		}

		// 绘制圆角路径
		private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
		{
			int diameter = radius;
			Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
			GraphicsPath path = new GraphicsPath();

			// 左上角
			path.AddArc(arcRect, 180, 90);

			// 右上角
			arcRect.X = rect.Right - diameter;
			path.AddArc(arcRect, 270, 90);

			// 右下角
			arcRect.Y = rect.Bottom - diameter;
			path.AddArc(arcRect, 0, 90);

			// 左下角
			arcRect.X = rect.Left;
			path.AddArc(arcRect, 90, 90);
			path.CloseFigure();//闭合曲线
			return path;
		}

		// 窗体size发生改变时重新设置Region属性
		private void MainWindow_Resize(object sender, EventArgs e)
		{
			SetWindowRegion();
		}

		private void UsernamePanel_Resize(object sender, EventArgs e)
		{
			SetWindowRegion();
		}

		// 实现无边框窗口的拖动
		private bool mouseDown;
		private Point lastLocation;

		private void BackgroundPicture_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDown = true;
			lastLocation = e.Location;
		}

		private void BackgroundPicture_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				this.Location = new Point(
					(this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

				this.Update();
			}
		}

		private void BackgroundPicture_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDown = false;
		}

		// 关闭窗体的方法
		private void ClosePicture_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// 鼠标放在关闭键上的方法
		private void ClosePicture_MouseEnter(object sender, EventArgs e)
		{
			ClosePicture.BackgroundImage = Properties.Resources.CloseFocus;
			ClosePicture.BackColor = Color.IndianRed;
		}

		private void ClosePicture_MouseLeave(object sender, EventArgs e)
		{
			ClosePicture.BackgroundImage = Properties.Resources.Close;
			ClosePicture.BackColor = Color.Transparent;
		}

		
	}
}
