namespace BasicFacebookFeatures
{
    partial class FormMain
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.labelBirthdateHeadline = new System.Windows.Forms.Label();
            this.labelNameHeadline = new System.Windows.Forms.Label();
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            this.labelBirthdate = new System.Windows.Forms.Label();
            this.linkTimeline = new System.Windows.Forms.LinkLabel();
            this.labelName = new System.Windows.Forms.Label();
            this.lableComments = new System.Windows.Forms.Label();
            this.listBoxComments = new System.Windows.Forms.ListBox();
            this.lableTimeline = new System.Windows.Forms.Label();
            this.listBoxTimeline = new System.Windows.Forms.ListBox();
            this.buttonPost = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.tabPageAlbums = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(18, 17);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(268, 32);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(18, 57);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(268, 32);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMain);
            this.tabControl1.Controls.Add(this.tabPageAlbums);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(89, 27);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1243, 697);
            this.tabControl1.TabIndex = 54;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.labelBirthdateHeadline);
            this.tabPageMain.Controls.Add(this.labelNameHeadline);
            this.tabPageMain.Controls.Add(this.checkBoxRemember);
            this.tabPageMain.Controls.Add(this.labelBirthdate);
            this.tabPageMain.Controls.Add(this.linkTimeline);
            this.tabPageMain.Controls.Add(this.labelName);
            this.tabPageMain.Controls.Add(this.lableComments);
            this.tabPageMain.Controls.Add(this.listBoxComments);
            this.tabPageMain.Controls.Add(this.lableTimeline);
            this.tabPageMain.Controls.Add(this.listBoxTimeline);
            this.tabPageMain.Controls.Add(this.buttonPost);
            this.tabPageMain.Controls.Add(this.textBoxStatus);
            this.tabPageMain.Controls.Add(this.pictureBoxProfile);
            this.tabPageMain.Controls.Add(this.buttonLogout);
            this.tabPageMain.Controls.Add(this.buttonLogin);
            this.tabPageMain.Location = new System.Drawing.Point(4, 31);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(1235, 662);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main Tab";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // labelBirthdateHeadline
            // 
            this.labelBirthdateHeadline.Location = new System.Drawing.Point(814, 57);
            this.labelBirthdateHeadline.Name = "labelBirthdateHeadline";
            this.labelBirthdateHeadline.Size = new System.Drawing.Size(90, 32);
            this.labelBirthdateHeadline.TabIndex = 68;
            this.labelBirthdateHeadline.Text = "Birthday:";
            // 
            // labelNameHeadline
            // 
            this.labelNameHeadline.Location = new System.Drawing.Point(814, 17);
            this.labelNameHeadline.Name = "labelNameHeadline";
            this.labelNameHeadline.Size = new System.Drawing.Size(70, 32);
            this.labelNameHeadline.TabIndex = 67;
            this.labelNameHeadline.Text = "Name:";
            // 
            // checkBoxRemember
            // 
            this.checkBoxRemember.Location = new System.Drawing.Point(306, 23);
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.Size = new System.Drawing.Size(147, 26);
            this.checkBoxRemember.TabIndex = 65;
            this.checkBoxRemember.Text = "Remember Me";
            this.checkBoxRemember.UseVisualStyleBackColor = true;
            // 
            // labelBirthdate
            // 
            this.labelBirthdate.AutoSize = true;
            this.labelBirthdate.Location = new System.Drawing.Point(932, 57);
            this.labelBirthdate.Name = "labelBirthdate";
            this.labelBirthdate.Size = new System.Drawing.Size(0, 24);
            this.labelBirthdate.TabIndex = 66;
            // 
            // linkTimeline
            // 
            this.linkTimeline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkTimeline.Location = new System.Drawing.Point(19, 132);
            this.linkTimeline.Name = "linkTimeline";
            this.linkTimeline.Size = new System.Drawing.Size(100, 17);
            this.linkTimeline.TabIndex = 65;
            this.linkTimeline.TabStop = true;
            this.linkTimeline.Text = "Fetch Timeline";
            this.linkTimeline.MouseClick += new System.Windows.Forms.MouseEventHandler(this.linkTimeline_MouseClick);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(929, 17);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 24);
            this.labelName.TabIndex = 64;
            // 
            // lableComments
            // 
            this.lableComments.Font = new System.Drawing.Font("Dubai", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableComments.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lableComments.Location = new System.Drawing.Point(809, 94);
            this.lableComments.Name = "lableComments";
            this.lableComments.Size = new System.Drawing.Size(187, 44);
            this.lableComments.TabIndex = 61;
            this.lableComments.Text = "Comments";
            // 
            // listBoxComments
            // 
            this.listBoxComments.FormattingEnabled = true;
            this.listBoxComments.ItemHeight = 22;
            this.listBoxComments.Location = new System.Drawing.Point(819, 151);
            this.listBoxComments.Name = "listBoxComments";
            this.listBoxComments.Size = new System.Drawing.Size(323, 356);
            this.listBoxComments.TabIndex = 60;
            // 
            // lableTimeline
            // 
            this.lableTimeline.Font = new System.Drawing.Font("Dubai", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableTimeline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lableTimeline.Location = new System.Drawing.Point(13, 92);
            this.lableTimeline.Name = "lableTimeline";
            this.lableTimeline.Size = new System.Drawing.Size(187, 44);
            this.lableTimeline.TabIndex = 59;
            this.lableTimeline.Text = "Timeline";
            // 
            // listBoxTimeline
            // 
            this.listBoxTimeline.FormattingEnabled = true;
            this.listBoxTimeline.ItemHeight = 22;
            this.listBoxTimeline.Location = new System.Drawing.Point(18, 151);
            this.listBoxTimeline.Name = "listBoxTimeline";
            this.listBoxTimeline.Size = new System.Drawing.Size(775, 356);
            this.listBoxTimeline.TabIndex = 58;
            this.listBoxTimeline.SelectedIndexChanged += new System.EventHandler(this.listBoxTimeline_SelectedIndexChanged);
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(718, 568);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 33);
            this.buttonPost.TabIndex = 57;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPost_MouseClick);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(18, 568);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(682, 67);
            this.textBoxStatus.TabIndex = 56;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProfile.Location = new System.Drawing.Point(1093, 11);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(79, 78);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // tabPageAlbums
            // 
            this.tabPageAlbums.Location = new System.Drawing.Point(4, 31);
            this.tabPageAlbums.Name = "tabPageAlbums";
            this.tabPageAlbums.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlbums.Size = new System.Drawing.Size(1235, 662);
            this.tabPageAlbums.TabIndex = 1;
            this.tabPageAlbums.Text = "Albums";
            this.tabPageAlbums.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 697);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label lableTimeline;
        private System.Windows.Forms.ListBox listBoxTimeline;
        private System.Windows.Forms.Label lableComments;
        private System.Windows.Forms.ListBox listBoxComments;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TabPage tabPageAlbums;
        private System.Windows.Forms.LinkLabel linkTimeline;
        private System.Windows.Forms.Label labelBirthdate;
        private System.Windows.Forms.CheckBox checkBoxRemember;
        private System.Windows.Forms.Label labelBirthdateHeadline;
        private System.Windows.Forms.Label labelNameHeadline;
    }
}

