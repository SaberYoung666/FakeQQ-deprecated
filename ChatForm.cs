using FakeQQ.RoundedCorners;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FakeQQ
{
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Boolean is_changed = false;//判断用户输入是否改变
        private String textBox_content;//文本框的值
        private Point init_location=new Point(0,0);//初始位置
        private int click_count=0;//消息发送次数

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (click_count == 0)
            {
                init_location=new Point(this.Width-50,10);
            }
            else if (init_location.Y > messageArea.Height)
            {
                init_location.Y = messageArea.Height+20;
            }
            PictureBox userAvatar= new PictureBox();
            RichTextBox message = new RichTextBox();
            set_userAvatar(userAvatar,init_location);
            set_message(message,init_location);
            messageArea.Controls.Add(userAvatar);
            messageArea.Controls.Add(message);
            messageArea.ScrollControlIntoView(userAvatar);
            messageArea.ScrollControlIntoView(message);
            click_count++;
        }//动态添加聊天框
        private void set_userAvatar(PictureBox userAvatar,Point location)
        {
            userAvatar.Size = new Size(30, 30);
            userAvatar.Location = init_location;
            userAvatar.Image = Properties.Resources.logo;
            userAvatar.SizeMode=PictureBoxSizeMode.StretchImage;
            RoundCorner.SetRoundRectRgn(userAvatar, 30);
        }//设置头像框属性

        private void set_message(RichTextBox message,Point location)
        {
            message.Width = 200;
            message.Location = new Point(init_location.X-210, init_location.Y);
            message.Text = textBox_content;
            message.BackColor = Color.White;
            message.BorderStyle = BorderStyle.None;
            message.ContentsResized += Message_ContentsResized;
            message.ReadOnly = true;
          
        }//设置消息框属性

        private void Message_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            RichTextBox message= sender as RichTextBox;
            message.Height=e.NewRectangle.Height;
            if (click_count != 0)
            {
                init_location.Y = (message.Height + 20) * click_count+5;
            }
        }

        private void richTextBox_content_TextChanged(object sender, EventArgs e)
        {
            is_changed= true;
            textBox_content=richTextBox_content.Text;
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
    }
}
