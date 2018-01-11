using Microsoft.Win32.TaskScheduler;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthwestAutoCheckin.Data
{
    /// <summary>
    /// This is the windows scheduled task class.
    /// </summary>
    internal class ScheduledTask
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The start datetime of the task.
        /// </summary>
        public DateTime p_StartDate { get; private set; }

        /// <summary>
        /// the full scheduled task path of the task.
        /// </summary>
        public string p_TaskPath { get; private set; }

        /// <summary>
        /// the server that the task is registered to run on
        /// </summary>
        public string p_ServerName { get; private set; }

        /// <summary>
        /// The root name that the tasks are stored under on the task subsystem.
        /// </summary>
        public string p_TaskRoot { get; private set; }


        /// <summary>
        /// Returns a list of all of the scheduled tasks registered.
        /// </summary>
        public static ScheduledTask[] p_GetScheduledTaskList(string ServerName, string TaskRoot)
        {
            //todo
            return new ScheduledTask[0];
        }

        /// <summary>
        /// Creates the scheduled task.
        /// </summary>
        public static ScheduledTask p_CreateOrUpdate(
            string ServerName,
            string TaskRootName,
            string TaskName,
            DateTime StartDate,
            string TaskActionPath,
            string TaskActionArguments,
            string TaskActionWorkingDirectory,
            string userId,
            string password
            )
        {
            Log.Trace($"Creating/Updating new task.");
            ScheduledTask MyTask = new ScheduledTask();
            MyTask.p_ServerName = ServerName;
            MyTask.p_TaskRoot = TaskRootName;
            MyTask.p_StartDate = StartDate;
            MyTask.p_TaskPath = Path.Combine(TaskRootName, TaskName);


            ExecAction TaskExecAction = new ExecAction();
            TaskExecAction.Path = TaskActionPath;
            TaskExecAction.Arguments = TaskActionArguments;
            TaskExecAction.WorkingDirectory = TaskActionWorkingDirectory;

            // Get the service on the remote machine
            using (TaskService TS = new TaskService($@"\\{MyTask.p_ServerName}"))
            {
                //Microsoft.Win32.TaskScheduler.Task Task = TS.GetTask(MyTask.p_TaskPath);
                TaskDefinition TD = null;
                
                //create new
                //if (Task == null)
                //{
                    // Create a new task definition and assign properties
                    TD = TS.NewTask();
                    // TaskLogonType.S4U = run wether user is logged on or not 
                    //TD.Principal.LogonType = TaskLogonType.S4U;
                    TD.RegistrationInfo.Description = MyTask.p_TaskPath;
                    TD.Triggers.Add(new TimeTrigger(MyTask.p_StartDate));
                    TD.Actions.Add(TaskExecAction);
                    // Register the task in the checkin folder
                    TS.RootFolder.RegisterTaskDefinition(
                        MyTask.p_TaskPath, 
                        TD, 
                        TaskCreation.CreateOrUpdate,
                        userId,
                        password,
                        TaskLogonType.S4U
                        );
                //}
                //else //update
                //{
                //    TD = Task.Definition;
                //    TD.Triggers[0] = new TimeTrigger(MyTask.p_StartDate);
                //    TD.Actions[0] = TaskExecAction;
                //    Task.RegisterChanges();
                //}
                return MyTask;
            }
        }

        /// <summary>
        /// Cleans up any tasks that have expired.
        /// </summary>
        public static void p_CleanUpOldTasks(string ServerName, string TaskRootName)
        {
            Log.Trace($"Cleaning up old tasks on server: {ServerName} with foldername: {TaskRootName}");
            // Get the service on the remote machine
            using (TaskService TS = new TaskService($@"\\{ServerName}"))
            {
                Microsoft.Win32.TaskScheduler.TaskCollection TaskList = TS.RootFolder.SubFolders[TaskRootName].Tasks;
                foreach (Microsoft.Win32.TaskScheduler.Task Task in TaskList)
                {
                    if (Task.NextRunTime < DateTime.Now)
                    {
                        TS.RootFolder.DeleteTask(Task.Name);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves a scheduled task from the server.
        /// </summary>
        public static ScheduledTask p_GetTask(string ServerName, string TaskPath)
        {
            Log.Trace($"Returning task with servername: {ServerName} and path: {TaskPath}");
            ScheduledTask MyTask = new ScheduledTask();
            // Get the service on the remote machine
            using (TaskService TS = new TaskService($@"\\{ServerName}"))
            {
                Microsoft.Win32.TaskScheduler.Task Task = TS.GetTask(TaskPath);
                if (Task != null)
                {
                    MyTask.p_ServerName = ServerName;
                    MyTask.p_TaskPath = TaskPath;
                    MyTask.p_StartDate = Task.Definition.Triggers[0].StartBoundary;
                    MyTask.p_TaskRoot = Task.Folder.Name;
                }
            }
            return MyTask;
        }

        /// <summary>
        /// Deletes the task.
        /// </summary>
        public void p_Delete()
        {
            Log.Trace($"Deleting task with path: {p_TaskPath}");
            ScheduledTask MyTask = new ScheduledTask();
            // Get the service on the remote machine
            using (TaskService TS = new TaskService($@"\\{p_ServerName}"))
            {
                Microsoft.Win32.TaskScheduler.Task Task = TS.GetTask(p_TaskPath);
                if (Task != null)
                {
                    TS.RootFolder.DeleteTask(Task.Name);
                }
            }
        }
    }
}
