﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SouthwestAutoCheckin.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://www.southwest.com/flight/lookup-air-reservation.html?default=cc")]
        public string TestConfirmationPageAddress {
            get {
                return ((string)(this["TestConfirmationPageAddress"]));
            }
            set {
                this["TestConfirmationPageAddress"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("confirmationNumber")]
        public string TestConfirmationNumberFieldHtmlId {
            get {
                return ((string)(this["TestConfirmationNumberFieldHtmlId"]));
            }
            set {
                this["TestConfirmationNumberFieldHtmlId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("passengerFirstName")]
        public string TestConfirmationFirstNameFieldHtmlId {
            get {
                return ((string)(this["TestConfirmationFirstNameFieldHtmlId"]));
            }
            set {
                this["TestConfirmationFirstNameFieldHtmlId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("passengerLastName")]
        public string TestConfirmationLastNameFieldHtmlId {
            get {
                return ((string)(this["TestConfirmationLastNameFieldHtmlId"]));
            }
            set {
                this["TestConfirmationLastNameFieldHtmlId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("form-mixin--submit-button")]
        public string TestConfirmationSubmitButtonFieldHtmlId {
            get {
                return ((string)(this["TestConfirmationSubmitButtonFieldHtmlId"]));
            }
            set {
                this["TestConfirmationSubmitButtonFieldHtmlId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("li.page-error--message")]
        public string TestConfirmationErrorHtmlSelector {
            get {
                return ((string)(this["TestConfirmationErrorHtmlSelector"]));
            }
            set {
                this["TestConfirmationErrorHtmlSelector"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Server01\\sales\\Telscreen\\Schedule Plans\\EyeRes Trips\\SouthwestAutoCheckIn\\Sched" +
            "uledCheckIns")]
        public string ScheduledCheckInJsonDirectory {
            get {
                return ((string)(this["ScheduledCheckInJsonDirectory"]));
            }
            set {
                this["ScheduledCheckInJsonDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Server01\\sales\\Telscreen\\Schedule Plans\\EyeRes Trips\\SouthwestAutoCheckIn")]
        public string SouthwestCheckInBaseDirectory {
            get {
                return ((string)(this["SouthwestCheckInBaseDirectory"]));
            }
            set {
                this["SouthwestCheckInBaseDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Server01\\sales\\Telscreen\\Schedule Plans\\EyeRes Trips\\SouthwestAutoCheckIn\\Firef" +
            "oxPortable\\FirefoxPortable.exe")]
        public string FirefoxBinaryPath {
            get {
                return ((string)(this["FirefoxBinaryPath"]));
            }
            set {
                this["FirefoxBinaryPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Server01\\sales\\Telscreen\\Schedule Plans\\EyeRes Trips\\SouthwestAutoCheckIn\\TestD" +
            "ata.txt")]
        public string TestDataFilePath {
            get {
                return ((string)(this["TestDataFilePath"]));
            }
            set {
                this["TestDataFilePath"] = value;
            }
        }
    }
}
