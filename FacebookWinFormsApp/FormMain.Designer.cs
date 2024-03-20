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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label birthdayLabel;
            System.Windows.Forms.Label religionLabel;
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.panelUserDetails = new System.Windows.Forms.Panel();
            this.birthdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.imageSquarePictureBox = new System.Windows.Forms.PictureBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.religionTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelAutoStatus = new System.Windows.Forms.TableLayoutPanel();
            this.btnAutoShoutoutAlbum = new System.Windows.Forms.Button();
            this.btnAutoCompliment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAutoFavoritePages = new System.Windows.Forms.Button();
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            this.linkTimeline = new System.Windows.Forms.LinkLabel();
            this.lableComments = new System.Windows.Forms.Label();
            this.listBoxComments = new System.Windows.Forms.ListBox();
            this.lableTimeline = new System.Windows.Forms.Label();
            this.listBoxTimeline = new System.Windows.Forms.ListBox();
            this.buttonPost = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.tabAlbums = new System.Windows.Forms.TabPage();
            this.tabFriends = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.tabLikedPages = new System.Windows.Forms.TabPage();
            birthdayLabel = new System.Windows.Forms.Label();
            religionLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.panelUserDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSquarePictureBox)).BeginInit();
            this.tableLayoutPanelAutoStatus.SuspendLayout();
            this.tabFriends.SuspendLayout();
            this.SuspendLayout();
            // 
            // birthdayLabel
            // 
            birthdayLabel.AutoSize = true;
            birthdayLabel.Location = new System.Drawing.Point(8, 44);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new System.Drawing.Size(82, 24);
            birthdayLabel.TabIndex = 0;
            birthdayLabel.Text = "Birthday:";
            // 
            // religionLabel
            // 
            religionLabel.AutoSize = true;
            religionLabel.Location = new System.Drawing.Point(8, 81);
            religionLabel.Name = "religionLabel";
            religionLabel.Size = new System.Drawing.Size(84, 24);
            religionLabel.TabIndex = 8;
            religionLabel.Text = "Religion:";
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabAlbums);
            this.tabControl.Controls.Add(this.tabFriends);
            this.tabControl.Controls.Add(this.tabLikedPages);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(89, 27);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1243, 697);
            this.tabControl.TabIndex = 54;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.buttonCancel);
            this.tabPageMain.Controls.Add(this.buttonEdit);
            this.tabPageMain.Controls.Add(this.panelUserDetails);
            this.tabPageMain.Controls.Add(this.tableLayoutPanelAutoStatus);
            this.tabPageMain.Controls.Add(this.checkBoxRemember);
            this.tabPageMain.Controls.Add(this.linkTimeline);
            this.tabPageMain.Controls.Add(this.lableComments);
            this.tabPageMain.Controls.Add(this.listBoxComments);
            this.tabPageMain.Controls.Add(this.lableTimeline);
            this.tabPageMain.Controls.Add(this.listBoxTimeline);
            this.tabPageMain.Controls.Add(this.buttonPost);
            this.tabPageMain.Controls.Add(this.textBoxStatus);
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
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(718, 57);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 32);
            this.buttonCancel.TabIndex = 72;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(718, 21);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(84, 33);
            this.buttonEdit.TabIndex = 71;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Visible = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // panelUserDetails
            // 
            this.panelUserDetails.Controls.Add(birthdayLabel);
            this.panelUserDetails.Controls.Add(this.birthdayDateTimePicker);
            this.panelUserDetails.Controls.Add(this.firstNameTextBox);
            this.panelUserDetails.Controls.Add(this.imageSquarePictureBox);
            this.panelUserDetails.Controls.Add(this.lastNameTextBox);
            this.panelUserDetails.Controls.Add(religionLabel);
            this.panelUserDetails.Controls.Add(this.religionTextBox);
            this.panelUserDetails.Enabled = false;
            this.panelUserDetails.Location = new System.Drawing.Point(819, 17);
            this.panelUserDetails.Name = "panelUserDetails";
            this.panelUserDetails.Size = new System.Drawing.Size(395, 119);
            this.panelUserDetails.TabIndex = 70;
            // 
            // birthdayDateTimePicker
            // 
            this.birthdayDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.userBindingSource, "Birthday", true));
            this.birthdayDateTimePicker.Location = new System.Drawing.Point(96, 44);
            this.birthdayDateTimePicker.Name = "birthdayDateTimePicker";
            this.birthdayDateTimePicker.Size = new System.Drawing.Size(200, 28);
            this.birthdayDateTimePicker.TabIndex = 1;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "FirstName", true));
            this.firstNameTextBox.Location = new System.Drawing.Point(12, 6);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(142, 28);
            this.firstNameTextBox.TabIndex = 3;
            // 
            // imageSquarePictureBox
            // 
            this.imageSquarePictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.userBindingSource, "ImageSquare", true));
            this.imageSquarePictureBox.Location = new System.Drawing.Point(302, 6);
            this.imageSquarePictureBox.Name = "imageSquarePictureBox";
            this.imageSquarePictureBox.Size = new System.Drawing.Size(89, 84);
            this.imageSquarePictureBox.TabIndex = 5;
            this.imageSquarePictureBox.TabStop = false;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "LastName", true));
            this.lastNameTextBox.Location = new System.Drawing.Point(160, 6);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(136, 28);
            this.lastNameTextBox.TabIndex = 7;
            // 
            // religionTextBox
            // 
            this.religionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Religion", true));
            this.religionTextBox.Location = new System.Drawing.Point(96, 78);
            this.religionTextBox.Name = "religionTextBox";
            this.religionTextBox.Size = new System.Drawing.Size(200, 28);
            this.religionTextBox.TabIndex = 9;
            // 
            // tableLayoutPanelAutoStatus
            // 
            this.tableLayoutPanelAutoStatus.ColumnCount = 1;
            this.tableLayoutPanelAutoStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelAutoStatus.Controls.Add(this.btnAutoShoutoutAlbum, 0, 3);
            this.tableLayoutPanelAutoStatus.Controls.Add(this.btnAutoCompliment, 0, 1);
            this.tableLayoutPanelAutoStatus.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelAutoStatus.Controls.Add(this.btnAutoFavoritePages, 0, 2);
            this.tableLayoutPanelAutoStatus.Location = new System.Drawing.Point(819, 498);
            this.tableLayoutPanelAutoStatus.Name = "tableLayoutPanelAutoStatus";
            this.tableLayoutPanelAutoStatus.RowCount = 4;
            this.tableLayoutPanelAutoStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelAutoStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelAutoStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelAutoStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelAutoStatus.Size = new System.Drawing.Size(200, 156);
            this.tableLayoutPanelAutoStatus.TabIndex = 69;
            // 
            // btnAutoShoutoutAlbum
            // 
            this.btnAutoShoutoutAlbum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoShoutoutAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoShoutoutAlbum.Location = new System.Drawing.Point(8, 116);
            this.btnAutoShoutoutAlbum.Name = "btnAutoShoutoutAlbum";
            this.btnAutoShoutoutAlbum.Size = new System.Drawing.Size(184, 34);
            this.btnAutoShoutoutAlbum.TabIndex = 5;
            this.btnAutoShoutoutAlbum.Text = "Shoutout album";
            this.btnAutoShoutoutAlbum.UseVisualStyleBackColor = true;
            this.btnAutoShoutoutAlbum.Click += new System.EventHandler(this.btnAutoShoutoutAlbum_Click);
            // 
            // btnAutoCompliment
            // 
            this.btnAutoCompliment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoCompliment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoCompliment.Location = new System.Drawing.Point(7, 33);
            this.btnAutoCompliment.Name = "btnAutoCompliment";
            this.btnAutoCompliment.Size = new System.Drawing.Size(186, 34);
            this.btnAutoCompliment.TabIndex = 4;
            this.btnAutoCompliment.Text = "Compliment friend";
            this.btnAutoCompliment.UseVisualStyleBackColor = true;
            this.btnAutoCompliment.Click += new System.EventHandler(this.btnAutoCompliment_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Auto Status";
            // 
            // btnAutoFavoritePages
            // 
            this.btnAutoFavoritePages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoFavoritePages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoFavoritePages.Location = new System.Drawing.Point(7, 73);
            this.btnAutoFavoritePages.Name = "btnAutoFavoritePages";
            this.btnAutoFavoritePages.Size = new System.Drawing.Size(186, 34);
            this.btnAutoFavoritePages.TabIndex = 2;
            this.btnAutoFavoritePages.Text = "Favorite Pages";
            this.btnAutoFavoritePages.UseVisualStyleBackColor = true;
            this.btnAutoFavoritePages.Click += new System.EventHandler(this.btnAutoFavoritePages_Click);
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
            // lableComments
            // 
            this.lableComments.Font = new System.Drawing.Font("Dubai", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableComments.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lableComments.Location = new System.Drawing.Point(809, 151);
            this.lableComments.Name = "lableComments";
            this.lableComments.Size = new System.Drawing.Size(187, 44);
            this.lableComments.TabIndex = 61;
            this.lableComments.Text = "Comments";
            // 
            // listBoxComments
            // 
            this.listBoxComments.FormattingEnabled = true;
            this.listBoxComments.ItemHeight = 22;
            this.listBoxComments.Location = new System.Drawing.Point(819, 202);
            this.listBoxComments.Name = "listBoxComments";
            this.listBoxComments.Size = new System.Drawing.Size(323, 290);
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
            // tabAlbums
            // 
            this.tabAlbums.Location = new System.Drawing.Point(4, 31);
            this.tabAlbums.Name = "tabAlbums";
            this.tabAlbums.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlbums.Size = new System.Drawing.Size(1235, 662);
            this.tabAlbums.TabIndex = 1;
            this.tabAlbums.Text = "Albums";
            this.tabAlbums.UseVisualStyleBackColor = true;
            // 
            // tabFriends
            // 
            this.tabFriends.Controls.Add(this.btnClear);
            this.tabFriends.Controls.Add(this.filterButton);
            this.tabFriends.Location = new System.Drawing.Point(4, 31);
            this.tabFriends.Name = "tabFriends";
            this.tabFriends.Padding = new System.Windows.Forms.Padding(3);
            this.tabFriends.Size = new System.Drawing.Size(1235, 662);
            this.tabFriends.TabIndex = 2;
            this.tabFriends.Text = "Friends";
            this.tabFriends.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1071, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(1152, 6);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 30);
            this.filterButton.TabIndex = 0;
            this.filterButton.Text = "filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // tabLikedPages
            // 
            this.tabLikedPages.Location = new System.Drawing.Point(4, 31);
            this.tabLikedPages.Name = "tabLikedPages";
            this.tabLikedPages.Padding = new System.Windows.Forms.Padding(3);
            this.tabLikedPages.Size = new System.Drawing.Size(1235, 662);
            this.tabLikedPages.TabIndex = 3;
            this.tabLikedPages.Text = "Pages";
            this.tabLikedPages.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 697);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.tabControl.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.panelUserDetails.ResumeLayout(false);
            this.panelUserDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSquarePictureBox)).EndInit();
            this.tableLayoutPanelAutoStatus.ResumeLayout(false);
            this.tableLayoutPanelAutoStatus.PerformLayout();
            this.tabFriends.ResumeLayout(false);
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label lableTimeline;
        private System.Windows.Forms.ListBox listBoxTimeline;
        private System.Windows.Forms.Label lableComments;
        private System.Windows.Forms.ListBox listBoxComments;
        private System.Windows.Forms.TabPage tabAlbums;
        private System.Windows.Forms.LinkLabel linkTimeline;
        private System.Windows.Forms.CheckBox checkBoxRemember;
        private System.Windows.Forms.TabPage tabFriends;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabPage tabLikedPages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAutoStatus;
        private System.Windows.Forms.Button btnAutoShoutoutAlbum;
        private System.Windows.Forms.Button btnAutoCompliment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAutoFavoritePages;
        private System.Windows.Forms.Panel panelUserDetails;
        private System.Windows.Forms.DateTimePicker birthdayDateTimePicker;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.PictureBox imageSquarePictureBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox religionTextBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonEdit;
    }
}

