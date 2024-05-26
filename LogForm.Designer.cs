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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.ClosePicture = new System.Windows.Forms.PictureBox();
			this.BackgroundPicture = new System.Windows.Forms.PictureBox();
			this.PasswordTextBox = new CueTextBox();
			this.UsernameTextBox = new CueTextBox();
			this.HeadImagePicture = new OvalPictureBox();
			this.UsernamePanel = new System.Windows.Forms.Panel();
			this.PasswordPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.ClosePicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundPicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HeadImagePicture)).BeginInit();
			this.SuspendLayout();
			// 
			// ClosePicture
			// 
			this.ClosePicture.BackColor = System.Drawing.Color.Transparent;
			this.ClosePicture.BackgroundImage = global::FakeQQ.Properties.Resources.Close;
			this.ClosePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClosePicture.Location = new System.Drawing.Point(322, 0);
			this.ClosePicture.Name = "ClosePicture";
			this.ClosePicture.Size = new System.Drawing.Size(30, 30);
			this.ClosePicture.TabIndex = 7;
			this.ClosePicture.TabStop = false;
			this.ClosePicture.Click += new System.EventHandler(this.ClosePicture_Click);
			this.ClosePicture.MouseEnter += new System.EventHandler(this.ClosePicture_MouseEnter);
			this.ClosePicture.MouseLeave += new System.EventHandler(this.ClosePicture_MouseLeave);
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
			// PasswordTextBox
			// 
			this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PasswordTextBox.Cue = null;
			this.PasswordTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.PasswordTextBox.Location = new System.Drawing.Point(96, 230);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(160, 22);
			this.PasswordTextBox.TabIndex = 4;
			this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// UsernameTextBox
			// 
			this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.UsernameTextBox.Cue = null;
			this.UsernameTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.UsernameTextBox.Location = new System.Drawing.Point(96, 174);
			this.UsernameTextBox.Name = "UsernameTextBox";
			this.UsernameTextBox.Size = new System.Drawing.Size(160, 22);
			this.UsernameTextBox.TabIndex = 4;
			this.UsernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// HeadImagePicture
			// 
			this.HeadImagePicture.BackColor = System.Drawing.Color.Transparent;
			this.HeadImagePicture.BackgroundImage = global::FakeQQ.Properties.Resources.logo;
			this.HeadImagePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.HeadImagePicture.Location = new System.Drawing.Point(136, 64);
			this.HeadImagePicture.Name = "HeadImagePicture";
			this.HeadImagePicture.Size = new System.Drawing.Size(80, 80);
			this.HeadImagePicture.TabIndex = 2;
			this.HeadImagePicture.TabStop = false;
			// 
			// UsernamePanel
			// 
			this.UsernamePanel.BackColor = System.Drawing.Color.White;
			this.UsernamePanel.Location = new System.Drawing.Point(41, 163);
			this.UsernamePanel.Name = "UsernamePanel";
			this.UsernamePanel.Size = new System.Drawing.Size(270, 44);
			this.UsernamePanel.TabIndex = 8;
			this.UsernamePanel.Resize += new System.EventHandler(this.UsernamePanel_Resize);
			// 
			// PasswordPanel
			// 
			this.PasswordPanel.BackColor = System.Drawing.Color.White;
			this.PasswordPanel.Location = new System.Drawing.Point(41, 219);
			this.PasswordPanel.Name = "PasswordPanel";
			this.PasswordPanel.Size = new System.Drawing.Size(270, 44);
			this.PasswordPanel.TabIndex = 9;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(352, 450);
			this.Controls.Add(this.PasswordPanel);
			this.Controls.Add(this.UsernamePanel);
			this.Controls.Add(this.ClosePicture);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.UsernameTextBox);
			this.Controls.Add(this.HeadImagePicture);
			this.Controls.Add(this.BackgroundPicture);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainWindow";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.Resize += new System.EventHandler(this.MainWindow_Resize);
			((System.ComponentModel.ISupportInitialize)(this.ClosePicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundPicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HeadImagePicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox BackgroundPicture;
		private OvalPictureBox HeadImagePicture;
		private CueTextBox UsernameTextBox;
		private CueTextBox PasswordTextBox;
		private System.Windows.Forms.PictureBox ClosePicture;
		private System.Windows.Forms.Panel UsernamePanel;
		private System.Windows.Forms.Panel PasswordPanel;
	}
}

