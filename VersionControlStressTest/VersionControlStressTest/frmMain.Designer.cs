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
            this.button2 = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSVN = new System.Windows.Forms.TabPage();
            this.tabPageHG = new System.Windows.Forms.TabPage();
            this.labelSVNWC = new System.Windows.Forms.Label();
            this.textBoxSVNWC = new System.Windows.Forms.TextBox();
            this.buttonSVNWCBrowse = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageSVN.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Testing";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // 
            // tabPageSVN
            // 
            this.tabPageSVN.Controls.Add(this.buttonSVNWCBrowse);
            this.tabPageSVN.Controls.Add(this.textBoxSVNWC);
            this.tabPageSVN.Controls.Add(this.labelSVNWC);
            this.tabPageSVN.Controls.Add(this.button2);
            this.tabPageSVN.Location = new System.Drawing.Point(4, 22);
            this.tabPageSVN.Name = "tabPageSVN";
            this.tabPageSVN.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSVN.Size = new System.Drawing.Size(586, 377);
            this.tabPageSVN.TabIndex = 0;
            this.tabPageSVN.Text = "SVN";
            this.tabPageSVN.UseVisualStyleBackColor = true;
            // 
            // tabPageHG
            // 
            this.tabPageHG.Location = new System.Drawing.Point(4, 22);
            this.tabPageHG.Name = "tabPageHG";
            this.tabPageHG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHG.Size = new System.Drawing.Size(524, 401);
            this.tabPageHG.TabIndex = 1;
            this.tabPageHG.Text = "Mercurial";
            this.tabPageHG.UseVisualStyleBackColor = true;
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
            // textBoxSVNWC
            // 
            this.textBoxSVNWC.Location = new System.Drawing.Point(91, 6);
            this.textBoxSVNWC.Name = "textBoxSVNWC";
            this.textBoxSVNWC.ReadOnly = true;
            this.textBoxSVNWC.Size = new System.Drawing.Size(406, 20);
            this.textBoxSVNWC.TabIndex = 5;
            // 
            // buttonSVNWCBrowse
            // 
            this.buttonSVNWCBrowse.Location = new System.Drawing.Point(503, 4);
            this.buttonSVNWCBrowse.Name = "buttonSVNWCBrowse";
            this.buttonSVNWCBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonSVNWCBrowse.TabIndex = 6;
            this.buttonSVNWCBrowse.Text = "Browse";
            this.buttonSVNWCBrowse.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 403);
            this.Controls.Add(this.tabControlMain);
            this.Name = "frmMain";
            this.Text = "Source Control - Stress Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSVN.ResumeLayout(false);
            this.tabPageSVN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSVN;
        private System.Windows.Forms.TabPage tabPageHG;
        private System.Windows.Forms.Button buttonSVNWCBrowse;
        private System.Windows.Forms.TextBox textBoxSVNWC;
        private System.Windows.Forms.Label labelSVNWC;
    }
}

