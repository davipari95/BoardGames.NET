using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects
{
    public class SettingsManager
    {

        #region ===== FIELDS FOR VARIABLES =====
        private string _ActiveLanguage;
        #endregion

        #region ===== VARIABLES =====
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
        public event EventHandler<string> ActiveLanguageChangedValueEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        public SettingsManager()
        {
            LoadSettings();

            ActiveLanguageChangedValueEvent += SettingsManager_ActiveLanguageChangedValueEvent;
        }
        #endregion

        #region ===== METHODS =====
        private void LoadSettings()
        {
            if (Program.cSQLiteManager.ExecuteReaderQuery("SELECT * FROM Settings", out List<Dictionary<string, SQLiteManager.DbResultStruct>> dbResult))
            {
                _ActiveLanguage = SQLiteManager.ConvertValue(dbResult[0]["ActiveLanguage"]);
            }
        }

        private bool StoreLanguageOnDatabase(string lanCode)
        {
            string query = $"UPDATE Settings SET ActiveLanguage = '{lanCode}'";

            return Program.cSQLiteManager.ExecuteQuery(query) >= 0;
        }

        private void SettingsManager_ActiveLanguageChangedValueEvent(object? sender, string e)
        {
            StoreLanguageOnDatabase(e);
        }
        #endregion

    }
}
