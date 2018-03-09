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

namespace VersionControlStressTest
{
    public partial class frmMain : Form
    {
        private MyThreadHelper _mth = new MyThreadHelper();
        private MyWorker _workerTest;

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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            string dir = @"C:\Users\cornie\Downloads\test\trunk";
            int fileCount = 10;
            try
            {
                List<string> log = new List<string>();

                for (int i = 0; i < fileCount; i++)
                {
                    #region Random File Generator
                    string fileName = Guid.NewGuid().ToString() + ".cmw";
                    string filePath = Path.Combine(dir, fileName);
                    int sizeInMb = 10;
                    byte[] data = new byte[sizeInMb * 1024 * 1024];
                    Random rng = new Random();
                    rng.NextBytes(data);
                    File.WriteAllBytes(filePath, data);
                    #endregion 

                    string[] addLog = (SVNCommitTest(dir, string.Format("add {0}", fileName)));
                    if (addLog != null)
                        log.AddRange(addLog);

                    string[] commit = SVNCommitTest(dir, string.Format("commit -m {0}Committing File {1}{0} {1}"
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

        private string[] SVNCommitTest(string dir, string svnCommand)
        {
            try
            {
                //Directory.SetCurrentDirectory(dir);
                //string svnCommitArg = "commit -m \"Commiting from shell\"";

                ProcessStartInfo gitInfo = new ProcessStartInfo();
                Process gitProcess = new Process();

                gitInfo.CreateNoWindow = true;
                gitInfo.UseShellExecute = false;
                gitInfo.FileName = @"svn";
                gitInfo.Arguments = svnCommand; //command such as "commit -m"
                gitInfo.WorkingDirectory = dir;  //repo path
                gitInfo.RedirectStandardError = true;
                gitInfo.RedirectStandardOutput = true;
                string[] logRaw = new string[] { };

                using (var proc = new System.Diagnostics.Process())
                {
                    proc.StartInfo = gitInfo;
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

        #region Error Handling for the entire Application
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
