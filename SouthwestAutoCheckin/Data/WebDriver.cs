using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium.Firefox;
using System.Windows.Forms;

namespace SouthwestAutoCheckin.Data
{
    internal class WebDriver
    {
        private static Properties.CheckIn Settings = Properties.CheckIn.Default;
        private static Logger Log = LogManager.GetCurrentClassLogger();
        private IWebDriver p_Driver { get; set; }

        public WebDriver()
        {
            string FireFoxBinaryPath = Properties.Settings.Default.FirefoxBinaryPath;
            Log.Trace($"Initializing selenium web driver for: {FireFoxBinaryPath}");
            FirefoxProfile FirefoxProfile = new FirefoxProfile();
            FirefoxBinary FirefoxPortableBinary = new FirefoxBinary(FireFoxBinaryPath);
            p_Driver = new FirefoxDriver(FirefoxPortableBinary, FirefoxProfile);
            p_Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
        
        /// <summary>
        /// closes the web browser
        /// </summary>
        public void p_CloseBrowser()
        {
            p_Driver.Quit();
        }

        /// <summary>
        /// Runs the script to test the paramaters for check-in.
        /// </summary>
        public bool p_RunTestCheckInScript(
            string firstName,
            string lastName,
            string confirmationCode
            )
        {
            Log.Trace($"Running check in test script for confirmation code: {confirmationCode}");
            if (p_Driver == null)
            {
                Log.Trace("Failed loading web driver.");
                return false;
            }

            string firstNameFieldId = Properties.Settings.Default.TestConfirmationFirstNameFieldHtmlId;
            string lastNameFieldId = Properties.Settings.Default.TestConfirmationLastNameFieldHtmlId;
            string confirmationNumberFieldId = Properties.Settings.Default.TestConfirmationNumberFieldHtmlId;
            string buttonSubmitId = Properties.Settings.Default.TestConfirmationSubmitButtonFieldHtmlId;
            string errorHtmlSelector = Properties.Settings.Default.TestConfirmationErrorHtmlSelector;
            try
            {
                // go to southwest lookup page to test credentials
                p_Driver.Navigate().GoToUrl(Properties.Settings.Default.TestConfirmationPageAddress);
                p_Driver.FindElement(By.Id(firstNameFieldId)).Click();
                p_Driver.FindElement(By.Id(firstNameFieldId)).Clear();
                p_Driver.FindElement(By.Id(firstNameFieldId)).SendKeys(firstName);
                p_Driver.FindElement(By.Id(lastNameFieldId)).Clear();
                p_Driver.FindElement(By.Id(lastNameFieldId)).SendKeys(lastName);
                p_Driver.FindElement(By.Id(confirmationNumberFieldId)).Clear();
                p_Driver.FindElement(By.Id(confirmationNumberFieldId)).SendKeys(confirmationCode);
                p_Driver.FindElement(By.Id(buttonSubmitId)).Click();
            }
            catch (Exception Ex)
            {
                Log.Error($"Failed running test check in script. Reason: {Ex.Message}");
                return false;
            }
            try
            {
                // if there was no error message on the page, this will
                // throw an exception
                p_Driver.FindElement(By.CssSelector(errorHtmlSelector));
                Log.Error($"Test failed due to displayed error on webpage.");
                return false;
            }
            catch
            {
                //yay no error
            }
            return true;
        }

        /// <summary>
        /// returns a web element by a css selector.
        /// </summary>
        private IWebElement f_GetWebElementByCssSelector(string css)
        {
            return p_Driver.FindElement(By.CssSelector(css));
        }

        /// <summary>
        /// inputs text into a field given its css selector.
        /// </summary>
        private void f_InputTextField(string css, string contentToFillIn)
        {
            IWebElement inputField = f_GetWebElementByCssSelector(css);
            inputField.Click();
            inputField.Clear();
            inputField.SendKeys(contentToFillIn);
        }

        /// <summary>
        /// Clicks a thing.
        /// </summary>
        private void f_Click(string css)
        {
            IWebElement item =
                    f_GetWebElementByCssSelector(css);
            item.Click();
        }

        /// <summary>
        /// Emails the confirmation
        /// </summary>
        private bool f_EmailConfirmation(string eMail)
        {
            Log.Trace($"Sending boarding pass to email: {eMail}");
            try
            {
                f_Click(Settings.SendToEmailButtonCss);
                f_InputTextField(Settings.EmailAddressInputCss, eMail);
                f_Click(Settings.EmailSubmitButton);
                f_Click(Settings.ChooseNextDeliveryMethodCss);
                return true;
            }
            catch (Exception Ex)
            {
                Log.Error($"Failed to set email address for confirmation. Reason: {Ex.Message}");
                f_Click(Settings.ChooseNextDeliveryMethodCss);
                return false;
            }
        }

        /// <summary>
        /// Texts to phone the confirmation
        /// </summary>
        private bool f_TextToPhoneConfirmation(string phone)
        {
            Log.Trace($"Sending boarding pass to phone: {phone}");
            try
            {
                f_Click(Settings.SendToTextPhoneButtonCss);
                f_InputTextField(Settings.TextPhoneInputCss, phone);
                f_Click(Settings.SendToTextPhoneSubmitButtonCss);
                f_Click(Settings.ChooseNextDeliveryMethodCss);
                return true;
            }
            catch (Exception Ex)
            {
                Log.Error($"Failed to set text to phone for confirmation. Reason: {Ex.Message}");
                f_Click(Settings.ChooseNextDeliveryMethodCss);
                return false;
            }
        }

        /// <summary>
        /// runs the script that tests checkin
        /// </summary>
        public bool p_RunCheckInScript(
            CheckIn checkIn
            )
        {
            Log.Trace($"Running check in script for file: {checkIn.p_JsonFilePath}");
            if (p_Driver == null)
            {
                Log.Trace("Failed loading web driver.");
                return false;
            }
            
            try
            {
                p_Driver.Navigate().GoToUrl(Settings.URL);
                f_InputTextField(
                    css: Settings.ConfirmationNumberCss,
                    contentToFillIn: checkIn.p_ConfirmationCode
                    );
                f_InputTextField(
                    css: Settings.ConfirmationFirstNameCss,
                    contentToFillIn: checkIn.p_FirstName
                    );
                f_InputTextField(
                    css: Settings.ConfirmationLastNameCss,
                    contentToFillIn: checkIn.p_LastName
                    );
                IWebElement checkInSubmitButton =
                    f_GetWebElementByCssSelector(Settings.ConfirmationSubmitButtonCss);
                checkInSubmitButton.Click();
                //CLH 2018-12-11: Southwest now requires you to click two submit
                // buttons...
                IWebElement checkInSubmitButton2 =
                    f_GetWebElementByCssSelector(Settings.ConfirmationSubmitButton2Css);
                checkInSubmitButton2.Click();
            }
            catch (Exception Ex)
            {
                string error = $"Failed running check in script. Reason: {Ex.Message}";
                Log.Error(error);
                MessageBox.Show(error, "SouthWestAutoCheckin");
                p_CloseBrowser();
                return false;
            }

            //try EITHER phone or email if one was passed in
            if (String.IsNullOrEmpty(checkIn.p_EmailAddress) == false)
            {
                f_EmailConfirmation(checkIn.p_EmailAddress);
            }
            else if(String.IsNullOrEmpty(checkIn.p_PhoneNumber) == false)
            {
                f_TextToPhoneConfirmation(checkIn.p_PhoneNumber);
            }
            MessageBox.Show("Successfully checked in.", "SouthWestAutoCheckin");
            p_CloseBrowser();
            return true;
        }
    }
}

