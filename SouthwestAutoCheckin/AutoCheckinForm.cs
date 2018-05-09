using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SouthwestAutoCheckin.Data;

using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using NLog;
using System.IO;

namespace SouthwestAutoCheckin
{
    internal partial class AutoCheckinForm : Form
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The checkin data.
        /// </summary>
        private SouthwestAutoCheckin.Data.CheckIn p_CheckIn { get; set; }

        /// <summary>
        /// The scheduled task associated with the checkin.
        /// </summary>
        private SouthwestAutoCheckin.Data.ScheduledTask p_ScheduledTask { get; set; }

        /// <summary>
        /// The time until the next attempt to check in.
        /// </summary>
        private TimeSpan p_TimeUntilNextCheckInAttempt { get; set; }

        /// <summary>
        /// the web page driver.
        /// </summary>
        private WebDriver p_Driver { get; set; }


        public AutoCheckinForm()
        {
            InitializeComponent();
            c_LabelFlightTime.Text += $@"({TimeZone.CurrentTimeZone.StandardName}):";
            c_DateTimePickerFlightTime.Format = DateTimePickerFormat.Time;
            c_DateTimePickerFlightDate.ShowUpDown = true;
            c_DateTimePickerFlightDate.Value = DateTime.Today;
            c_DateTimePickerFlightTime.Value = DateTime.Today;
            //f_GenerateFakeTestCheckin();
        }

        /// <summary>
        /// Populate the form with data from check in.
        /// </summary>
        private void f_LoadCheckInToForm()
        {
            Log.Trace("Loading check in variables into form fields.");
            c_TextBoxConfirmationNumber.Text = p_CheckIn.p_ConfirmationCode;
            c_TextBoxFirstName.Text = p_CheckIn.p_FirstName;
            c_TextBoxLastName.Text = p_CheckIn.p_LastName;
            c_DateTimePickerFlightDate.Value = p_CheckIn.p_CheckInDate.Date;
            c_DateTimePickerFlightTime.Value = p_CheckIn.p_CheckInDate;
            c_TextBoxEmail.Text = p_CheckIn.p_EmailAddress;
            c_TextBoxPhoneNumber.Text = p_CheckIn.p_PhoneNumber;
        }

        /// <summary>
        /// Creates a fake checkin data json file.
        /// </summary>
        private void f_GenerateFakeTestCheckin()
        {
            string testDataFilePath = Properties.Settings.Default.TestDataFilePath;
            Log.Trace($"Generating test data from file: {testDataFilePath}");
            
            DateTime checkinDate = DateTime.Now.AddDays(1);
            string[] testData = File.ReadAllLines(testDataFilePath);
            
            p_CheckIn = CheckIn.p_CreateCheckIn(
                firstName: testData[0],
                lastName: testData[1],
                confirmationCode: testData[2],
                checkInDate: checkinDate,
                dataDirectory: Properties.Settings.Default.ScheduledCheckInJsonDirectory,
                emailAddress: "",
                phoneNumber: ""
                );
            f_LoadCheckInToForm();
        }

        /// <summary>
        /// Tests the credentials to make sure the credentials will work at 
        /// check in time.
        /// </summary>
        private void Handle_ButtonTest_Click(object sender, EventArgs e)
        {
            p_Driver = new WebDriver();
            bool success = p_Driver.p_RunTestCheckInScript(
                firstName: c_TextBoxFirstName.Text,
                lastName: c_TextBoxLastName.Text,
                confirmationCode: c_TextBoxConfirmationNumber.Text
                );
            c_LabelTestResults.Visible = true;
            if (success == true)
            {
                c_ButtonTest.Enabled = false;
                c_ButtonOK.Enabled = true;
                c_LabelTestResults.Text = "Success: Credential check passed.";
                c_LabelTestResults.ForeColor = Color.Green;
                //lock the required parameters
                c_TextBoxConfirmationNumber.Enabled = false;
                c_TextBoxFirstName.Enabled = false;
                c_TextBoxLastName.Enabled = false;
                //enable optional parameters
                c_TextBoxEmail.Enabled = true;
                c_DateTimePickerFlightDate.Enabled = true;
                c_DateTimePickerFlightTime.Enabled = true;
                return;
            }
            c_LabelTestResults.Text = "Error: Credential check failed.";
            c_LabelTestResults.ForeColor = Color.Red;
        }

        /// <summary>
        /// Minimizes the program.
        /// </summary>
        private void Handle_ButtonOK_Click(object sender, EventArgs e)
        {
            c_ButtonOK.Enabled = false;
            c_DateTimePickerFlightDate.Enabled = false;
            c_DateTimePickerFlightTime.Enabled = false;

            DateTime checkInDate = c_DateTimePickerFlightDate.Value.Date;
            checkInDate += c_DateTimePickerFlightTime.Value.TimeOfDay;
            checkInDate = checkInDate.AddDays(1); //check in 24 hours before flight.

            //Create scheduled task and finished adding checkin info
            p_CheckIn = CheckIn.p_CreateCheckIn(
                firstName: c_TextBoxFirstName.Text,
                lastName: c_TextBoxLastName.Text,
                confirmationCode: c_TextBoxConfirmationNumber.Text,
                checkInDate: checkInDate,
                dataDirectory: Properties.Settings.Default.ScheduledCheckInJsonDirectory,
                emailAddress: c_TextBoxEmail.Text,
                phoneNumber: c_TextBoxPhoneNumber.Text
                );

            p_CheckIn.p_Serialize();
            f_ScheduleCheckInTask();
            p_Driver.p_CloseBrowser();
        }        

        /// <summary>
        /// Schedules the check in task to run on a server.
        /// </summary>
        private void f_ScheduleCheckInTask()
        {
            //bool success = Scheduler.p_CreateOrUpdateJob(p_CheckIn.p_JsonFilePath);
            bool success = true;
            if (success == true)
            {
                c_TimerCountDown.Start();
                c_LabelTimeLeft.Visible = true;
            }
            else
            {
                MessageBox.Show(
                    "There was an error scheduling the task. Contact support.",
                    "Scheduler Error",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                    );
            }
        }

        /// <summary>
        /// Countdown timer tick.
        /// </summary>
        private void Handle_TimerCountDown_Tick(object sender, EventArgs e)
        {
            p_TimeUntilNextCheckInAttempt = p_CheckIn.p_CheckInDate - DateTime.Now;
            TimeSpan interval = TimeSpan.FromSeconds(30);
            
            if (p_TimeUntilNextCheckInAttempt > TimeSpan.Zero)
            {
                // Display the new time left
                // by updating the Time Left label.
                f_UpdateTimeLeftLabel();
                return;
            }
            Log.Trace("Stopping countdown.");
            c_TimerCountDown.Stop();
            c_TimerCheckinRetryInterval.Start();
        }

        /// <summary>
        /// close everything out.
        /// </summary>
        private void Handle_ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void c_LabelCheckInDate_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the label that shows how much time is left until the next 
        /// check in.
        /// </summary>
        private void f_UpdateTimeLeftLabel()
        {
            c_LabelTimeLeft.Text 
                = $"Time until check-in attempt: {p_TimeUntilNextCheckInAttempt.Days} Days, {p_TimeUntilNextCheckInAttempt.Hours} Hours, {p_TimeUntilNextCheckInAttempt.Minutes} Minutes, and {p_TimeUntilNextCheckInAttempt.Seconds} Seconds.";
        }

        private void c_TimerCheckinRetryInterval_Tick(object sender, EventArgs e)
        {
            DateTime maxDate = p_CheckIn.p_CheckInDate.AddMinutes(1);
            if (DateTime.Now > maxDate)
            {
                Log.Trace("Done trying to check in.");
                c_TimerCheckinRetryInterval.Stop();
            }
            Log.Trace("Attempting to check in.");
            Scheduler.p_CheckInNow(p_CheckIn);
        }
    }
}
