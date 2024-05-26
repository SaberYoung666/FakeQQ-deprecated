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
			this.AccountPanel = new System.Windows.Forms.Panel();
			this.PasswordPanel = new System.Windows.Forms.Panel();
			this.LoginButton = new System.Windows.Forms.Button();
			this.PasswordTextBox = new CueTextBox();
			this.AccountTextBox = new CueTextBox();
			this.HeadImagePicture = new OvalPictureBox();
			this.AccountClosePicture = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.ClosePicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundPicture)).BeginInit();
			this.AccountPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.HeadImagePicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AccountClosePicture)).BeginInit();
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
			// AccountPanel
			// 
			this.AccountPanel.BackColor = System.Drawing.Color.White;
			this.AccountPanel.Controls.Add(this.AccountClosePicture);
			this.AccountPanel.Location = new System.Drawing.Point(41, 163);
			this.AccountPanel.Name = "AccountPanel";
			this.AccountPanel.Size = new System.Drawing.Size(270, 44);
			this.AccountPanel.TabIndex = 8;
			// 
			// PasswordPanel
			// 
			this.PasswordPanel.BackColor = System.Drawing.Color.White;
			this.PasswordPanel.Location = new System.Drawing.Point(41, 219);
			this.PasswordPanel.Name = "PasswordPanel";
			this.PasswordPanel.Size = new System.Drawing.Size(270, 44);
			this.PasswordPanel.TabIndex = 9;
			// 
			// LoginButton
			// 
			this.LoginButton.BackColor = System.Drawing.Color.NavajoWhite;
			this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.NavajoWhite;
			this.LoginButton.FlatAppearance.BorderSize = 0;
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LoginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
			this.LoginButton.Location = new System.Drawing.Point(41, 324);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(270, 44);
			this.LoginButton.TabIndex = 10;
			this.LoginButton.Text = "登录";
			this.LoginButton.UseVisualStyleBackColor = false;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PasswordTextBox.Cue = null;
			this.PasswordTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.PasswordTextBox.Location = new System.Drawing.Point(96, 232);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(160, 19);
			this.PasswordTextBox.TabIndex = 4;
			this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.PasswordTextBox.UseSystemPasswordChar = true;
			// 
			// AccountTextBox
			// 
			this.AccountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AccountTextBox.Cue = null;
			this.AccountTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.AccountTextBox.Location = new System.Drawing.Point(96, 175);
			this.AccountTextBox.Name = "AccountTextBox";
			this.AccountTextBox.Size = new System.Drawing.Size(160, 19);
			this.AccountTextBox.TabIndex = 4;
			this.AccountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			// AccountClosePicture
			// 
			this.AccountClosePicture.BackgroundImage = global::FakeQQ.Properties.Resources.Close;
			this.AccountClosePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.AccountClosePicture.Location = new System.Drawing.Point(240, 12);
			this.AccountClosePicture.Name = "AccountClosePicture";
			this.AccountClosePicture.Size = new System.Drawing.Size(19, 19);
			this.AccountClosePicture.TabIndex = 0;
			this.AccountClosePicture.TabStop = false;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(352, 450);
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.PasswordPanel);
			this.Controls.Add(this.AccountPanel);
			this.Controls.Add(this.ClosePicture);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.AccountTextBox);
			this.Controls.Add(this.HeadImagePicture);
			this.Controls.Add(this.BackgroundPicture);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.MainWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.ClosePicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundPicture)).EndInit();
			this.AccountPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.HeadImagePicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AccountClosePicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox BackgroundPicture;
		private OvalPictureBox HeadImagePicture;
		private CueTextBox AccountTextBox;
		private CueTextBox PasswordTextBox;
		private System.Windows.Forms.PictureBox ClosePicture;
		private System.Windows.Forms.Panel AccountPanel;
		private System.Windows.Forms.Panel PasswordPanel;
		private System.Windows.Forms.Button LoginButton;
		private System.Windows.Forms.PictureBox AccountClosePicture;
	}
}

