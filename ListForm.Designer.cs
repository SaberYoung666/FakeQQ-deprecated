namespace FakeQQ
{
    partial class ListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListForm));
            this.avatar = new System.Windows.Forms.PictureBox();
            this.userName = new System.Windows.Forms.Label();
            this.signature = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // avatar
            // 
            this.avatar.BackColor = System.Drawing.Color.Transparent;
            this.avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.avatar.Image = ((System.Drawing.Image)(resources.GetObject("avatar.Image")));
            this.avatar.Location = new System.Drawing.Point(12, 64);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(80, 80);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            this.avatar.Click += new System.EventHandler(this.avatar_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.BackColor = System.Drawing.Color.Transparent;
            this.userName.Location = new System.Drawing.Point(109, 85);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(71, 15);
            this.userName.TabIndex = 1;
            this.userName.Text = "userName";
            // 
            // signature
            // 
            this.signature.AutoEllipsis = true;
            this.signature.BackColor = System.Drawing.Color.Transparent;
            this.signature.Location = new System.Drawing.Point(109, 124);
            this.signature.Name = "signature";
            this.signature.Size = new System.Drawing.Size(240, 20);
            this.signature.TabIndex = 3;
            this.signature.Text = "如果看到前面的阴影，别害怕，那是因为你的背后有阳光。";
            this.signature.Click += new System.EventHandler(this.signature_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OIP-C (2).jpg");
            this.imageList1.Images.SetKeyName(1, "OIP-C (3).jpg");
            this.imageList1.Images.SetKeyName(2, "下载 (1).jpg");
            this.imageList1.Images.SetKeyName(3, "下载.jpg");
            this.imageList1.Images.SetKeyName(4, "OIP-C.jpg");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(381, 641);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.signature);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.avatar);
            this.Name = "ListForm";
            this.Text = "ListForm";
            this.Load += new System.EventHandler(this.ListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label signature;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}