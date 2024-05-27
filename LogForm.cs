using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FakeQQ.RoundedCorners;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace FakeQQ
{
	public partial class LogForm : Form
	{
		// 实现无边框窗口的拖动用到的参数
		private bool mouseDown;
		private Point lastLocation;

		public LogForm()
		{
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			// 将背景图片设为控件的父级，实现透明色
			LogInClosePicture.Parent = LogInBackgroundPicture;
			LogUpLabel.Parent = LogInBackgroundPicture;
			LogUpClosePicture.Parent = LogUpBackgroundPicture;
			LogInLabel.Parent = LogUpBackgroundPicture;
			WelcomeLogUpLabel.Parent = LogUpBackgroundPicture;

			// 绘制圆角
			DrawRoundedCorners();

			// 设置文本框提示信息
			SetTextBoxCue();
		}

		// 设置文本框提示信息
		private void SetTextBoxCue()
		{
			AccountTextBox.Cue = "输入QQ号";
			PasswordTextBox.Cue = "输入QQ密码";
			LogUpUsernameTextBox.Cue = "昵称";
			LogUpPasswordTextBox.Cue = "密码";
			LogUpPhoneTextBox.Cue = "手机号码";
		}

		// 绘制圆角
		private void DrawRoundedCorners()
		{
			// 绘制窗体的圆角
			int hRgn = RoundCorner.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
			RoundCorner.SetWindowRgn(this.Handle, hRgn, true);
			RoundCorner.DeleteObject(hRgn);

			// 绘制圆角
			RoundCorner.SetRoundRectRgn(AccountPanel, 10);
			RoundCorner.SetRoundRectRgn(PasswordPanel, 10);
			RoundCorner.SetRoundRectRgn(LogInButton, 10);
			RoundCorner.SetRoundRectRgn(LogUpUsernamePanel, 10);
			RoundCorner.SetRoundRectRgn(LogUpPasswordPanel, 10);
			RoundCorner.SetRoundRectRgn(LogUpPhonePanel, 10);
			RoundCorner.SetRoundRectRgn(LogUpButton, 10);
		}

		// 窗体拖动
		private void BackgroundPicture_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDown = true;
			lastLocation = e.Location;
		}

		private void BackgroundPicture_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

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
			LogInClosePicture.BackgroundImage = Properties.Resources.CloseFocus;
			LogInClosePicture.BackColor = Color.IndianRed;
			LogUpClosePicture.BackgroundImage = Properties.Resources.CloseFocus;
			LogUpClosePicture.BackColor = Color.IndianRed;
		}

		private void ClosePicture_MouseLeave(object sender, EventArgs e)
		{
			LogInClosePicture.BackgroundImage = Properties.Resources.Close;
			LogInClosePicture.BackColor = Color.Transparent;
			LogUpClosePicture.BackgroundImage = Properties.Resources.Close;
			LogUpClosePicture.BackColor = Color.Transparent;
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

		// 登录注册页面切换
		private void LogUpLabel_Click(object sender, EventArgs e)
		{
			// 展示注册用到的控件
			LogInPanel.Visible = false;
		}

		private void LogInLabel_Click(object sender, EventArgs e)
		{
			//  展示登录用到的控件
			/*LogUpUsernamePanel.Visible = false;
			LogUpPasswordPanel.Visible = false;
			LogUpPhonePanel.Visible = false;
			LogUpButton.Visible = false;
			LogInLabel.Visible = false;

			HeadImagePicture.Visible = true;
			LogUpLabel.Visible = true;
			AccountPanel.Visible = true;
			PasswordPanel.Visible = true;
			LogInButton.Visible = true;*/
			LogInPanel.Visible = true;
		}
	}
}
