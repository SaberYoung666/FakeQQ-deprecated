namespace FakeQQ
{
	partial class MainWindow
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.HeadImagePicture = new OvalPictureBox();
			this.BackgroundPicture = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.UsernameTextBox = new CueTextBox();
			((System.ComponentModel.ISupportInitialize)(this.HeadImagePicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// HeadImagePicture
			// 
			this.HeadImagePicture.BackColor = System.Drawing.Color.Transparent;
			this.HeadImagePicture.BackgroundImage = global::FakeQQ.Properties.Resources.logo;
			this.HeadImagePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.HeadImagePicture.Location = new System.Drawing.Point(140, 64);
			this.HeadImagePicture.Name = "HeadImagePicture";
			this.HeadImagePicture.Size = new System.Drawing.Size(80, 80);
			this.HeadImagePicture.TabIndex = 2;
			this.HeadImagePicture.TabStop = false;
			// 
			// BackgroundPicture
			// 
			this.BackgroundPicture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BackgroundPicture.Image = global::FakeQQ.Properties.Resources.mainWindowBackground;
			this.BackgroundPicture.Location = new System.Drawing.Point(0, 0);
			this.BackgroundPicture.Name = "BackgroundPicture";
			this.BackgroundPicture.Size = new System.Drawing.Size(352, 450);
			this.BackgroundPicture.TabIndex = 0;
			this.BackgroundPicture.TabStop = false;
			this.BackgroundPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackgroundPicture_MouseDown);
			this.BackgroundPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackgroundPicture_MouseMove);
			this.BackgroundPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackgroundPicture_MouseUp);
			// 
			// textBox1
			// 
			this.textBox1.CausesValidation = false;
			this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(60, 237);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(240, 29);
			this.textBox1.TabIndex = 3;
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox1.GotFocus += new System.EventHandler(this.UsernameTextBox_GotFocus);
			this.textBox1.LostFocus += new System.EventHandler(this.UsernameTextBox_LostFocus);
			// 
			// UsernameTextBox
			// 
			this.UsernameTextBox.Cue = null;
			this.UsernameTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.UsernameTextBox.Location = new System.Drawing.Point(60, 174);
			this.UsernameTextBox.Name = "UsernameTextBox";
			this.UsernameTextBox.Size = new System.Drawing.Size(240, 29);
			this.UsernameTextBox.TabIndex = 4;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(352, 450);
			this.Controls.Add(this.UsernameTextBox);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.HeadImagePicture);
			this.Controls.Add(this.BackgroundPicture);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MainWindow";
			this.Text = "mainWindow";
			((System.ComponentModel.ISupportInitialize)(this.HeadImagePicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox BackgroundPicture;
		private OvalPictureBox HeadImagePicture;
		private System.Windows.Forms.TextBox textBox1;
		private CueTextBox UsernameTextBox;
	}
}

