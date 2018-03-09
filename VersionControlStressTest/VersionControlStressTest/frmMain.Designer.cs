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
            this.groupBoxSVNCreate = new System.Windows.Forms.GroupBox();
            this.labelSVNFileCount = new System.Windows.Forms.Label();
            this.textBoxSVNFilesCount = new System.Windows.Forms.TextBox();
            this.buttonSVNWCBrowse = new System.Windows.Forms.Button();
            this.textBoxSVNWC = new System.Windows.Forms.TextBox();
            this.labelSVNWC = new System.Windows.Forms.Label();
            this.tabPageHG = new System.Windows.Forms.TabPage();
            this.labelSVNFileSize = new System.Windows.Forms.Label();
            this.textBoxSVNFileSize = new System.Windows.Forms.TextBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageSVN.SuspendLayout();
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
            this.textBoxSVNWC.ReadOnly = true;
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
            // labelSVNFileSize
            // 
            this.labelSVNFileSize.AutoSize = true;
            this.labelSVNFileSize.Location = new System.Drawing.Point(6, 45);
            this.labelSVNFileSize.Name = "labelSVNFileSize";
            this.labelSVNFileSize.Size = new System.Drawing.Size(83, 13);
            this.labelSVNFileSize.TabIndex = 9;
            this.labelSVNFileSize.Text = "Number of Files:";
            // 
            // textBoxSVNFileSize
            // 
            this.textBoxSVNFileSize.Location = new System.Drawing.Point(95, 42);
            this.textBoxSVNFileSize.Name = "textBoxSVNFileSize";
            this.textBoxSVNFileSize.Size = new System.Drawing.Size(49, 20);
            this.textBoxSVNFileSize.TabIndex = 10;
            this.textBoxSVNFileSize.Text = "2";
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
    }
}

