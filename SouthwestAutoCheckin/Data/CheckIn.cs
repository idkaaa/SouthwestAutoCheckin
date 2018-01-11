using Newtonsoft.Json;
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
    /// A single flight checkin on southwest.
    /// </summary>
    internal class CheckIn
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The path to this data on disk.
        /// </summary>
        public string p_JsonFilePath { get; set; }

        public enum TaskStatus
        {
            Error,
            Unscheduled,
            Scheduled,
            Running,
            Completed
        }

        /// <summary>
        /// Fliers first name.
        /// </summary>
        public string p_FirstName { get; set; }
        /// <summary>
        /// Fliers Last name.
        /// </summary>
        public string p_LastName { get; set; }
        /// <summary>
        /// Fliers Confirmation code.
        /// </summary>
        public string p_ConfirmationCode { get; set; }
        /// <summary>
        /// Fliers check in date.
        /// </summary>
        public DateTime p_CheckInDate { get; set; }
        /// <summary>
        /// Fliers Email address.
        /// </summary>
        public string p_EmailAddress { get; set; } = null;
        /// <summary>
        /// fliers Phone number.
        /// </summary>
        public string p_PhoneNumber { get; set; } = null;

        /// <summary>
        /// The task status.
        /// </summary>
        public TaskStatus p_TaskStatus { get; set; }

        /// <summary>
        /// Create a basic check in object.
        /// </summary>
        /// <returns></returns>
        public static CheckIn p_CreateCheckIn(
            string firstName,
            string lastName,
            string confirmationCode,
            DateTime checkInDate,
            string dataDirectory,
            string emailAddress = "",
            string phoneNumber = ""
            )
        {
            Log.Trace($"Creating check in for: {firstName} {lastName} with confirmation code: {confirmationCode} on date: {checkInDate.ToShortDateString()}");
            CheckIn C = new CheckIn();
            C.p_FirstName = firstName;
            C.p_LastName = lastName;
            C.p_ConfirmationCode = confirmationCode;
            C.p_CheckInDate = checkInDate;
            C.p_EmailAddress = emailAddress;
            C.p_PhoneNumber = phoneNumber;
            string fileName = p_GetFileName(
                firstName,
                lastName,
                checkInDate
                );
            C.p_JsonFilePath = Path.Combine(dataDirectory, fileName);
            return C;
        }

        /// <summary>
        /// Get a checkin from a data file.
        /// </summary>
        public static CheckIn p_Deserialize(string pathToJson)
        {
            Log.Trace($"Reading check in file: {pathToJson}");
            CheckIn checkIn;
            using (StreamReader file = File.OpenText(pathToJson))
            {
                JsonSerializer serializer = new JsonSerializer();
                checkIn = (CheckIn)serializer.Deserialize(file, typeof(CheckIn));
            }
            return checkIn;
        }
        
        public static string p_GetFileName(
            string firstName,
            string lastName,
            DateTime checkInDate
            )
        {
            return $"CheckIn-{lastName}_{firstName}-{p_GetDateFileNameString(checkInDate)}.JSON";
        }

        /// <summary>
        /// returns a date string that can be used for filenames in windows.
        /// </summary>
        public static string p_GetDateFileNameString(DateTime date)
        {
            return date.ToString("yyyy-MM-d");
        }

        /// <summary>
        /// Deletes the checkin from the disk.
        /// </summary>
        public void p_Delete()
        {
            Log.Trace($"Deleting file: {p_JsonFilePath}");
            if (File.Exists(p_JsonFilePath))
            {
                File.Delete(p_JsonFilePath);
            }
        }

        /// <summary>
        /// writes the json to a file.
        /// </summary>
        public void p_Serialize()
        {
            Log.Trace($"Serializing check in at: {p_JsonFilePath}");
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(p_JsonFilePath, json);
        }
    }
}
