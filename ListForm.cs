using FakeQQ.RoundedCorners;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeQQ
{
    public partial class ListForm : Form
    {

        public ListForm()
        {
            
            InitializeComponent();
      
        }
        List<Friends> friendsList= new List<Friends>();
        

        private void ListForm_Load(object sender, EventArgs e)
        {
            picCircle(avatar);
            friendsList.Add(new Friends("张三", @"C:\Users\ASUS\Desktop\images\OIP-C (3).jpg"));
            friendsList.Add(new Friends("李四", @"C:\Users\ASUS\Desktop\images\OIP-C.jpg"));
            friendsList.Add(new Friends("王五", @"C:\Users\ASUS\Desktop\images\OIP-C (2).jpg"));
            Point label_location = new Point(70,160);
            Point pictureBox_location = new Point(10, 140);

            for (int i = 0; i < friendsList.Count; i++, label_location.Y += 80,pictureBox_location.Y+=80)
            {
                PictureBox pictureBox = new PictureBox();
                Label label = new Label();
                set_pictureBox(pictureBox, pictureBox_location, i);
                set_label(label, label_location, i);
                this.Controls.Add(pictureBox);
                this.Controls.Add(label);
                picCircle(pictureBox);
            }
            // 绘制窗体的圆角
            int hRgn = RoundCorner.CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20);
            RoundCorner.SetWindowRgn(this.Handle, hRgn, true);
            RoundCorner.DeleteObject(hRgn);

        }

        public void set_pictureBox(PictureBox pictureBox,Point pictureBox_location,int index)
        {
            pictureBox.Location = pictureBox_location;
            pictureBox.Size = new Size(50, 50);
            pictureBox.ImageLocation = friendsList[index].avatarURL;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.DoubleClick += PictureBox_DoubleClick;
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            ChatForm chatForm=new ChatForm();
            chatForm.ShowDialog(); 
            throw new NotImplementedException();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            
        }

        public void set_label(Label label,Point label_location,int index) {
            label.Text = friendsList[index].name;
            label.Location = label_location;
            label.BackColor = Color.Transparent;
        }

        public void picCircle(PictureBox avatar)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(avatar.ClientRectangle);
            Region region = new Region(gp);
            avatar.Region = region;
            gp.Dispose();
            region.Dispose();
        }
        


        private void avatar_Click(object sender, EventArgs e)
        {

        }

        private void signature_Click(object sender, EventArgs e)
        {

        }

        private void picture_minus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picture_close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private Point mousepoint;
        private Boolean leftflag = false;
        //设置全局变量，用于记录鼠标位置和左键判断标志
        private void ListForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousepoint=e.Location;
                leftflag = true;
            }

        }//  首先记下按下左键时的第一个鼠标位置

        private void ListForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftflag)
            {
                Left = MousePosition.X - mousepoint.X;
                Top = MousePosition.Y - mousepoint.Y;
            }
        }//如果左键标志为真则移动窗体，且移动的位置为当前鼠标位置减去按下左键时第一个鼠标位置

        private void ListForm_MouseUp(object sender, MouseEventArgs e)
        {
            leftflag=false;
        }//如果左键松开就不移动
    }

}
