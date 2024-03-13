using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects
{
    /// <summary>
    /// Classes that manage the application settings.
    /// </summary>
    public class SettingsManager
    {
        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private string _ActiveLanguage;
        #endregion

        /// <summary>
        /// Language actually activated.<br/>
        /// This is a three letter ISO language code.
        /// </summary>
        public string ActiveLangauge
        {
            get
            {
                return _ActiveLanguage;
            }
            set
            {
                if (value != _ActiveLanguage)
                {
                    _ActiveLanguage = value;
                    ActiveLanguageChangedValueEvent?.Invoke(this, value);
                }
            }
        }
        #endregion

        #region ===== EVENTS =====
        /// <summary>
        /// Event that manage the change of the actual activated langauge.
        /// </summary>
        public event EventHandler<string> ActiveLanguageChangedValueEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize the class and load the settings.
        /// </summary>
        public SettingsManager()
        {
            LoadSettings();

            ActiveLanguageChangedValueEvent += SettingsManager_ActiveLanguageChangedValueEvent;
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Load settings from DataBase.
        /// </summary>
        private void LoadSettings()
        {
            if (Program.cSQLiteManager.ExecuteReaderQuery("SELECT * FROM Settings", out List<Dictionary<string, SQLiteManager.DbResultStruct>> dbResult))
            {
                _ActiveLanguage = SQLiteManager.ConvertValue(dbResult[0]["ActiveLanguage"]);
            }
        }

        /// <summary>
        /// Store the three letter ISO language on DataBase.
        /// </summary>
        /// <param name="lanCode">Three letter ISO on </param>
        /// <returns></returns>
        private bool StoreLanguageOnDatabase(string lanCode)
        {
            string query = $"UPDATE Settings SET ActiveLanguage = '{lanCode}'";

            return Program.cSQLiteManager.ExecuteQuery(query) >= 0;
        }

        /// <summary>
        /// Listener that manage the event <see cref="ActiveLanguageChangedValueEvent"/>.<br/>
        /// This event is triggered everytime the language is changed.
        /// </summary>
        /// <param name="sender">Sender that triggers the event.<br/>Sender is a <see cref="SettingsManager"/> type.</param>
        /// <param name="e">Actual three letter ISO language code that is setted as active language.</param>
        private void SettingsManager_ActiveLanguageChangedValueEvent(object? sender, string e)
        {
            StoreLanguageOnDatabase(e);
        }
        #endregion

    }
}
