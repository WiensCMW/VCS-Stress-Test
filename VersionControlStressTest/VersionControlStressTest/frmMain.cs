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
                    textBoxSVNWC.Text = Settings.Default.Directory;

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

        private void comboBoxSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Save selected system
                Settings.Default.SelectedSystem = comboBoxSystem.SelectedIndex;
                Settings.Default.Save();

                SetFormControls();
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
                switch (comboBoxSystem.SelectedIndex)
                {
                    case 0:
                        {
                            checkBoxPushAfterCreate.Visible = false;
                            checkBoxPushAfterUpdate.Visible = false;
                            break;
                        }
                    case 1:
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
        private void buttonSVNWCBrowse_Click(object sender, EventArgs e)
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
                        if (!DirectoryIsWC(diag.SelectedPath, ".svn"))
                        {
                            MessageBox.Show("Selected directory is not part of a Working Copy."
                                , "Invalid Directory"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Warning);
                            textBoxSVNWC.Text = "";
                        }
                        else
                        {
                            textBoxSVNWC.Text = diag.SelectedPath;
                            Settings.Default.Directory = diag.SelectedPath;
                            Settings.Default.Save();
                        }
                    }
                    else
                        textBoxSVNWC.Text = "";
                }
                else
                    textBoxSVNWC.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region SVN Create Methods
        private void buttonSVNCreate_Click(object sender, EventArgs e)
        {
            VCSCreate();
        }

        private void VCSCreate()
        {
            try
            {
                // Validate
                string dir = textBoxSVNWC.Text;
                if (string.IsNullOrEmpty(dir))
                {
                    MessageBox.Show("SVN Working Copy location can't be empty.");
                    return;
                }
                else if (!Directory.Exists(dir))
                {
                    MessageBox.Show("Selected SVN Working Copy doesn't exist.");
                    return;
                }

                int fileCount = My_Parse.ParseInt32Or0(textBoxFileCount.Text);
                if (fileCount <= 0)
                {
                    MessageBox.Show("Invalid File Count.");
                    return;
                }

                int fileSize = My_Parse.ParseInt32Or0(textBoxFileSize.Text);
                if (fileSize <= 0)
                {
                    MessageBox.Show("Invalid File Size.");
                    return;
                }
                else if (fileSize > 25)
                {
                    MessageBox.Show("File to large.");
                    return;
                }

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

                ////MessageBox.Show(string.Join("\n", log));
                //File.AppendAllText(dir + @"\CommitLog.txt", string.Join("\n", log));
                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //HostGlobals.ErrorMessage(this.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex, _spm, _touchScreenMode);
            }
        } 
        #endregion

        #region SVN Update Methods
        private void buttonSVNUpdate_Click(object sender, EventArgs e)
        {
            VCSUpdate();
        }

        private void VCSUpdate()
        {
            try
            {
                #region Validate
                // Validate
                string dir = textBoxSVNWC.Text;
                if (string.IsNullOrEmpty(dir))
                {
                    MessageBox.Show("SVN Working Copy location can't be empty.");
                    return;
                }
                else if (!Directory.Exists(dir))
                {
                    MessageBox.Show("Selected SVN Working Copy doesn't exist.");
                    return;
                }

                int updateCount = My_Parse.ParseInt32Or0(textBoxUpdateCount.Text);
                if (updateCount <= 0)
                {
                    MessageBox.Show("Invalid File Count.");
                    return;
                }

                int fileSize = My_Parse.ParseInt32Or0(textBoxUpdateFileSize.Text);
                if (fileSize <= 0)
                {
                    MessageBox.Show("Invalid File Size.");
                    return;
                }
                else if (fileSize > 25)
                {
                    MessageBox.Show("File to large.");
                    return;
                }
                #endregion

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

                // Loop through valid files, override them with new data and commit to svn
                List<string> log = new List<string>();

                for (int x = 0; x < updateCount; x++)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        #region Random File Generator
                        byte[] data = new byte[fileSize * 1024 * 1024];
                        Random rng = new Random();
                        rng.NextBytes(data);
                        File.WriteAllBytes(files[i].FullName, data);
                        #endregion
                    }

                    string[] commit = VCSCommit(dir, string.Format("commit -m {0}Updated Files {1}{0}"
                        , "\""
                        , string.Join(", ", files.Select(j => j.Name))));
                    if (commit != null)
                        log.AddRange(commit);
                }

                ////MessageBox.Show(string.Join("\n", log));
                //File.AppendAllText(dir + @"\CommitLog.txt", string.Join("\n", log));
                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //HostGlobals.ErrorMessage(this.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex, _spm, _touchScreenMode);
            }
        }
        #endregion

        private string[] VCSCommit(string dir, string svnCommand)
        {
            try
            {
                ProcessStartInfo cmdInfo = new ProcessStartInfo();
                Process gitProcess = new Process();

                cmdInfo.CreateNoWindow = true;
                cmdInfo.UseShellExecute = false;
                cmdInfo.FileName = @"svn";
                cmdInfo.Arguments = svnCommand; //command such as "commit -m"
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
                MessageBox.Show(ex.ToString(), "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return null;
        }
        #endregion

        #region HG Methods
        //private void buttonHGWCBrowse_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        FolderBrowserDialog diag = new FolderBrowserDialog();
        //        DialogResult results = diag.ShowDialog(this);
        //        if (results == DialogResult.OK)
        //        {
        //            if (!string.IsNullOrEmpty(diag.SelectedPath)
        //                && Directory.Exists(diag.SelectedPath))
        //            {
        //                textBoxHGWC.Text = diag.SelectedPath;
        //            }
        //            else
        //                textBoxHGWC.Text = "";
        //        }
        //        else
        //            textBoxHGWC.Text = "";

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //#region HG Create Methods
        //private void buttonHGCreate_Click(object sender, EventArgs e)
        //{
        //    HGCreate();
        //}

        //private void HGCreate()
        //{
        //    try
        //    {
        //        // Validate
        //        string dir = textBoxHGWC.Text;
        //        if (string.IsNullOrEmpty(dir))
        //        {
        //            MessageBox.Show("HG Working Copy location can't be empty.");
        //            return;
        //        }
        //        else if (!Directory.Exists(dir))
        //        {
        //            MessageBox.Show("Selected HG Working Copy doesn't exist.");
        //            return;
        //        }

        //        int fileCount = My_Parse.ParseInt32Or0(textBoxHGFileCount.Text);
        //        if (fileCount <= 0)
        //        {
        //            MessageBox.Show("Invalid File Count.");
        //            return;
        //        }

        //        int fileSize = My_Parse.ParseInt32Or0(textBoxHGFileSize.Text);
        //        if (fileSize <= 0)
        //        {
        //            MessageBox.Show("Invalid File Size.");
        //            return;
        //        }
        //        else if (fileSize > 25)
        //        {
        //            MessageBox.Show("File to large.");
        //            return;
        //        }

        //        List<string> log = new List<string>();

        //        for (int i = 0; i < fileCount; i++)
        //        {
        //            #region Random File Generator
        //            string fileName = Guid.NewGuid().ToString() + ".cmw";
        //            string filePath = Path.Combine(dir, fileName);
        //            byte[] data = new byte[fileSize * 1024 * 1024];
        //            Random rng = new Random();
        //            rng.NextBytes(data);
        //            File.WriteAllBytes(filePath, data);
        //            #endregion 

        //            string[] addLog = (HGCommit(dir, string.Format("add {0}", fileName)));
        //            if (addLog != null)
        //                log.AddRange(addLog);

        //            string[] commit = HGCommit(dir, string.Format("commit -m {0}Committing File {1}{0} {1}"
        //                , "\""
        //                , fileName));
        //            if (commit != null)
        //                log.AddRange(commit);
        //        }

        //        if (checkBoxHGPushAfterCreate.Checked)
        //        {
        //            string[] commit = HGCommit(dir, string.Format("push"));
        //            if (commit != null)
        //                log.AddRange(commit);
        //        }

        //        MessageBox.Show("Done!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        //#endregion

        //#region HG Update Methods
        //private void buttonHGUpdate_Click(object sender, EventArgs e)
        //{
        //    HGUpdate();
        //}

        //private void HGUpdate()
        //{
        //    try
        //    {
        //        #region Validate
        //        // Validate
        //        string dir = textBoxHGWC.Text;
        //        if (string.IsNullOrEmpty(dir))
        //        {
        //            MessageBox.Show("HG Working Copy location can't be empty.");
        //            return;
        //        }
        //        else if (!Directory.Exists(dir))
        //        {
        //            MessageBox.Show("Selected HG Working Copy doesn't exist.");
        //            return;
        //        }

        //        int updateCount = My_Parse.ParseInt32Or0(textBoxHGUpdateCount.Text);
        //        if (updateCount <= 0)
        //        {
        //            MessageBox.Show("Invalid File Count.");
        //            return;
        //        }

        //        int fileSize = My_Parse.ParseInt32Or0(textBoxHGUpdateFileSize.Text);
        //        if (fileSize <= 0)
        //        {
        //            MessageBox.Show("Invalid File Size.");
        //            return;
        //        }
        //        else if (fileSize > 25)
        //        {
        //            MessageBox.Show("File to large.");
        //            return;
        //        }
        //        #endregion

        //        #region Get list of valid Files in Working Copy
        //        string[] fileList = Directory.GetFiles(dir);
        //        List<FileInfo> files = new List<FileInfo>();
        //        for (int i = 0; i < fileList.Length; i++)
        //        {
        //            FileInfo file = new FileInfo(fileList[i]);
        //            if (file.Exists)
        //            {
        //                // Make sure the file name is a valid Guid
        //                Guid? fileName = My_Parse.ParseGuidOrNull(file.Name.Replace(file.Extension, ""));
        //                if (fileName.HasValue)
        //                    files.Add(file);
        //            }
        //        }
        //        #endregion

        //        // Loop through valid files, override them with new data and commit to svn
        //        List<string> log = new List<string>();

        //        for (int x = 0; x < updateCount; x++)
        //        {
        //            for (int i = 0; i < files.Count; i++)
        //            {
        //                #region Random File Generator
        //                byte[] data = new byte[fileSize * 1024 * 1024];
        //                Random rng = new Random();
        //                rng.NextBytes(data);
        //                File.WriteAllBytes(files[i].FullName, data);
        //                #endregion
        //            }

        //            string[] commit = HGCommit(dir, string.Format("commit -m {0}Updated Files {1}{0}"
        //                , "\""
        //                , string.Join(", ", files.Select(j => j.Name))));
        //            if (commit != null)
        //                log.AddRange(commit);
        //        }

        //        if (checkBoxHGPushAfterUpdate.Checked)
        //        {
        //            string[] commit = HGCommit(dir, string.Format("push"));
        //            if (commit != null)
        //                log.AddRange(commit);
        //        }

        //        MessageBox.Show("Done!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        //#endregion

        //private string[] HGCommit(string dir, string hgCommand)
        //{
        //    try
        //    {
        //        ProcessStartInfo cmdInfo = new ProcessStartInfo();
        //        Process gitProcess = new Process();

        //        cmdInfo.CreateNoWindow = true;
        //        cmdInfo.UseShellExecute = false;
        //        cmdInfo.FileName = @"hg";
        //        cmdInfo.Arguments = hgCommand; //command such as "commit -m"
        //        cmdInfo.WorkingDirectory = dir;  //repo path
        //        cmdInfo.RedirectStandardError = true;
        //        cmdInfo.RedirectStandardOutput = true;
        //        string[] logRaw = new string[] { };

        //        using (var proc = new System.Diagnostics.Process())
        //        {
        //            proc.StartInfo = cmdInfo;
        //            proc.Start();

        //            var output = proc.StandardOutput.ReadToEnd();
        //            var error = proc.StandardError.ReadToEnd();

        //            logRaw = string.IsNullOrEmpty(output) && !string.IsNullOrEmpty(error)
        //                ? error.Split('\n').ToArray()
        //                : output.Split('\n').ToArray();

        //            proc.WaitForExit();
        //            proc.Close();
        //        }

        //        return logRaw;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }

        //    return null;
        //}
        #endregion

        #region Worker Methods
        private bool TestWorker()
        {
            try
            {
                // create args for Worker
                int runTime = 3;

                object[] args = new object[] { "RunTime=" + runTime
                    , "TaskName=TestingWorker" };

                // Worker was busy, so newly selected row to work queue
                if (!StartWorkerLoadTaskSubData(args))
                    _mth.WorkQueue.AddWorkQueue("TestingWorker", args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        private bool StartWorkerLoadTaskSubData(object[] workerArgs)
        {
            try
            {
                if (_workerTest.IsIdle)
                {
                    _workerTest.RunWorkerAsync(workerArgs);
                    //button1.Enabled = false;
                    //SetCancelButton();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void _workerTest_DoWork(object sender, DoWorkEventArgs e)
        {
            MyWorker worker = sender as MyWorker;
            try
            {
                #region Capture and Validate passed in Arguments
                object[] args = e.Argument as object[];

                // Validate against null args
                if (args == null)
                    throw new Exception("Worker's args can't be null.");

                int runTime = 0;

                // Collect passed in worker arguments
                for (int i = 0; i < args.Length; i++)
                {
                    if (args == null)
                        continue;

                    if (args[i] is string)
                    {
                        if (args[i].ToString().Contains("RunTime="))
                            runTime = My_Parse.ParseInt32Or0(args[i].ToString().Replace("RunTime=", ""));
                    }
                }

                // Validate collected arguments, cancel worker if validation fails
                if (runTime <= 0)
                {
                    worker.CancelAsync(); // not sure if this is correct
                    return;
                }

                if (worker.CancellationPending)
                    return;
                #endregion

                #region Do Work!
                worker.ReportProgress(0, string.Format("Testing Worker", runTime));
                for (int i = 0; i < ((runTime * 1000) / 50); i++)
                {
                    if (worker.CancellationPending)
                        return;
                    worker.ReportProgress(0, string.Format("Testing Worker {0}", Guid.NewGuid()));
                    Thread.Sleep(50);
                }
                #endregion

                #region Create Worker Results and pass them out of the Worker
                object[] results = new object[]
                {
                    "Worker Finished!"
                };
                e.Result = results;
                #endregion
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
            finally
            {
                // Mark worker as Cancelled if Cancellation was requested
                if (worker.CancellationPending)
                    e.Cancel = true;

                // Signal that worker is complete
                worker.Reset.Set();
            }
        }

        private void _workerTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MyWorker worker = sender as MyWorker;
            try
            {
                // Show Progress label and report worker's progress
                //label1.Visible = true;
                //label1.Text = (string)e.UserState;
            }
            catch (Exception ex)
            {
                worker.CancelAsync();
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _workerTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                // Hide Progress label
                //label1.Visible = false;

                // Evaluate worker's Result
                if (e.Cancelled)
                {
                    // Worker was Cancelled
                    //label1.Visible = true;
                    //label1.Text = "Worker Cancelled!!!";
                }
                else if (e.Result is Exception)
                {
                    throw new Exception((e.Result as Exception).ToString());
                }
                else
                {
                    // Worker Completed

                    #region Collect and Validate Worker Results
                    object[] results = e.Result as object[];

                    string workerMessage = "";

                    // Validate against null results
                    if (results == null)
                        throw new Exception("Worker's results can't be null.");

                    // Collect worker results into local variables
                    for (int i = 0; i < results.Length; i++)
                    {
                        if (results == null)
                            continue;

                        if (results[i] is string)
                        {
                            workerMessage = (string)results[i];
                        }
                    }

                    //label1.Visible = true;
                    //label1.Text = workerMessage;
                    #endregion

                    #region Check for and execute queued up work
                    if (_mth.WorkQueue.WorkerHasWorkQueued("TestingWorker"))
                        StartWorkerLoadTaskSubData(_mth.WorkQueue.GetQueuedWorkerArgs("TestingWorker"));
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //SetCancelButton();
                //button1.Enabled = true;
            }
        }
        #endregion

        #region Error Handling code sample for the entire Application
        //public static void ErrorMessage(string form
        //    , string method
        //    , Exception ex
        //    , SplashScreenManager spm
        //    , bool touchScreenMode)
        //{
        //    touchScreenMode = true;
        //    if (touchScreenMode)
        //    {
        //        //DXMessage(string.Format("An Error has occurred in..."
        //        //    + "\n" + "Class: {0}"
        //        //    + "\n" + "Method: {1}"
        //        //    + "\n" + "\n" + "{2}", form, method, (DebugMode) ? ex.ToString() : ex.Message.ToString())
        //        //    , "VidirHome Error"
        //        //    , MessageBoxIcon.Error
        //        //    , spm);

        //        frm_Host_Touchscreen_Dialog touchDialog = new frm_Host_Touchscreen_Dialog(
        //            string.Format("An Error has occurred in..."
        //            + "\n" + "Class: {0}"
        //            + "\n" + "Method: {1}"
        //            + "\n" + "\n" + "{2}", form, method, (DevMode) ? ex.ToString() : ex.Message.ToString())
        //            , "VidirHome Error"
        //            , MessageBoxButtons.OK
        //            , MessageBoxIcon.Error
        //            , spm);
        //        touchDialog.ShowDialog();
        //    }
        //    else
        //    {
        //        DXMessage(string.Format("An Error has occurred in..."
        //            + "\n" + "Class: {0}"
        //            + "\n" + "Method: {1}"
        //            + "\n" + "\n" + "{2}", form, method, (DevMode) ? ex.ToString() : ex.Message.ToString())
        //            , "VidirHome Error"
        //            , MessageBoxIcon.Error
        //            , spm);
        //    }

        //    LogError(form, method, ex);
        //}
        #endregion
    }
}
