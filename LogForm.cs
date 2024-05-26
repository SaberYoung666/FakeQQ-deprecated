using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FakeQQ.RoundedCorners;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

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
			AccountTextBox.Cue = "输入QQ号";
			PasswordTextBox.Cue = "输入QQ密码";

			// 将图片框设为背景图片的透明色
			ClosePicture.Parent = BackgroundPicture;

			Controls.Add(AccountPanel);
			Controls.Add(PasswordPanel);
			Controls.Add(BackgroundPicture);

			// 绘制窗体的圆角
			int hRgn = RoundCorner.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
			RoundCorner.SetWindowRgn(this.Handle, hRgn, true);
			RoundCorner.DeleteObject(hRgn);
			
			// 绘制圆角
			RoundCorner.SetRoundRectRgn(AccountPanel, 10);
			RoundCorner.SetRoundRectRgn(PasswordPanel, 10);
			RoundCorner.SetRoundRectRgn(LoginButton, 10);
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

		// 登录逻辑
		private void LoginButton_Click(object sender, EventArgs e)
		{
			string account = AccountTextBox.Text;
			string password = PasswordTextBox.Text;

			Connect connect = new Connect();
			connect.load();
			string sql = "select * from user where account = " + account + ";";
			connect.comm = new MySqlCommand(sql, connect.conn);
			connect.dr = connect.comm.ExecuteReader();
			connect.dr.Read();

			if (password == connect.dr.GetString("password"))
			{
				MessageBox.Show("登录成功！");
				connect.dr.Close();
				this.Hide();
				ListForm listForm = new ListForm();
				listForm.ShowDialog();
			}
			else
			{
				MessageBox.Show("登录失败！");
			}
		}

		// 清空文本框
		private void AccountClosePicture_Click(object sender, EventArgs e)
		{
			AccountTextBox.Clear();
		}

		private void PasswordClosePicture_Click(object sender, EventArgs e)
		{
			PasswordTextBox.Clear();
		}
	}
}
