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
            Point label_location = new Point(70,140);
            Point pictureBox_location = new Point(10, 120);

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
 
        }

        public void set_pictureBox(PictureBox pictureBox,Point pictureBox_location,int index)
        {
            pictureBox.Location = pictureBox_location;
            pictureBox.Size = new Size(50, 50);
            pictureBox.ImageLocation = friendsList[index].avatarURL;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Click += PictureBox_Click;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            
        }

        public void toMessageForm()
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
    }

}
