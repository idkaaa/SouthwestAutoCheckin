using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;
using SouthwestAutoCheckin.Data;
using System.IO;
using NLog;

namespace SouthwestAutoCheckin
{
    /// <summary>
    /// this class schedules a check in job to be run.
    /// </summary>
    internal static class Scheduler
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        public static bool p_CheckInNow(CheckIn checkin)
        {
            Log.Trace($"Checking in: {checkin.p_LastName}, {checkin.p_FirstName} - {checkin.p_ConfirmationCode}");
            WebDriver driver = new WebDriver();
            driver.p_RunCheckInScript(checkin);
            return true;
        }

        /// <summary>
        /// Schedules the checkin job
        /// </summary>
        public static bool p_CreateOrUpdateJob(string checkInJsonPath)
        {
            Log.Trace($"Creating/updating task for checkin: {checkInJsonPath}");
            CheckIn checkIn = CheckIn.p_Deserialize(checkInJsonPath);

            string[] loginCredentials = File.ReadAllLines(Path.Combine(
                Properties.Settings.Default.SouthwestCheckInBaseDirectory,
                "ScheduledTaskLogin.txt"
                ));

            ScheduledTask CreatedTask = ScheduledTask.p_CreateOrUpdate(
                ServerName: loginCredentials[0],
                TaskRootName: "SouthWestAutoCheckIn",
                TaskName: $@"Flight Check In-{Path.GetFileNameWithoutExtension(checkInJsonPath)}",
                StartDate: checkIn.p_CheckInDate,
                TaskActionPath: "SouthwestAutoCheckin.exe",
                TaskActionArguments: $@" {checkInJsonPath}",
                TaskActionWorkingDirectory: Properties.Settings.Default.SouthwestCheckInBaseDirectory,
                userId: loginCredentials[1],
                password: loginCredentials[2]
                );

            if (CreatedTask != null)
            {
                Log.Trace($"Successfully scheduled task for checkin: {checkInJsonPath}");
                checkIn.p_TaskStatus = CheckIn.TaskStatus.Scheduled;
                return true;
            }
            Log.Error($"Failed to schedule task for checkin: {checkInJsonPath}");
            checkIn.p_TaskStatus = CheckIn.TaskStatus.Error;
            return false;
        }
    }
}
