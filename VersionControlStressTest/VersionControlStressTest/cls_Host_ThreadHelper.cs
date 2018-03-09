using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace VersionControlStressTest
{
    #region Prevent Visual Studio from thinking that this class can be Designed.
    /* Without this, Visual Studio thinks this class can be designed after MyWorker
     * inherited the BackgroundWorker class.
     */
    [System.ComponentModel.DesignerCategory("")]
    #endregion

    public class MyThreadHelper
    {
        public List<MyWorker> WorkerList = new List<MyWorker>();
        public MyWorkQueue WorkQueue = new MyWorkQueue();

        public ConcurrentDictionary<Guid, MyThreadTask> ThreadTaskList = new ConcurrentDictionary<Guid, MyThreadTask>();

        public MyThreadHelper()
        {

        }
    }

    public class MyWorker : BackgroundWorker
    {
        public System.Threading.AutoResetEvent Reset = new System.Threading.AutoResetEvent(false);
        /// <summary>
        /// Worker is NOT Busy and does NOT have CancellationPending so it's safe to start the worker
        /// </summary>
        public Boolean IsIdle
        {
            get 
            {
                if (!IsBusy && !CancellationPending)
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// Worker IS Busy and has NOT been told to cancel itself.
        /// </summary>
        public Boolean IsRunning
        {
            get
            {
                if (IsBusy && !CancellationPending)
                    return true;
                else
                    return false;
            }
        }

        public MyWorker() { }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            #region Name the thread NOTE: A thread can only be named once
            //if (System.Threading.Thread.CurrentThread.Name == null) // Can only set it once
            //    System.Threading.Thread.CurrentThread.Name = Name; 
            #endregion

            base.OnDoWork(e);
        }
    }

    public class MyWorkQueue
    {
        private List<WorkQueue> WorkQueue = new List<WorkQueue>();

        public MyWorkQueue() { }

        public void AddWorkQueue(string workName
            , object[] workerInputArgs)
        {
            // Remove any existing Work Queues for the passed in Work Name
            if (WorkQueue.Any(x => x.WorkName == workName))
                RemoveWorkQueue(workName);

            // Create new Work Queue
            WorkQueue.Add(new WorkQueue(workName, workerInputArgs));
        }

        public void RemoveWorkQueue(string workName)
        {
            if (WorkQueue.Any(x => x.WorkName == workName))
                WorkQueue.RemoveAll(x => x.WorkName == workName);
        }

        public bool WorkerHasWorkQueued(string workName)
        {
            return WorkQueue.Any(x => x.WorkName == workName);
        }

        public object[] GetQueuedWorkerArgs(string workName)
        {
            object[] results = null;

            if (WorkQueue.Any(x => x.WorkName == workName))
            {
                results = WorkQueue.FirstOrDefault(x => x.WorkName == workName).WorkerInputArgs;
                RemoveWorkQueue(workName);
            }

            return results;
        }
    }
    
    public class WorkQueue
    {
        public String WorkName;
        public Object[] WorkerInputArgs;

        public WorkQueue(string workName
            , object[] workerInputArgs)
        {
            this.WorkName = workName;
            this.WorkerInputArgs = workerInputArgs;
        }
    }

    public class MyThreadTask
    {
        public Guid ID;
        public String Name;
        public Object Results;
        public Boolean Complete = false;
        public Boolean CancelTask = false;
        public System.Threading.AutoResetEvent Reset = new AutoResetEvent(false);

        public MyThreadTask(Guid id
            ,String description)
        {
            this.ID = id;
            this.Name = description;
        }
    }

    public class MyTimer : System.Windows.Forms.Timer
    {
        public MyTimer(int interval)
        {
            if (interval <= 0)
                throw new Exception("Timer Inverval can't be below 0");

            this.Interval = interval;
        }

        protected override void OnTick(EventArgs e)
        {
            base.OnTick(e);
        }
    }
}