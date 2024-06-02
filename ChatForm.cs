﻿using FakeQQ.RoundedCorners;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FakeQQ
{
    public partial class ChatForm : Form
    {
        // 判断用户输入是否改变
        private Boolean is_changed = false;
        // 文本框的值
        private String textBox_content;
        // 初始位置
        private Point init_location = new Point(0, 0);
        // 消息发送次数
        private int click_count = 1;
        // 设置全局变量，用于记录鼠标位置和左键判断标志
		private Point mousepoint;
		private Boolean leftflag = false;
        // 枚举按钮类型
		private enum btn_type { text, document, emoji, image }
		btn_type type = btn_type.text;
        // 当前用户QQ号
        string sendAccount = "";
        // 目标用户QQ号
        string receiveAccount = "";
        // qq表情列表
        List<string> qqEmojiList= new List<string>();
        // qq表情链接
        private String qqEmojiURL;
		// 创建套接字
		Socket clientSocket = null;
		Thread clientThread = null;

        public ChatForm()
        {
            InitializeComponent();
        }

		public ChatForm(string sendAccount, string receiveAccount, Socket clientSocket)
        {
            InitializeComponent();
            this.sendAccount = sendAccount;
            this.receiveAccount = receiveAccount;
            this.clientSocket = clientSocket;
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            QQEmojiArea.Parent = this;
            QQEmojiArea.BringToFront();
            ConnectServer();
            qqEmojiList.Add(@"C:\Users\ASUS\Desktop\qq表情包\QQ表情1.jpg");
            qqEmojiList.Add(@"C:\Users\ASUS\Desktop\qq表情包\QQ表情2.jpg");
            qqEmojiList.Add(@"C:\Users\ASUS\Desktop\qq表情包\QQ表情3.jpg");
            qqEmojiList.Add(@"C:\Users\ASUS\Desktop\qq表情包\QQ表情4.jpg");
            qqEmojiList.Add(@"C:\Users\ASUS\Desktop\qq表情包\QQ表情5.jpg");
            qqEmojiList.Add(@"C:\Users\ASUS\Desktop\qq表情包\QQ表情6.gif");
            qqEmojiList.Add(@"C:\Users\ASUS\Desktop\qq表情包\QQ表情7.jpg");
            qqEmojiList.Add(@"C:\Users\ASUS\Desktop\qq表情包\QQ表情8.jpg");
            qqEmojiList.Add(@"C:\Users\ASUS\Desktop\qq表情包\QQ表情9.jpg");
            LinkServer();
        }

        // 关闭按钮
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		private void picture_close_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void picture_minus_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		private void picture_minus_MouseMove(object sender, MouseEventArgs e)
		{
			picture_minus.BackColor = Color.Red;
		}
		private void picture_minus_MouseLeave(object sender, EventArgs e)
		{
			picture_minus.BackColor = Color.Transparent;
		}
		private void picture_close_MouseMove(object sender, MouseEventArgs e)
		{
			picture_close.BackColor = Color.Red;
		}
		private void picture_close_MouseLeave(object sender, EventArgs e)
		{
			picture_close.BackColor = Color.Transparent;
		}

		// 窗体移动
		private void navigation_bar_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				mousepoint = e.Location;
				leftflag = true;
			}
		}
		private void navigation_bar_MouseMove(object sender, MouseEventArgs e)
		{
			if (leftflag)
			{
				Left = MousePosition.X - mousepoint.X;
				Top = MousePosition.Y - mousepoint.Y;
			}
		}
		private void navigation_bar_MouseUp(object sender, MouseEventArgs e)
		{
			leftflag = false;
		}

		// 发送消息
		// 动态添加聊天框
		private void btn_send_Click(object sender, EventArgs e)
        {
            if (click_count == 1)
            {
                // 头像位置
                init_location = new Point(this.Width - 50, 20);
            }
            if (type == btn_type.text || type == btn_type.document)
            {
                PictureBox userAvatar = new PictureBox();
                RichTextBox message = new RichTextBox();
                set_userAvatar(userAvatar, init_location);
                set_message(message, init_location);
                messageArea.Controls.Add(message);
                messageArea.Controls.Add(userAvatar);
                messageArea.ScrollControlIntoView(userAvatar);
                messageArea.ScrollControlIntoView(message);
            }
            if(type == btn_type.image || type == btn_type.emoji)
            {
                PictureBox userAvatar = new PictureBox();
                PictureBox message = new PictureBox();
                set_userAvatar(userAvatar, init_location);
                set_message(message, init_location);
                messageArea.Controls.Add(message);
                messageArea.Controls.Add(userAvatar);
                messageArea.ScrollControlIntoView(userAvatar);
                messageArea.ScrollControlIntoView(message);
            }
            click_count +=1;
            richTextBox_content.Clear();
            richTextBox_content.Controls.Clear();
            richTextBox_content.Focus();
            type = btn_type.text;
        }//动态添加聊天框
        private void set_userAvatar(PictureBox userAvatar,Point location)
        {
            userAvatar.Size = new Size(30, 30);
            userAvatar.Location = init_location;
            userAvatar.Image = Properties.Resources.logo;
            userAvatar.SizeMode=PictureBoxSizeMode.StretchImage;
            RoundCorner.SetRoundRectRgn(userAvatar, 30);
        }
        // 设置消息框属性
        private void set_message(Control message,Point location)
        {
            if (type == btn_type.text)
            {
            {
                RichTextBox text_message = (RichTextBox)message;
                text_message.Width = 200;
                text_message.Text = textBox_content;
                text_message.BackColor = Color.White;
                text_message.BorderStyle = BorderStyle.None;
                text_message.ContentsResized += Message_ContentsResized;
                message.Location = new Point(init_location.X - text_message.Width-20, init_location.Y + 5);
                text_message.ReadOnly = true;
				// 发送消息
				string str = textBox_content;
                byte[] buffer = Encoding.Default.GetBytes(str);
				clientSocket.Send(buffer);
                MessageBox.Show(textBox_content, "客户端发送消息");
			}
            else if (type == btn_type.image)
            {
                PictureBox image_message= (PictureBox)message;
                image_message.Image = Clipboard.GetImage();
                image_message.SizeMode=PictureBoxSizeMode.AutoSize;
                image_message.Location = new Point(init_location.X - image_message.Width - 20, init_location.Y + 5);
                init_location.Y += image_message.Height + 20;
                if (init_location.Y > messageArea.Height)
                {
                    init_location.Y = messageArea.Height + 20;
                }
            }
            else if(type == btn_type.document)
            {
                message.Width = 200;
                message.BorderStyle = BorderStyle.None;
                message.Location = new Point(init_location.X - message.Width - 20, init_location.Y + 5);
                message.ContentsResized += Message_ContentsResized;
                message.Paste();
            }
            
        }


        private void Message_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            RichTextBox message = sender as RichTextBox;
            message.Height = e.NewRectangle.Height;
            init_location.Y += message.Height;
            if (init_location.Y > messageArea.Height)
            {
                init_location.Y = messageArea.Height + 20;
                }
            }  
        }


        private void Message_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            RichTextBox message= sender as RichTextBox;
            message.Height=e.NewRectangle.Height;
            init_location.Y+=message.Height;
            if (init_location.Y > messageArea.Height)
            {
                init_location.Y =messageArea.Height+20;
            }
        }

        private void richTextBox_content_TextChanged(object sender, EventArgs e)
        {
            textBox_content = richTextBox_content.Text;
            if (textBox_content=="")
            {
                btn_send.Enabled = false;
            }
                message.Width = 200;
                message.BorderStyle = BorderStyle.None;
                message.Location = new Point(init_location.X - message.Width - 20, init_location.Y + 5);
                message.ContentsResized += Message_ContentsResized;
                message.Paste();
            }
            
        }
            {
                is_changed= true;
                btn_send.Enabled = true;
            }
        }
        private void picture_close_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void picture_minus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picture_minus_MouseMove(object sender, MouseEventArgs e)
        {
            picture_minus.BackColor= Color.Red;
        }

        private void picture_minus_MouseLeave(object sender, EventArgs e)
        {
        }
            picture_minus.BackColor= Color.Red;
        }

        private void picture_minus_MouseLeave(object sender, EventArgs e)
        {
            picture_minus.BackColor= Color.Transparent;
        }

        private void picture_close_MouseMove(object sender, MouseEventArgs e)
        {
            picture_close.BackColor= Color.Red;
        }

        private void picture_close_MouseLeave(object sender, EventArgs e)
        {
            picture_close.BackColor= Color.Transparent;
        }
        private Point mousepoint;
        private Boolean leftflag = false;
        //设置全局变量，用于记录鼠标位置和左键判断标志
       

        private void navigation_bar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousepoint = e.Location;
                leftflag = true;
            }
        }//  首先记下按下左键时的第一个鼠标位置

        private void navigation_bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftflag)
            {
                Left = MousePosition.X - mousepoint.X;
                Top = MousePosition.Y - mousepoint.Y;
            }
        }//如果左键标志为真则移动窗体，且移动的位置为当前鼠标位置减去按下左键时第一个鼠标位置
       

        private void navigation_bar_MouseUp(object sender, MouseEventArgs e)
        {
            leftflag= false;
        }//如果左键松开就不移动
        private enum btn_type {text,document,emoji,image }//枚举按钮类型
        btn_type type = btn_type.text;
        private void picture_doc_Click(object sender, EventArgs e)
        {
            type= btn_type.document;
            OpenFileDialog openDocumentDialog = new OpenFileDialog();
            openDocumentDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            openDocumentDialog.Multiselect = false;//关闭多选
            if (openDocumentDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openDocumentDialog.FileName);
                Clipboard.Clear();   //清空剪贴板
                System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();

        // 发送表情包
        private void picture_emoji_Click(object sender, EventArgs e)
        {
            type= btn_type.emoji;
            Point qqEmojiLocation=new Point(20,20);
            QQEmojiArea.Visible= true;
            for(int i = 0; i < qqEmojiList.Count; i++)
            {
                PictureBox qqEmoji=new PictureBox();
                qqEmoji.ImageLocation = qqEmojiList[i];
                qqEmoji.Location = qqEmojiLocation;
                qqEmoji.Size = new Size(40, 40);
                qqEmoji.SizeMode = PictureBoxSizeMode.StretchImage;
                qqEmoji.Click += QqEmoji_Click;
                qqEmojiLocation.X += 72;
                if (qqEmojiLocation.X >=QQEmojiArea.Width-60)
                {
                    qqEmojiLocation.Y += 50;
                    qqEmojiLocation.X = 20;
                }
                QQEmojiArea.Controls.Add(qqEmoji);
            }
        }

        private void QqEmoji_Click(object sender, EventArgs e)
        {
            QQEmojiArea.VerticalScroll.Value = 0;
            PictureBox qq_emoji=new PictureBox();
            qq_emoji.ImageLocation = (sender as PictureBox).ImageLocation;
            qqEmojiURL = (sender as PictureBox).ImageLocation;
            qq_emoji.Size = new Size(100, 100);
            qq_emoji.SizeMode = PictureBoxSizeMode.StretchImage;
            richTextBox_content.Controls.Add(qq_emoji);
            QQEmojiArea.Visible = false;
        }

        // 发送图片
        private void picture_image_Click(object sender, EventArgs e)
        {
            type = btn_type.image;
            OpenFileDialog openImageFileDialog=new OpenFileDialog();
            openImageFileDialog.Filter = "图片文件|*.jpg|BMP图片|*.bmp|Gif图片|*.gif";
            openImageFileDialog.Multiselect = false;
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openImageFileDialog.FileName);
                Clipboard.Clear();   //清空剪贴板
                Bitmap bmp = new Bitmap(openImageFileDialog.FileName);  //创建Bitmap类对象
                Clipboard.SetImage(bmp);  //将Bitmap类对象写入剪贴板
                richTextBox_content.Paste();   //将剪贴板中的对象粘贴到对话框里
            }
        }

		//连接服务器
		private void ConnectServer()
		{
			// 创建客户端套接字
			clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			// 设置IP地址
			IPAddress address = IPAddress.Parse("127.0.0.1");
			// 设置IP地址和端口号
			IPEndPoint endPoint = new IPEndPoint(address, 8088);
			try
			{
				// 与服务器建立连接
				clientSocket.Connect(endPoint);
                MessageBox.Show("成功连接到服务器");
			}
			catch (Exception ex)
			{
				MessageBox.Show("连接失败：" + ex.Message, "友情提示");
		// 连接服务器
		private void LinkServer()
		{
				return;
			}
			// 接收或发送消息 使用线程来实现
			clientThread = new Thread(ReceiveMsg);
			clientThread.IsBackground = true; //开启后台线程
			clientThread.Start();
		}
        // 客户端接收消息
		private void ReceiveMsg()
		{
			while (true)
			{
				byte[] recBuffer = new byte[1024 * 1024 * 2];//声明最大字符内存
				int length = -1; //字节长度
				try
				{
					length = clientSocket.Receive(recBuffer);//返回接收到的实际的字节数量
				}
				catch (SocketException ex)
				{
					break;
				}
				catch (Exception ex)
				{
                    MessageBox.Show("与服务器断开连接");
					break;
				}
				//接收到消息
				if (length > 0)
				{
					string msg = Encoding.Default.GetString(recBuffer, 0, length);//转译字符串(字符串，开始的索引，字符串长度)
					string str = $"{DateTime.Now}【接收】{msg}{Environment.NewLine}";//接收的时间，内容，换行
                    MessageBox.Show(str, "接收到的消息");
				}
			}
		}

        
    }
}
