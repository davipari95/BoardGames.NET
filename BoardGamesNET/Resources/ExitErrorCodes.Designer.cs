﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoardGamesNET.Resources {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.8.0.0")]
    internal sealed partial class ExitErrorCodes : global::System.Configuration.ApplicationSettingsBase {
        
        private static ExitErrorCodes defaultInstance = ((ExitErrorCodes)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ExitErrorCodes())));
        
        public static ExitErrorCodes Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int NoErrorCode {
            get {
                return ((int)(this["NoErrorCode"]));
            }
            set {
                this["NoErrorCode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-1")]
        public int DataFileNotFound {
            get {
                return ((int)(this["DataFileNotFound"]));
            }
            set {
                this["DataFileNotFound"] = value;
            }
        }
    }
}
