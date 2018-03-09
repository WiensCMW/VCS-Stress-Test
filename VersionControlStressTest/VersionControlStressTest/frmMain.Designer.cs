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
            this.buttonSVNCreate = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSVN = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSVNUpdateFileSize = new System.Windows.Forms.Label();
            this.textBoxSVNUpdateFileSize = new System.Windows.Forms.TextBox();
            this.buttonSVNUpdate = new System.Windows.Forms.Button();
            this.labelSVNUpdateCount = new System.Windows.Forms.Label();
            this.textBoxSVNUpdateCount = new System.Windows.Forms.TextBox();
            this.groupBoxSVNCreate = new System.Windows.Forms.GroupBox();
            this.labelSVNFileSize = new System.Windows.Forms.Label();
            this.textBoxSVNFileSize = new System.Windows.Forms.TextBox();
            this.labelSVNFileCount = new System.Windows.Forms.Label();
            this.textBoxSVNFilesCount = new System.Windows.Forms.TextBox();
            this.buttonSVNWCBrowse = new System.Windows.Forms.Button();
            this.textBoxSVNWC = new System.Windows.Forms.TextBox();
            this.labelSVNWC = new System.Windows.Forms.Label();
            this.tabPageHG = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.tabPageSVN.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxSVNCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSVNCreate
            // 
            this.buttonSVNCreate.Location = new System.Drawing.Point(9, 71);
            this.buttonSVNCreate.Name = "buttonSVNCreate";
            this.buttonSVNCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonSVNCreate.TabIndex = 3;
            this.buttonSVNCreate.Text = "Create";
            this.buttonSVNCreate.UseVisualStyleBackColor = true;
            this.buttonSVNCreate.Click += new System.EventHandler(this.buttonSVNCreate_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageSVN);
            this.tabControlMain.Controls.Add(this.tabPageHG);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(594, 403);
            this.tabControlMain.TabIndex = 4;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageSVN
            // 
            this.tabPageSVN.Controls.Add(this.groupBox1);
            this.tabPageSVN.Controls.Add(this.groupBoxSVNCreate);
            this.tabPageSVN.Controls.Add(this.buttonSVNWCBrowse);
            this.tabPageSVN.Controls.Add(this.textBoxSVNWC);
            this.tabPageSVN.Controls.Add(this.labelSVNWC);
            this.tabPageSVN.Location = new System.Drawing.Point(4, 22);
            this.tabPageSVN.Name = "tabPageSVN";
            this.tabPageSVN.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSVN.Size = new System.Drawing.Size(586, 377);
            this.tabPageSVN.TabIndex = 0;
            this.tabPageSVN.Text = "SVN";
            this.tabPageSVN.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSVNUpdateFileSize);
            this.groupBox1.Controls.Add(this.textBoxSVNUpdateFileSize);
            this.groupBox1.Controls.Add(this.buttonSVNUpdate);
            this.groupBox1.Controls.Add(this.labelSVNUpdateCount);
            this.groupBox1.Controls.Add(this.textBoxSVNUpdateCount);
            this.groupBox1.Location = new System.Drawing.Point(8, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 109);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Files";
            // 
            // labelSVNUpdateFileSize
            // 
            this.labelSVNUpdateFileSize.AutoSize = true;
            this.labelSVNUpdateFileSize.Location = new System.Drawing.Point(6, 45);
            this.labelSVNUpdateFileSize.Name = "labelSVNUpdateFileSize";
            this.labelSVNUpdateFileSize.Size = new System.Drawing.Size(61, 13);
            this.labelSVNUpdateFileSize.TabIndex = 9;
            this.labelSVNUpdateFileSize.Text = "Size of File:";
            // 
            // textBoxSVNUpdateFileSize
            // 
            this.textBoxSVNUpdateFileSize.Location = new System.Drawing.Point(95, 42);
            this.textBoxSVNUpdateFileSize.Name = "textBoxSVNUpdateFileSize";
            this.textBoxSVNUpdateFileSize.Size = new System.Drawing.Size(49, 20);
            this.textBoxSVNUpdateFileSize.TabIndex = 10;
            this.textBoxSVNUpdateFileSize.Text = "2";
            // 
            // buttonSVNUpdate
            // 
            this.buttonSVNUpdate.Location = new System.Drawing.Point(9, 70);
            this.buttonSVNUpdate.Name = "buttonSVNUpdate";
            this.buttonSVNUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonSVNUpdate.TabIndex = 3;
            this.buttonSVNUpdate.Text = "Update";
            this.buttonSVNUpdate.UseVisualStyleBackColor = true;
            this.buttonSVNUpdate.Click += new System.EventHandler(this.buttonSVNUpdate_Click);
            // 
            // labelSVNUpdateCount
            // 
            this.labelSVNUpdateCount.AutoSize = true;
            this.labelSVNUpdateCount.Location = new System.Drawing.Point(6, 19);
            this.labelSVNUpdateCount.Name = "labelSVNUpdateCount";
            this.labelSVNUpdateCount.Size = new System.Drawing.Size(102, 13);
            this.labelSVNUpdateCount.TabIndex = 8;
            this.labelSVNUpdateCount.Text = "Number of Updates:";
            // 
            // textBoxSVNUpdateCount
            // 
            this.textBoxSVNUpdateCount.Location = new System.Drawing.Point(114, 16);
            this.textBoxSVNUpdateCount.Name = "textBoxSVNUpdateCount";
            this.textBoxSVNUpdateCount.Size = new System.Drawing.Size(49, 20);
            this.textBoxSVNUpdateCount.TabIndex = 8;
            this.textBoxSVNUpdateCount.Text = "10";
            // 
            // groupBoxSVNCreate
            // 
            this.groupBoxSVNCreate.Controls.Add(this.labelSVNFileSize);
            this.groupBoxSVNCreate.Controls.Add(this.textBoxSVNFileSize);
            this.groupBoxSVNCreate.Controls.Add(this.labelSVNFileCount);
            this.groupBoxSVNCreate.Controls.Add(this.textBoxSVNFilesCount);
            this.groupBoxSVNCreate.Controls.Add(this.buttonSVNCreate);
            this.groupBoxSVNCreate.Location = new System.Drawing.Point(8, 32);
            this.groupBoxSVNCreate.Name = "groupBoxSVNCreate";
            this.groupBoxSVNCreate.Size = new System.Drawing.Size(570, 109);
            this.groupBoxSVNCreate.TabIndex = 7;
            this.groupBoxSVNCreate.TabStop = false;
            this.groupBoxSVNCreate.Text = "Create Files";
            // 
            // labelSVNFileSize
            // 
            this.labelSVNFileSize.AutoSize = true;
            this.labelSVNFileSize.Location = new System.Drawing.Point(6, 45);
            this.labelSVNFileSize.Name = "labelSVNFileSize";
            this.labelSVNFileSize.Size = new System.Drawing.Size(61, 13);
            this.labelSVNFileSize.TabIndex = 9;
            this.labelSVNFileSize.Text = "Size of File:";
            // 
            // textBoxSVNFileSize
            // 
            this.textBoxSVNFileSize.Location = new System.Drawing.Point(95, 42);
            this.textBoxSVNFileSize.Name = "textBoxSVNFileSize";
            this.textBoxSVNFileSize.Size = new System.Drawing.Size(49, 20);
            this.textBoxSVNFileSize.TabIndex = 10;
            this.textBoxSVNFileSize.Text = "2";
            // 
            // labelSVNFileCount
            // 
            this.labelSVNFileCount.AutoSize = true;
            this.labelSVNFileCount.Location = new System.Drawing.Point(6, 19);
            this.labelSVNFileCount.Name = "labelSVNFileCount";
            this.labelSVNFileCount.Size = new System.Drawing.Size(83, 13);
            this.labelSVNFileCount.TabIndex = 8;
            this.labelSVNFileCount.Text = "Number of Files:";
            // 
            // textBoxSVNFilesCount
            // 
            this.textBoxSVNFilesCount.Location = new System.Drawing.Point(95, 16);
            this.textBoxSVNFilesCount.Name = "textBoxSVNFilesCount";
            this.textBoxSVNFilesCount.Size = new System.Drawing.Size(49, 20);
            this.textBoxSVNFilesCount.TabIndex = 8;
            this.textBoxSVNFilesCount.Text = "10";
            // 
            // buttonSVNWCBrowse
            // 
            this.buttonSVNWCBrowse.Location = new System.Drawing.Point(503, 4);
            this.buttonSVNWCBrowse.Name = "buttonSVNWCBrowse";
            this.buttonSVNWCBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonSVNWCBrowse.TabIndex = 6;
            this.buttonSVNWCBrowse.Text = "Browse";
            this.buttonSVNWCBrowse.UseVisualStyleBackColor = true;
            this.buttonSVNWCBrowse.Click += new System.EventHandler(this.buttonSVNWCBrowse_Click);
            // 
            // textBoxSVNWC
            // 
            this.textBoxSVNWC.Location = new System.Drawing.Point(91, 6);
            this.textBoxSVNWC.Name = "textBoxSVNWC";
            this.textBoxSVNWC.Size = new System.Drawing.Size(406, 20);
            this.textBoxSVNWC.TabIndex = 5;
            this.textBoxSVNWC.Text = "D:\\_repos\\StressTest\\trunk";
            // 
            // labelSVNWC
            // 
            this.labelSVNWC.AutoSize = true;
            this.labelSVNWC.Location = new System.Drawing.Point(8, 9);
            this.labelSVNWC.Name = "labelSVNWC";
            this.labelSVNWC.Size = new System.Drawing.Size(77, 13);
            this.labelSVNWC.TabIndex = 4;
            this.labelSVNWC.Text = "Working Copy:";
            // 
            // tabPageHG
            // 
            this.tabPageHG.Location = new System.Drawing.Point(4, 22);
            this.tabPageHG.Name = "tabPageHG";
            this.tabPageHG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHG.Size = new System.Drawing.Size(586, 377);
            this.tabPageHG.TabIndex = 1;
            this.tabPageHG.Text = "Mercurial";
            this.tabPageHG.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 403);
            this.Controls.Add(this.tabControlMain);
            this.Name = "frmMain";
            this.Text = "Source Control - Stress Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSVN.ResumeLayout(false);
            this.tabPageSVN.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxSVNCreate.ResumeLayout(false);
            this.groupBoxSVNCreate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSVNCreate;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSVN;
        private System.Windows.Forms.TabPage tabPageHG;
        private System.Windows.Forms.Button buttonSVNWCBrowse;
        private System.Windows.Forms.TextBox textBoxSVNWC;
        private System.Windows.Forms.Label labelSVNWC;
        private System.Windows.Forms.GroupBox groupBoxSVNCreate;
        private System.Windows.Forms.Label labelSVNFileCount;
        private System.Windows.Forms.TextBox textBoxSVNFilesCount;
        private System.Windows.Forms.Label labelSVNFileSize;
        private System.Windows.Forms.TextBox textBoxSVNFileSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelSVNUpdateFileSize;
        private System.Windows.Forms.TextBox textBoxSVNUpdateFileSize;
        private System.Windows.Forms.Button buttonSVNUpdate;
        private System.Windows.Forms.Label labelSVNUpdateCount;
        private System.Windows.Forms.TextBox textBoxSVNUpdateCount;
    }
}

