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
            this.labelUpdateFileSize = new System.Windows.Forms.Label();
            this.textBoxUpdateFileSize = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelUpdateCount = new System.Windows.Forms.Label();
            this.textBoxUpdateCount = new System.Windows.Forms.TextBox();
            this.groupBoxCreate = new System.Windows.Forms.GroupBox();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.textBoxFileSize = new System.Windows.Forms.TextBox();
            this.labelFileCount = new System.Windows.Forms.Label();
            this.textBoxFileCount = new System.Windows.Forms.TextBox();
            this.buttonSVNWCBrowse = new System.Windows.Forms.Button();
            this.textBoxSVNWC = new System.Windows.Forms.TextBox();
            this.labelSVNWC = new System.Windows.Forms.Label();
            this.groupBoxSystem = new System.Windows.Forms.GroupBox();
            this.labelSystem = new System.Windows.Forms.Label();
            this.comboBoxSystem = new System.Windows.Forms.ComboBox();
            this.checkBoxPushAfterCreate = new System.Windows.Forms.CheckBox();
            this.checkBoxPushAfterUpdate = new System.Windows.Forms.CheckBox();
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
            this.buttonCreate.Click += new System.EventHandler(this.buttonSVNCreate_Click);
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
            this.textBoxUpdateFileSize.Text = "2";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(9, 70);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonSVNUpdate_Click);
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
            this.textBoxUpdateCount.Text = "10";
            // 
            // groupBoxCreate
            // 
            this.groupBoxCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCreate.Controls.Add(this.checkBoxPushAfterCreate);
            this.groupBoxCreate.Controls.Add(this.labelFileSize);
            this.groupBoxCreate.Controls.Add(this.textBoxFileSize);
            this.groupBoxCreate.Controls.Add(this.labelFileCount);
            this.groupBoxCreate.Controls.Add(this.textBoxFileCount);
            this.groupBoxCreate.Controls.Add(this.buttonCreate);
            this.groupBoxCreate.Location = new System.Drawing.Point(12, 88);
            this.groupBoxCreate.Name = "groupBoxCreate";
            this.groupBoxCreate.Size = new System.Drawing.Size(570, 109);
            this.groupBoxCreate.TabIndex = 7;
            this.groupBoxCreate.TabStop = false;
            this.groupBoxCreate.Text = "Create Files";
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
            // textBoxFileSize
            // 
            this.textBoxFileSize.Location = new System.Drawing.Point(95, 42);
            this.textBoxFileSize.Name = "textBoxFileSize";
            this.textBoxFileSize.Size = new System.Drawing.Size(49, 20);
            this.textBoxFileSize.TabIndex = 10;
            this.textBoxFileSize.Text = "2";
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
            // textBoxFileCount
            // 
            this.textBoxFileCount.Location = new System.Drawing.Point(95, 16);
            this.textBoxFileCount.Name = "textBoxFileCount";
            this.textBoxFileCount.Size = new System.Drawing.Size(49, 20);
            this.textBoxFileCount.TabIndex = 8;
            this.textBoxFileCount.Text = "10";
            // 
            // buttonSVNWCBrowse
            // 
            this.buttonSVNWCBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSVNWCBrowse.Location = new System.Drawing.Point(507, 4);
            this.buttonSVNWCBrowse.Name = "buttonSVNWCBrowse";
            this.buttonSVNWCBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonSVNWCBrowse.TabIndex = 6;
            this.buttonSVNWCBrowse.Text = "Browse";
            this.buttonSVNWCBrowse.UseVisualStyleBackColor = true;
            this.buttonSVNWCBrowse.Click += new System.EventHandler(this.buttonSVNWCBrowse_Click);
            // 
            // textBoxSVNWC
            // 
            this.textBoxSVNWC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSVNWC.Location = new System.Drawing.Point(95, 6);
            this.textBoxSVNWC.Name = "textBoxSVNWC";
            this.textBoxSVNWC.Size = new System.Drawing.Size(406, 20);
            this.textBoxSVNWC.TabIndex = 5;
            // 
            // labelSVNWC
            // 
            this.labelSVNWC.AutoSize = true;
            this.labelSVNWC.Location = new System.Drawing.Point(12, 9);
            this.labelSVNWC.Name = "labelSVNWC";
            this.labelSVNWC.Size = new System.Drawing.Size(77, 13);
            this.labelSVNWC.TabIndex = 4;
            this.labelSVNWC.Text = "Working Copy:";
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
            "Mercurial"});
            this.comboBoxSystem.Location = new System.Drawing.Point(56, 19);
            this.comboBoxSystem.Name = "comboBoxSystem";
            this.comboBoxSystem.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSystem.TabIndex = 0;
            this.comboBoxSystem.SelectedIndexChanged += new System.EventHandler(this.comboBoxSystem_SelectedIndexChanged);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 322);
            this.Controls.Add(this.groupBoxSystem);
            this.Controls.Add(this.groupBoxUpdate);
            this.Controls.Add(this.groupBoxCreate);
            this.Controls.Add(this.labelSVNWC);
            this.Controls.Add(this.buttonSVNWCBrowse);
            this.Controls.Add(this.textBoxSVNWC);
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
        private System.Windows.Forms.Button buttonSVNWCBrowse;
        private System.Windows.Forms.TextBox textBoxSVNWC;
        private System.Windows.Forms.Label labelSVNWC;
        private System.Windows.Forms.GroupBox groupBoxCreate;
        private System.Windows.Forms.Label labelFileCount;
        private System.Windows.Forms.TextBox textBoxFileCount;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.TextBox textBoxFileSize;
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

