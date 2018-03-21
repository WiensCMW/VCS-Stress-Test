namespace VersionControlStressTest
{
    partial class frmMain
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
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBoxUpdate = new System.Windows.Forms.GroupBox();
            this.checkBoxPushAfterUpdate = new System.Windows.Forms.CheckBox();
            this.labelUpdateFileSize = new System.Windows.Forms.Label();
            this.textBoxUpdateFileSize = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelUpdateCount = new System.Windows.Forms.Label();
            this.textBoxUpdateCount = new System.Windows.Forms.TextBox();
            this.groupBoxCreate = new System.Windows.Forms.GroupBox();
            this.checkBoxPushAfterCreate = new System.Windows.Forms.CheckBox();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.textBoxCreateFileSize = new System.Windows.Forms.TextBox();
            this.labelFileCount = new System.Windows.Forms.Label();
            this.textBoxCreateFileCount = new System.Windows.Forms.TextBox();
            this.buttonWCBrowse = new System.Windows.Forms.Button();
            this.textBoxWCDir = new System.Windows.Forms.TextBox();
            this.labelWCDir = new System.Windows.Forms.Label();
            this.groupBoxSystem = new System.Windows.Forms.GroupBox();
            this.labelSystem = new System.Windows.Forms.Label();
            this.comboBoxSystem = new System.Windows.Forms.ComboBox();
            this.groupBoxUpdate.SuspendLayout();
            this.groupBoxCreate.SuspendLayout();
            this.groupBoxSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(9, 71);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 3;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // groupBoxUpdate
            // 
            this.groupBoxUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxUpdate.Controls.Add(this.checkBoxPushAfterUpdate);
            this.groupBoxUpdate.Controls.Add(this.labelUpdateFileSize);
            this.groupBoxUpdate.Controls.Add(this.textBoxUpdateFileSize);
            this.groupBoxUpdate.Controls.Add(this.buttonUpdate);
            this.groupBoxUpdate.Controls.Add(this.labelUpdateCount);
            this.groupBoxUpdate.Controls.Add(this.textBoxUpdateCount);
            this.groupBoxUpdate.Location = new System.Drawing.Point(12, 203);
            this.groupBoxUpdate.Name = "groupBoxUpdate";
            this.groupBoxUpdate.Size = new System.Drawing.Size(570, 109);
            this.groupBoxUpdate.TabIndex = 11;
            this.groupBoxUpdate.TabStop = false;
            this.groupBoxUpdate.Text = "Update Files";
            // 
            // checkBoxPushAfterUpdate
            // 
            this.checkBoxPushAfterUpdate.AutoSize = true;
            this.checkBoxPushAfterUpdate.Location = new System.Drawing.Point(95, 74);
            this.checkBoxPushAfterUpdate.Name = "checkBoxPushAfterUpdate";
            this.checkBoxPushAfterUpdate.Size = new System.Drawing.Size(112, 17);
            this.checkBoxPushAfterUpdate.TabIndex = 12;
            this.checkBoxPushAfterUpdate.Text = "Push after Update";
            this.checkBoxPushAfterUpdate.UseVisualStyleBackColor = true;
            // 
            // labelUpdateFileSize
            // 
            this.labelUpdateFileSize.AutoSize = true;
            this.labelUpdateFileSize.Location = new System.Drawing.Point(6, 45);
            this.labelUpdateFileSize.Name = "labelUpdateFileSize";
            this.labelUpdateFileSize.Size = new System.Drawing.Size(61, 13);
            this.labelUpdateFileSize.TabIndex = 9;
            this.labelUpdateFileSize.Text = "Size of File:";
            // 
            // textBoxUpdateFileSize
            // 
            this.textBoxUpdateFileSize.Location = new System.Drawing.Point(95, 42);
            this.textBoxUpdateFileSize.Name = "textBoxUpdateFileSize";
            this.textBoxUpdateFileSize.Size = new System.Drawing.Size(49, 20);
            this.textBoxUpdateFileSize.TabIndex = 10;
            this.textBoxUpdateFileSize.Text = "1";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(9, 70);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelUpdateCount
            // 
            this.labelUpdateCount.AutoSize = true;
            this.labelUpdateCount.Location = new System.Drawing.Point(6, 19);
            this.labelUpdateCount.Name = "labelUpdateCount";
            this.labelUpdateCount.Size = new System.Drawing.Size(102, 13);
            this.labelUpdateCount.TabIndex = 8;
            this.labelUpdateCount.Text = "Number of Updates:";
            // 
            // textBoxUpdateCount
            // 
            this.textBoxUpdateCount.Location = new System.Drawing.Point(114, 16);
            this.textBoxUpdateCount.Name = "textBoxUpdateCount";
            this.textBoxUpdateCount.Size = new System.Drawing.Size(49, 20);
            this.textBoxUpdateCount.TabIndex = 8;
            this.textBoxUpdateCount.Text = "1";
            // 
            // groupBoxCreate
            // 
            this.groupBoxCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCreate.Controls.Add(this.checkBoxPushAfterCreate);
            this.groupBoxCreate.Controls.Add(this.labelFileSize);
            this.groupBoxCreate.Controls.Add(this.textBoxCreateFileSize);
            this.groupBoxCreate.Controls.Add(this.labelFileCount);
            this.groupBoxCreate.Controls.Add(this.textBoxCreateFileCount);
            this.groupBoxCreate.Controls.Add(this.buttonCreate);
            this.groupBoxCreate.Location = new System.Drawing.Point(12, 88);
            this.groupBoxCreate.Name = "groupBoxCreate";
            this.groupBoxCreate.Size = new System.Drawing.Size(570, 109);
            this.groupBoxCreate.TabIndex = 7;
            this.groupBoxCreate.TabStop = false;
            this.groupBoxCreate.Text = "Create Files";
            // 
            // checkBoxPushAfterCreate
            // 
            this.checkBoxPushAfterCreate.AutoSize = true;
            this.checkBoxPushAfterCreate.Location = new System.Drawing.Point(95, 75);
            this.checkBoxPushAfterCreate.Name = "checkBoxPushAfterCreate";
            this.checkBoxPushAfterCreate.Size = new System.Drawing.Size(116, 17);
            this.checkBoxPushAfterCreate.TabIndex = 11;
            this.checkBoxPushAfterCreate.Text = "Push after Creating";
            this.checkBoxPushAfterCreate.UseVisualStyleBackColor = true;
            // 
            // labelFileSize
            // 
            this.labelFileSize.AutoSize = true;
            this.labelFileSize.Location = new System.Drawing.Point(6, 45);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(61, 13);
            this.labelFileSize.TabIndex = 9;
            this.labelFileSize.Text = "Size of File:";
            // 
            // textBoxCreateFileSize
            // 
            this.textBoxCreateFileSize.Location = new System.Drawing.Point(95, 42);
            this.textBoxCreateFileSize.Name = "textBoxCreateFileSize";
            this.textBoxCreateFileSize.Size = new System.Drawing.Size(49, 20);
            this.textBoxCreateFileSize.TabIndex = 10;
            this.textBoxCreateFileSize.Text = "1";
            // 
            // labelFileCount
            // 
            this.labelFileCount.AutoSize = true;
            this.labelFileCount.Location = new System.Drawing.Point(6, 19);
            this.labelFileCount.Name = "labelFileCount";
            this.labelFileCount.Size = new System.Drawing.Size(83, 13);
            this.labelFileCount.TabIndex = 8;
            this.labelFileCount.Text = "Number of Files:";
            // 
            // textBoxCreateFileCount
            // 
            this.textBoxCreateFileCount.Location = new System.Drawing.Point(95, 16);
            this.textBoxCreateFileCount.Name = "textBoxCreateFileCount";
            this.textBoxCreateFileCount.Size = new System.Drawing.Size(49, 20);
            this.textBoxCreateFileCount.TabIndex = 8;
            this.textBoxCreateFileCount.Text = "1";
            // 
            // buttonWCBrowse
            // 
            this.buttonWCBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWCBrowse.Location = new System.Drawing.Point(507, 4);
            this.buttonWCBrowse.Name = "buttonWCBrowse";
            this.buttonWCBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonWCBrowse.TabIndex = 6;
            this.buttonWCBrowse.Text = "Browse";
            this.buttonWCBrowse.UseVisualStyleBackColor = true;
            this.buttonWCBrowse.Click += new System.EventHandler(this.buttonWCDirBrowse_Click);
            // 
            // textBoxWCDir
            // 
            this.textBoxWCDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWCDir.Location = new System.Drawing.Point(95, 6);
            this.textBoxWCDir.Name = "textBoxWCDir";
            this.textBoxWCDir.Size = new System.Drawing.Size(406, 20);
            this.textBoxWCDir.TabIndex = 5;
            // 
            // labelWCDir
            // 
            this.labelWCDir.AutoSize = true;
            this.labelWCDir.Location = new System.Drawing.Point(12, 9);
            this.labelWCDir.Name = "labelWCDir";
            this.labelWCDir.Size = new System.Drawing.Size(77, 13);
            this.labelWCDir.TabIndex = 4;
            this.labelWCDir.Text = "Working Copy:";
            // 
            // groupBoxSystem
            // 
            this.groupBoxSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSystem.Controls.Add(this.labelSystem);
            this.groupBoxSystem.Controls.Add(this.comboBoxSystem);
            this.groupBoxSystem.Location = new System.Drawing.Point(12, 32);
            this.groupBoxSystem.Name = "groupBoxSystem";
            this.groupBoxSystem.Size = new System.Drawing.Size(570, 50);
            this.groupBoxSystem.TabIndex = 12;
            this.groupBoxSystem.TabStop = false;
            this.groupBoxSystem.Text = "Version Control System";
            // 
            // labelSystem
            // 
            this.labelSystem.AutoSize = true;
            this.labelSystem.Location = new System.Drawing.Point(6, 22);
            this.labelSystem.Name = "labelSystem";
            this.labelSystem.Size = new System.Drawing.Size(44, 13);
            this.labelSystem.TabIndex = 9;
            this.labelSystem.Text = "System:";
            // 
            // comboBoxSystem
            // 
            this.comboBoxSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSystem.FormattingEnabled = true;
            this.comboBoxSystem.Items.AddRange(new object[] {
            "Subversion",
            "Mercurial",
            "Git"});
            this.comboBoxSystem.Location = new System.Drawing.Point(56, 19);
            this.comboBoxSystem.Name = "comboBoxSystem";
            this.comboBoxSystem.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSystem.TabIndex = 0;
            this.comboBoxSystem.SelectedIndexChanged += new System.EventHandler(this.comboBoxSystem_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 322);
            this.Controls.Add(this.groupBoxSystem);
            this.Controls.Add(this.groupBoxUpdate);
            this.Controls.Add(this.groupBoxCreate);
            this.Controls.Add(this.labelWCDir);
            this.Controls.Add(this.buttonWCBrowse);
            this.Controls.Add(this.textBoxWCDir);
            this.Name = "frmMain";
            this.Text = "Source Control - Stress Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBoxUpdate.ResumeLayout(false);
            this.groupBoxUpdate.PerformLayout();
            this.groupBoxCreate.ResumeLayout(false);
            this.groupBoxCreate.PerformLayout();
            this.groupBoxSystem.ResumeLayout(false);
            this.groupBoxSystem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonWCBrowse;
        private System.Windows.Forms.TextBox textBoxWCDir;
        private System.Windows.Forms.Label labelWCDir;
        private System.Windows.Forms.GroupBox groupBoxCreate;
        private System.Windows.Forms.Label labelFileCount;
        private System.Windows.Forms.TextBox textBoxCreateFileCount;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.TextBox textBoxCreateFileSize;
        private System.Windows.Forms.GroupBox groupBoxUpdate;
        private System.Windows.Forms.Label labelUpdateFileSize;
        private System.Windows.Forms.TextBox textBoxUpdateFileSize;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelUpdateCount;
        private System.Windows.Forms.TextBox textBoxUpdateCount;
        private System.Windows.Forms.GroupBox groupBoxSystem;
        private System.Windows.Forms.Label labelSystem;
        private System.Windows.Forms.ComboBox comboBoxSystem;
        private System.Windows.Forms.CheckBox checkBoxPushAfterUpdate;
        private System.Windows.Forms.CheckBox checkBoxPushAfterCreate;
    }
}

