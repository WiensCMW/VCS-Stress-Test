using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using VersionControlStressTest.Properties;

namespace VersionControlStressTest
{
    public partial class frmMain : Form
    {
        private MyThreadHelper _mth = new MyThreadHelper();
        private MyWorker _workerTest;

        #region General Methods
        public frmMain()
        {
            InitializeComponent();

            // Initialize Background Workers
            _workerTest = new MyWorker();
            _workerTest.WorkerReportsProgress = true;
            _workerTest.WorkerSupportsCancellation = true;
            _workerTest.DoWork += new DoWorkEventHandler(_workerTest_DoWork);
            _workerTest.ProgressChanged += new ProgressChangedEventHandler(_workerTest_ProgressChanged);
            _workerTest.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_workerTest_RunWorkerCompleted);

            // Add to worker list so it can be cancelled on form closing
            _mth.WorkerList.Add(_workerTest);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Restore saved settings
                if (!string.IsNullOrEmpty(Settings.Default.Directory))
                    textBoxWCDir.Text = Settings.Default.Directory;

                if (Settings.Default.SelectedSystem <= (comboBoxSystem.Items.Count - 1))
                    comboBoxSystem.SelectedIndex = Settings.Default.SelectedSystem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                #region Cancel all running Workers, Threads and Timers
                //label1.Text = "Cleaning up background threads, please wait";

                #region Cancel all Workers
                bool cancelFail = false;
                for (int i = 0; i < _mth.WorkerList.Count; i++)
                {
                    if (!_mth.WorkerList[i].IsIdle)
                    {
                        // Command worker to cancel itself
                        _mth.WorkerList[i].CancelAsync();

                        // Force UI Thread to wait until worker signals it's Reset Event, or timeout after 15000 milliseconds
                        if (!_mth.WorkerList[i].Reset.WaitOne(15000))
                            cancelFail = true;
                    }
                }
                #endregion

                if (cancelFail)
                {
                    MessageBox.Show("Unable to clean up all background threads." + "\n" + "\n"
                        + "Please wait a few seconds and try closing the app again."
                        , "Thread cleanup failed"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);

                    e.Cancel = true;
                    return;
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Save selected system
                Settings.Default.SelectedSystem = comboBoxSystem.SelectedIndex;
                Settings.Default.Save();

                SetFormControls();

                // Clear selected directory
                textBoxWCDir.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFormControls()
        {
            try
            {
                // Set controls based on selected system
                switch (comboBoxSystem.SelectedIndex)
                {
                    case 0: // Subversion
                        {
                            checkBoxPushAfterCreate.Visible = false;
                            checkBoxPushAfterUpdate.Visible = false;
                            break;
                        }
                    case 1: // Mercurial
                        {
                            checkBoxPushAfterCreate.Visible = true;
                            checkBoxPushAfterUpdate.Visible = true;
                            break;
                        }
                    case 2: // Git
                        {
                            checkBoxPushAfterCreate.Visible = true;
                            checkBoxPushAfterUpdate.Visible = true;
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region VSC Methods
        private void buttonWCDirBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog diag = new FolderBrowserDialog();
                DialogResult results = diag.ShowDialog(this);
                if (results == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(diag.SelectedPath)
                        && Directory.Exists(diag.SelectedPath))
                    {
                        if (!DirectoryIsWC(diag.SelectedPath, "." + GetSystemType()))
                        {
                            MessageBox.Show("Selected directory is not part of a Working Copy."
                                , "Invalid Directory"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Warning);
                            textBoxWCDir.Text = "";
                        }
                        else
                        {
                            textBoxWCDir.Text = diag.SelectedPath;
                            Settings.Default.Directory = diag.SelectedPath;
                            Settings.Default.Save();
                        }
                    }
                    else
                        textBoxWCDir.Text = "";
                }
                else
                    textBoxWCDir.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Checks if the passed in Directory or any of it's parents are valid Working Copies.
        /// </summary>
        /// <param name="dir">The path of the directory you want to search.</param>
        /// <param name="vcsHiddenFolder">The Version Control hidden folder to indicate it's a working copy</param>
        /// <param name="prevDir">pass null on first call. Used to prevent infinite recusions.</param>
        /// <returns>Returns true if valid working directory was found, else returns false.</returns>
        private bool DirectoryIsWC(string dir, string vcsHiddenFolder, string prevDir = null)
        {
            try
            {
                // Search passed in dir for folders matching the passed in systemType
                string[] localDirResults = Directory.GetDirectories(dir, vcsHiddenFolder);

                // Return true if any results were found
                if (localDirResults.Length > 0)
                    return true;
                else
                {
                    // Create new path for one directory up from passed in directory
                    string newDir = Path.GetFullPath(Path.Combine(dir, @"..\"));

                    // Check against infinite recusion
                    if (prevDir == dir)
                        return false;

                    // Return false if new directory isn't valid
                    if (!Directory.Exists(newDir))
                        return false;
                    else
                        // Call current method in recursive method with new directory
                        return DirectoryIsWC(newDir, vcsHiddenFolder, dir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private String GetSystemType()
        {
            switch (comboBoxSystem.SelectedIndex)
            {
                case 0:
                    return "svn";
                case 1:
                    return "hg";
                case 2:
                    return "git";
                default:
                    return "";
            }
        }

        private bool ValidateVCS(string dir, int fileCount, int fileSize)
        {
            try
            {
                // Validate
                if (string.IsNullOrEmpty(dir))
                {
                    MessageBox.Show("Working Copy Directory can't be empty.");
                    return false;
                }
                else if (!Directory.Exists(dir))
                {
                    MessageBox.Show("Selected Working Copy Directory doesn't exist.");
                    return false;
                }
                else if (!DirectoryIsWC(dir, "." + GetSystemType()))
                {
                    MessageBox.Show("Selected Directory is not a valid Working Copy");
                    return false;
                }

                if (fileCount <= 0)
                {
                    MessageBox.Show("Invalid File Count.");
                    return false;
                }

                if (fileSize <= 0)
                {
                    MessageBox.Show("Invalid File Size.");
                    return false;
                }
                else if (fileSize > 25)
                {
                    MessageBox.Show("File to large.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return true;
        }

        private string[] VCSCommit(string dir, string command)
        {
            try
            {
                ProcessStartInfo cmdInfo = new ProcessStartInfo();

                cmdInfo.CreateNoWindow = true;
                cmdInfo.UseShellExecute = false;
                cmdInfo.FileName = GetSystemType();
                cmdInfo.Arguments = command; //command such as "commit -m"
                cmdInfo.WorkingDirectory = dir;  //repo path
                cmdInfo.RedirectStandardError = true;
                cmdInfo.RedirectStandardOutput = true;
                string[] logRaw = new string[] { };

                using (var proc = new System.Diagnostics.Process())
                {
                    proc.StartInfo = cmdInfo;
                    proc.Start();

                    var output = proc.StandardOutput.ReadToEnd();
                    var error = proc.StandardError.ReadToEnd();

                    logRaw = string.IsNullOrEmpty(output) && !string.IsNullOrEmpty(error)
                        ? error.Split('\n').ToArray()
                        : output.Split('\n').ToArray();

                    proc.WaitForExit();
                    proc.Close();
                }

                return logRaw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return null;
        }

        #region Create Methods
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            VCSCreate();
        }

        private void VCSCreate()
        {
            try
            {
                string dir = textBoxWCDir.Text;
                int fileCount = My_Parse.ParseInt32Or0( textBoxCreateFileCount.Text);
                int fileSize = My_Parse.ParseInt32Or0(textBoxCreateFileSize.Text);

                if (!ValidateVCS(dir, fileCount, fileSize))
                    return;

                List<string> log = new List<string>();

                for (int i = 0; i < fileCount; i++)
                {
                    #region Random File Generator
                    string fileName = Guid.NewGuid().ToString() + ".cmw";
                    string filePath = Path.Combine(dir, fileName);
                    byte[] data = new byte[fileSize * 1024 * 1024];
                    Random rng = new Random();
                    rng.NextBytes(data);
                    File.WriteAllBytes(filePath, data);
                    #endregion

                    string[] addLog = (VCSCommit(dir, string.Format("add {0}", fileName)));
                    if (addLog != null)
                        log.AddRange(addLog);

                    string[] commit = VCSCommit(dir, string.Format("commit -m {0}Committing File {1}{0} {1}"
                        , "\""
                        , fileName));
                    if (commit != null)
                        log.AddRange(commit);
                }

                // Push if option is checked
                if ((comboBoxSystem.SelectedIndex == 1
                    || comboBoxSystem.SelectedIndex == 2)
                    && checkBoxPushAfterCreate.Checked)
                {
                    string[] commit = VCSCommit(dir, string.Format("push"));
                    if (commit != null)
                        log.AddRange(commit);
                }

                ////MessageBox.Show(string.Join("\n", log));
                //File.AppendAllText(dir + @"\CommitLog.txt", string.Join("\n", log));
                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Update Methods
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            VCSUpdate();
        }

        private void VCSUpdate()
        {
            try
            {
                string dir = textBoxWCDir.Text;
                int fileCount = My_Parse.ParseInt32Or0(textBoxUpdateCount.Text);
                int fileSize = My_Parse.ParseInt32Or0(textBoxUpdateFileSize.Text);

                if (!ValidateVCS(dir, fileCount, fileSize))
                    return;

                #region Get list of valid Files in Working Copy
                string[] fileList = Directory.GetFiles(dir);
                List<FileInfo> files = new List<FileInfo>();
                for (int i = 0; i < fileList.Length; i++)
                {
                    FileInfo file = new FileInfo(fileList[i]);
                    if (file.Exists)
                    {
                        // Make sure the file name is a valid Guid
                        Guid? fileName = My_Parse.ParseGuidOrNull(file.Name.Replace(file.Extension, ""));
                        if (fileName.HasValue)
                            files.Add(file);
                    }
                }
                #endregion

                // Loop through valid files, override them with new data and commit to vcs
                List<string> log = new List<string>();

                for (int x = 0; x < fileCount; x++)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        #region Random File Generator
                        byte[] data = new byte[fileSize * 1024 * 1024];
                        Random rng = new Random();
                        rng.NextBytes(data);
                        File.WriteAllBytes(files[i].FullName, data);
                        #endregion

                        #region Stage modified file for git
                        if (GetSystemType() == "git")
                        {
                            string[] addLog = (VCSCommit(dir, string.Format("add {0}", files[i].FullName)));
                            if (addLog != null)
                                log.AddRange(addLog);
                        }
                        #endregion
                    }

                    string[] commit = VCSCommit(dir, string.Format("commit -m {0}Updated Files {1}{0}"
                        , "\""
                        , string.Join(", ", files.Select(j => j.Name))));
                    if (commit != null)
                        log.AddRange(commit);
                }

                // Push if option is checked
                if ((comboBoxSystem.SelectedIndex == 1
                    || comboBoxSystem.SelectedIndex == 2)
                    && checkBoxPushAfterCreate.Checked)
                {
                    string[] commit = VCSCommit(dir, string.Format("push"));
                    if (commit != null)
                        log.AddRange(commit);
                }

                ////MessageBox.Show(string.Join("\n", log));
                //File.AppendAllText(dir + @"\CommitLog.txt", string.Join("\n", log));
                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
