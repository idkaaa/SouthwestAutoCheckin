namespace SouthwestAutoCheckin
{
    partial class AutoCheckinForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.c_TextBoxConfirmationNumber = new System.Windows.Forms.TextBox();
            this.c_LabelConfirmationNumber = new System.Windows.Forms.Label();
            this.c_LabelFirstName = new System.Windows.Forms.Label();
            this.c_TextBoxFirstName = new System.Windows.Forms.TextBox();
            this.c_LabelLastName = new System.Windows.Forms.Label();
            this.c_TextBoxLastName = new System.Windows.Forms.TextBox();
            this.c_ButtonTest = new System.Windows.Forms.Button();
            this.c_ButtonOK = new System.Windows.Forms.Button();
            this.c_ButtonCancel = new System.Windows.Forms.Button();
            this.c_LabelEmail = new System.Windows.Forms.Label();
            this.c_TextBoxEmail = new System.Windows.Forms.TextBox();
            this.c_LabelTestResults = new System.Windows.Forms.Label();
            this.c_LabelFlightDate = new System.Windows.Forms.Label();
            this.c_DateTimePickerFlightDate = new System.Windows.Forms.DateTimePicker();
            this.c_TimerCountDown = new System.Windows.Forms.Timer(this.components);
            this.c_LabelTimeLeft = new System.Windows.Forms.Label();
            this.c_LabelPhoneNumber = new System.Windows.Forms.Label();
            this.c_TextBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.c_TimerCheckinRetryInterval = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // c_TextBoxConfirmationNumber
            // 
            this.c_TextBoxConfirmationNumber.Location = new System.Drawing.Point(15, 128);
            this.c_TextBoxConfirmationNumber.MaxLength = 25;
            this.c_TextBoxConfirmationNumber.Name = "c_TextBoxConfirmationNumber";
            this.c_TextBoxConfirmationNumber.Size = new System.Drawing.Size(297, 22);
            this.c_TextBoxConfirmationNumber.TabIndex = 3;
            // 
            // c_LabelConfirmationNumber
            // 
            this.c_LabelConfirmationNumber.AutoSize = true;
            this.c_LabelConfirmationNumber.Location = new System.Drawing.Point(12, 109);
            this.c_LabelConfirmationNumber.Name = "c_LabelConfirmationNumber";
            this.c_LabelConfirmationNumber.Size = new System.Drawing.Size(136, 16);
            this.c_LabelConfirmationNumber.TabIndex = 3;
            this.c_LabelConfirmationNumber.Text = "Confirmation Number:";
            // 
            // c_LabelFirstName
            // 
            this.c_LabelFirstName.AutoSize = true;
            this.c_LabelFirstName.Location = new System.Drawing.Point(12, 7);
            this.c_LabelFirstName.Name = "c_LabelFirstName";
            this.c_LabelFirstName.Size = new System.Drawing.Size(76, 16);
            this.c_LabelFirstName.TabIndex = 5;
            this.c_LabelFirstName.Text = "First Name:";
            // 
            // c_TextBoxFirstName
            // 
            this.c_TextBoxFirstName.Location = new System.Drawing.Point(15, 28);
            this.c_TextBoxFirstName.MaxLength = 25;
            this.c_TextBoxFirstName.Name = "c_TextBoxFirstName";
            this.c_TextBoxFirstName.Size = new System.Drawing.Size(297, 22);
            this.c_TextBoxFirstName.TabIndex = 1;
            // 
            // c_LabelLastName
            // 
            this.c_LabelLastName.AutoSize = true;
            this.c_LabelLastName.Location = new System.Drawing.Point(12, 55);
            this.c_LabelLastName.Name = "c_LabelLastName";
            this.c_LabelLastName.Size = new System.Drawing.Size(76, 16);
            this.c_LabelLastName.TabIndex = 7;
            this.c_LabelLastName.Text = "Last Name:";
            // 
            // c_TextBoxLastName
            // 
            this.c_TextBoxLastName.Location = new System.Drawing.Point(15, 76);
            this.c_TextBoxLastName.MaxLength = 25;
            this.c_TextBoxLastName.Name = "c_TextBoxLastName";
            this.c_TextBoxLastName.Size = new System.Drawing.Size(297, 22);
            this.c_TextBoxLastName.TabIndex = 2;
            // 
            // c_ButtonTest
            // 
            this.c_ButtonTest.Location = new System.Drawing.Point(12, 164);
            this.c_ButtonTest.Name = "c_ButtonTest";
            this.c_ButtonTest.Size = new System.Drawing.Size(120, 41);
            this.c_ButtonTest.TabIndex = 4;
            this.c_ButtonTest.Text = "Test";
            this.c_ButtonTest.UseVisualStyleBackColor = true;
            this.c_ButtonTest.Click += new System.EventHandler(this.Handle_ButtonTest_Click);
            // 
            // c_ButtonOK
            // 
            this.c_ButtonOK.Enabled = false;
            this.c_ButtonOK.Location = new System.Drawing.Point(4, 495);
            this.c_ButtonOK.Name = "c_ButtonOK";
            this.c_ButtonOK.Size = new System.Drawing.Size(137, 41);
            this.c_ButtonOK.TabIndex = 9;
            this.c_ButtonOK.Text = "Schedule";
            this.c_ButtonOK.UseVisualStyleBackColor = true;
            this.c_ButtonOK.Click += new System.EventHandler(this.Handle_ButtonOK_Click);
            // 
            // c_ButtonCancel
            // 
            this.c_ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.c_ButtonCancel.Location = new System.Drawing.Point(373, 12);
            this.c_ButtonCancel.Name = "c_ButtonCancel";
            this.c_ButtonCancel.Size = new System.Drawing.Size(120, 41);
            this.c_ButtonCancel.TabIndex = 10;
            this.c_ButtonCancel.Text = "Cancel";
            this.c_ButtonCancel.UseVisualStyleBackColor = true;
            this.c_ButtonCancel.Click += new System.EventHandler(this.Handle_ButtonCancel_Click);
            // 
            // c_LabelEmail
            // 
            this.c_LabelEmail.AutoSize = true;
            this.c_LabelEmail.Location = new System.Drawing.Point(9, 250);
            this.c_LabelEmail.Name = "c_LabelEmail";
            this.c_LabelEmail.Size = new System.Drawing.Size(241, 16);
            this.c_LabelEmail.TabIndex = 14;
            this.c_LabelEmail.Text = "Confirmation E-Mail Address (Optional):";
            this.c_LabelEmail.Visible = false;
            // 
            // c_TextBoxEmail
            // 
            this.c_TextBoxEmail.Enabled = false;
            this.c_TextBoxEmail.Location = new System.Drawing.Point(12, 269);
            this.c_TextBoxEmail.MaxLength = 40;
            this.c_TextBoxEmail.Name = "c_TextBoxEmail";
            this.c_TextBoxEmail.Size = new System.Drawing.Size(297, 22);
            this.c_TextBoxEmail.TabIndex = 5;
            this.c_TextBoxEmail.Visible = false;
            // 
            // c_LabelTestResults
            // 
            this.c_LabelTestResults.AutoSize = true;
            this.c_LabelTestResults.ForeColor = System.Drawing.Color.Red;
            this.c_LabelTestResults.Location = new System.Drawing.Point(24, 208);
            this.c_LabelTestResults.Name = "c_LabelTestResults";
            this.c_LabelTestResults.Size = new System.Drawing.Size(84, 16);
            this.c_LabelTestResults.TabIndex = 16;
            this.c_LabelTestResults.Text = "Not Tested...";
            this.c_LabelTestResults.Visible = false;
            // 
            // c_LabelFlightDate
            // 
            this.c_LabelFlightDate.AutoSize = true;
            this.c_LabelFlightDate.Location = new System.Drawing.Point(9, 367);
            this.c_LabelFlightDate.Name = "c_LabelFlightDate";
            this.c_LabelFlightDate.Size = new System.Drawing.Size(75, 16);
            this.c_LabelFlightDate.TabIndex = 18;
            this.c_LabelFlightDate.Text = "Flight Date:";
            this.c_LabelFlightDate.Click += new System.EventHandler(this.c_LabelCheckInDate_Click);
            // 
            // c_DateTimePickerFlightDate
            // 
            this.c_DateTimePickerFlightDate.CustomFormat = "";
            this.c_DateTimePickerFlightDate.Enabled = false;
            this.c_DateTimePickerFlightDate.Location = new System.Drawing.Point(10, 386);
            this.c_DateTimePickerFlightDate.Name = "c_DateTimePickerFlightDate";
            this.c_DateTimePickerFlightDate.Size = new System.Drawing.Size(302, 22);
            this.c_DateTimePickerFlightDate.TabIndex = 7;
            // 
            // c_TimerCountDown
            // 
            this.c_TimerCountDown.Tick += new System.EventHandler(this.Handle_TimerCountDown_Tick);
            // 
            // c_LabelTimeLeft
            // 
            this.c_LabelTimeLeft.AutoSize = true;
            this.c_LabelTimeLeft.Location = new System.Drawing.Point(13, 539);
            this.c_LabelTimeLeft.Name = "c_LabelTimeLeft";
            this.c_LabelTimeLeft.Size = new System.Drawing.Size(69, 16);
            this.c_LabelTimeLeft.TabIndex = 19;
            this.c_LabelTimeLeft.Text = "Time Left: ";
            this.c_LabelTimeLeft.Visible = false;
            // 
            // c_LabelPhoneNumber
            // 
            this.c_LabelPhoneNumber.AutoSize = true;
            this.c_LabelPhoneNumber.Location = new System.Drawing.Point(9, 306);
            this.c_LabelPhoneNumber.Name = "c_LabelPhoneNumber";
            this.c_LabelPhoneNumber.Size = new System.Drawing.Size(198, 16);
            this.c_LabelPhoneNumber.TabIndex = 23;
            this.c_LabelPhoneNumber.Text = "Confirmation Phone # (Optional):";
            this.c_LabelPhoneNumber.Visible = false;
            // 
            // c_TextBoxPhoneNumber
            // 
            this.c_TextBoxPhoneNumber.Enabled = false;
            this.c_TextBoxPhoneNumber.Location = new System.Drawing.Point(12, 325);
            this.c_TextBoxPhoneNumber.MaxLength = 40;
            this.c_TextBoxPhoneNumber.Name = "c_TextBoxPhoneNumber";
            this.c_TextBoxPhoneNumber.Size = new System.Drawing.Size(297, 22);
            this.c_TextBoxPhoneNumber.TabIndex = 6;
            this.c_TextBoxPhoneNumber.Visible = false;
            // 
            // c_TimerCheckinRetryInterval
            // 
            this.c_TimerCheckinRetryInterval.Interval = 10000;
            this.c_TimerCheckinRetryInterval.Tick += new System.EventHandler(this.c_TimerCheckinRetryInterval_Tick);
            // 
            // AutoCheckinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 565);
            this.Controls.Add(this.c_LabelPhoneNumber);
            this.Controls.Add(this.c_TextBoxPhoneNumber);
            this.Controls.Add(this.c_LabelTimeLeft);
            this.Controls.Add(this.c_LabelFlightDate);
            this.Controls.Add(this.c_DateTimePickerFlightDate);
            this.Controls.Add(this.c_LabelTestResults);
            this.Controls.Add(this.c_LabelEmail);
            this.Controls.Add(this.c_TextBoxEmail);
            this.Controls.Add(this.c_ButtonCancel);
            this.Controls.Add(this.c_ButtonOK);
            this.Controls.Add(this.c_ButtonTest);
            this.Controls.Add(this.c_LabelLastName);
            this.Controls.Add(this.c_TextBoxLastName);
            this.Controls.Add(this.c_LabelFirstName);
            this.Controls.Add(this.c_TextBoxFirstName);
            this.Controls.Add(this.c_LabelConfirmationNumber);
            this.Controls.Add(this.c_TextBoxConfirmationNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoCheckinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Southwest Auto Check-In Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox c_TextBoxConfirmationNumber;
        private System.Windows.Forms.Label c_LabelConfirmationNumber;
        private System.Windows.Forms.Label c_LabelFirstName;
        private System.Windows.Forms.TextBox c_TextBoxFirstName;
        private System.Windows.Forms.Label c_LabelLastName;
        private System.Windows.Forms.TextBox c_TextBoxLastName;
        private System.Windows.Forms.Button c_ButtonTest;
        private System.Windows.Forms.Button c_ButtonOK;
        private System.Windows.Forms.Button c_ButtonCancel;
        private System.Windows.Forms.Label c_LabelEmail;
        private System.Windows.Forms.TextBox c_TextBoxEmail;
        private System.Windows.Forms.Label c_LabelTestResults;
        private System.Windows.Forms.Label c_LabelFlightDate;
        private System.Windows.Forms.DateTimePicker c_DateTimePickerFlightDate;
        private System.Windows.Forms.Timer c_TimerCountDown;
        private System.Windows.Forms.Label c_LabelTimeLeft;
        private System.Windows.Forms.Label c_LabelPhoneNumber;
        private System.Windows.Forms.TextBox c_TextBoxPhoneNumber;
        private System.Windows.Forms.Timer c_TimerCheckinRetryInterval;
    }
}

