using NLog;
using SouthwestAutoCheckin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouthwestAutoCheckin
{
    static class Program
    {
        ///// <summary>
        ///// The main entry point for the application.
        ///// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new AutoCheckinForm());
        //}

        private static Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The current checkin.
        /// </summary>
        private static CheckIn p_CheckIn { get; set; }

        /// <summary>
        /// the web browser driver.
        /// </summary>
        private static WebDriver p_WebDriver { get; set; }
        public static void print(IEnumerable<string> x)
        {
            foreach (string s in x)
            {
                Log.Trace(s);
            }
        }

        [STAThread]
        static int Main(string[] args)
        {
            string[] x = new string[] { "a", "c", "b" };
            IEnumerable<string> y = x;
            Log.Trace("Unsorted IEnumerable");
            print(y);
            Log.Trace("Sorted IEnumerable");
            print(y.OrderBy(r => r));
        
        bool hasArguments = args.Length != 0;
            if (hasArguments == false)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AutoCheckinForm());
                return 0;
            }
            try
            {
                string checkInJsonPath = args[0];
                p_CheckIn = CheckIn.p_Deserialize(checkInJsonPath);
            }
            catch (Exception Ex)
            {
                Log.Error($"Failed to read in JSON file path from arguments. Reason: {Ex.Message}");
                Environment.Exit(-1);
            }

            p_WebDriver = new WebDriver();
            bool success = p_WebDriver.p_RunCheckInScript(p_CheckIn);


            if (success == true)
            {
                Log.Trace($"Successfully checked in: {p_CheckIn.p_JsonFilePath}");
                p_CheckIn.p_TaskStatus = CheckIn.TaskStatus.Completed;
                p_CheckIn.p_Serialize();
                MessageBox.Show($"Successfully checked in: {p_CheckIn.p_JsonFilePath}");
                return 0;
            }
            Log.Error($"Failed to check in: {p_CheckIn.p_JsonFilePath}");
            p_CheckIn.p_TaskStatus = CheckIn.TaskStatus.Error;
            p_CheckIn.p_Serialize();
            MessageBox.Show($"Failed to Check in: {p_CheckIn.p_JsonFilePath}");
            return 1;
        }
    }
}
