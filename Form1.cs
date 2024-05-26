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

		private void UsernameTextBox_LostFocus(object sender, EventArgs e)
		{
			UsernameTextBox.Text = "失去焦点的提示内容";
			//显示的字体颜色，灰色
			UsernameTextBox.ForeColor = Color.Gray;
		}
		private void UsernameTextBox_GotFocus(object sender, EventArgs e)
		{
			UsernameTextBox.Text = "";
			//输入的字体颜色，黑色
			UsernameTextBox.ForeColor = Color.Black;
		}


	}
}
