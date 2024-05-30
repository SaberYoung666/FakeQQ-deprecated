using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FakeQQ.RoundedCorners;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FakeQQ
{
	public partial class LogForm : Form
	{
		// 实现无边框窗口的拖动用到的参数
		private bool mouseDown;
		private Point lastLocation;
		// 合法数据的正则表达式
		private string legalUsername = @"^[\u4e00-\u9fa5a-zA-Z0-9]{1,20}$";
		private string legalPassword = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$";

		public LogForm()
		{
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			//设置焦点
			this.ActiveControl = this.HeadImagePicture;
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
			LogUpCheckPasswordTextBox.Cue = "确认密码";
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
			RoundCorner.SetRoundRectRgn(LogUpCheckPasswordPanel, 10);
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

		// 登录注册页面切换
		private void LogUpLabel_Click(object sender, EventArgs e)
		{
			// 展示注册用到的控件
			LogInPanel.Visible = false;
		}
		private void LogInLabel_Click(object sender, EventArgs e)
		{
			// 展示登录用到的控件
			LogInPanel.Visible = true;
			SetTextBoxCue();
			LogUpUsernameTextBox.Clear();
			UsernameIndicatorPictureBox.Visible = false;
			LogUpPasswordTextBox.Clear();
			PasswordIndicatorPictureBox.Visible = false;
			LogUpCheckPasswordTextBox.Clear();
			CheckPasswordIndicatorPictureBox.Visible = false;
			LogUpPhoneTextBox.Clear();
			ActiveControl = null;
		}

		// 登录逻辑
		// 判断焦点是否在输入框上
		private void FocusedTimer_Tick(object sender, EventArgs e)
		{
			if (this.ActiveControl == AccountTextBox)
			{
				AccountClosePicture.Visible = true;
			}
			else
			{
				AccountClosePicture.Visible = false;
			}

			if (this.ActiveControl == PasswordTextBox)
			{
				PasswordClosePicture.Visible = true;
			}
			else
			{
				PasswordClosePicture.Visible = false;
			}
		}
		// 清空文本框
		private void ClearPicture_Click(object sender, EventArgs e)
		{
			if (sender == AccountClosePicture)
			{
				AccountTextBox.Clear();
			}
			else if (sender == PasswordClosePicture)
			{
				PasswordTextBox.Clear();
			}
		}
		// 对于账号密码是否有输入做出判断
		private void MonitorTextBoxTimer_Tick(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(AccountTextBox.Text) || String.IsNullOrEmpty(PasswordTextBox.Text))
			{
				LogInButton.BackColor = Color.AntiqueWhite;
				LogInButton.Enabled = false;
			}
			else
			{
				LogInButton.BackColor = Color.NavajoWhite;
				LogInButton.Enabled = true;
			}
		}
		private void LoginButton_Click(object sender, EventArgs e)
		{
			string account = AccountTextBox.Text;
			string password = PasswordTextBox.Text;
			string queryPassword = "";

			Connect connect = new Connect();
			connect.load();
			string sql = "select * from user where account = " + account + ";";
			connect.comm = new MySqlCommand(sql, connect.conn);
			connect.dr = connect.comm.ExecuteReader();
			if (connect.dr.Read())
			{
				queryPassword = connect.dr.GetString("password");
			}

			if (password == queryPassword)
			{
				connect.dr.Close();
				this.Hide();
				ListForm listForm = new ListForm();
				listForm.ShowDialog();
			}
			else
			{
				MessageBox.Show("账号或密码错误，请重新输入。","登录失败");
			}
		}

		// 注册逻辑
		// 判断输入是否完全
		private void MonitorLogUpTextBoxTimer_Tick(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(LogUpUsernameTextBox.Text) || String.IsNullOrEmpty(LogUpPasswordTextBox.Text) || String.IsNullOrEmpty(LogUpCheckPasswordTextBox.Text) || String.IsNullOrEmpty(LogUpPhoneTextBox.Text))
			{
				LogUpButton.BackColor = Color.AntiqueWhite;
				LogUpButton.Enabled = false;
			}
			else
			{
				LogUpButton.BackColor = Color.NavajoWhite;
				LogUpButton.Enabled = true;
			}
		}
		private void LogUpButton_Click(object sender, EventArgs e)
		{
			string username = LogUpUsernameTextBox.Text;
			string password = LogUpPasswordTextBox.Text;
			string checkPassword = LogUpCheckPasswordTextBox.Text;
			string phone = LogUpPhoneTextBox.Text;

			
			
			// 判断两次密码输入是否相同
			// 判断手机号是否合法
			// 发送验证码验证
			// 生成账号
			// 将数据录入数据库
			// 展示账号
		}
		// 判断昵称是否合法
		private void LogUpUsernameTextBox_Validated(object sender, EventArgs e)
		{
			UsernameIndicatorPictureBox.Visible = true;

			if (Regex.IsMatch(LogUpUsernameTextBox.Text, legalUsername))
			{
				UsernameIndicatorPictureBox.BackgroundImage = Properties.Resources.right;
				LogUpUsernameTextBox.Cue = "昵称";
			}
			else if (String.IsNullOrEmpty(LogUpUsernameTextBox.Text))
			{
				UsernameIndicatorPictureBox.Visible = false;
			}
			else
			{
				UsernameIndicatorPictureBox.BackgroundImage = Properties.Resources.wrong;
				LogUpUsernameTextBox.Clear();
				ActiveControl = null;
				LogUpUsernameTextBox.Cue = "用户名应该在20字以内";
			}
		}
		// 判断密码是否合法
		private void PasswordIndicatorPictureBox_Validated(object sender, EventArgs e)
		{
			PasswordIndicatorPictureBox.Visible = true;
			

			if (Regex.IsMatch(LogUpPasswordTextBox.Text, legalPassword))
			{
				PasswordIndicatorPictureBox.BackgroundImage = Properties.Resources.right;
				LogUpPasswordTextBox.Cue = "密码";
			}
			else if (String.IsNullOrEmpty(LogUpPasswordTextBox.Text))
			{
				PasswordIndicatorPictureBox.Visible = false;
			}
			else
			{
				PasswordIndicatorPictureBox.BackgroundImage = Properties.Resources.wrong;
				LogUpPasswordTextBox.Clear();
				ActiveControl = null;
				LogUpPasswordTextBox.Cue = "密码应由8-20位的大小写字母和数字组成";
			}
		}
	}
}
