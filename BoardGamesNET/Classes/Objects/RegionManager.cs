using BoardGamesNET.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Objects
{
    public class RegionManager
    {
        #region ===== FIELDS FOR VARIABLES =====
        private Dictionary<string, string> _AvailableLanguages;
        private Dictionary<long, Dictionary<string, string>> _TranslatedText;
        #endregion

        #region ===== VARIABLES =====
        public Dictionary<string, string> AvailableLangauges
        {
            get
            {
                return _AvailableLanguages;
            }
            private set
            {
                if (value != _AvailableLanguages)
                {
                    _AvailableLanguages = value;
                }
            }
        }

        public Dictionary<long, Dictionary<string, string>> TranslatedText
        {
            get
            {
                return _TranslatedText;
            }
            private set
            {
                _TranslatedText = value;
            }
        }
        #endregion

        #region ===== CONSTRUCTORS =====
        public RegionManager()
        {
            InitializeAvailableLangauges();
            InitializeTranslatedText();
        }
        #endregion

        #region ===== METHODS =====
        public void TranslateAllElementsInControl(Control container)
        {
            TranslateAllElementsInControl(container, Program.cSettingsManager.ActiveLangauge);
        }

        public void TranslateAllElementsInControl(Control container, string languageCode)
        {
            foreach (ITranslatable component in GetAllTranslatableComponents(container))
            {
                long lanRef = component.LanguageReference;

                if (lanRef != 0)
                {
                    if (component is Control)
                    {
                        ((Control)component).Text = GetTranslatedText(lanRef, languageCode);
                    }
                    else if (component is ToolStripItem)
                    {
                        ((ToolStripItem)component).Text = GetTranslatedText(lanRef, languageCode);
                    } 
                }
            }
        }

        public static IEnumerable<ITranslatable> GetAllTranslatableComponents(Control c)
        {
            List<ITranslatable> objects = new List<ITranslatable>(0);

            if (c is ITranslatable)
            {
                objects.Add((ITranslatable)c);
            }

            if (c is MenuStrip)
            {
                objects.AddRange(GetMenuStripTranslatableElements((MenuStrip)c));
            }
            else
            {
                foreach (Control subControls in c.Controls)
                {
                    objects.AddRange(GetAllTranslatableComponents(subControls));
                }
            }

            return objects;
        }

        public static ICollection<ITranslatable> GetMenuStripTranslatableElements(MenuStrip menu)
        {
            List<ITranslatable> objects = new List<ITranslatable>(0);

            foreach (ToolStripMenuItem item in menu.Items)
            {
                objects.AddRange(GetAllDropDownItemsInMenuItem(item));
            }

            return objects;
        }

        public static ICollection<ITranslatable> GetAllDropDownItemsInMenuItem(ToolStripMenuItem menuItem)
        {
            List<ITranslatable> objects = new List<ITranslatable>(0);

            if (menuItem is ITranslatable) objects.Add((ITranslatable)menuItem);

            foreach (ToolStripMenuItem item in menuItem.DropDownItems)
            {
                objects.AddRange(GetAllDropDownItemsInMenuItem(item));
            }

            return objects;
        }

        public string GetTranslatedText(long languageReference)
        {
            return GetTranslatedText(languageReference, Program.cSettingsManager.ActiveLangauge);
        }

        public string GetTranslatedText(long languageReference, string languageCode)
        {
            return TranslatedText[languageReference][languageCode];
        }

        private void InitializeAvailableLangauges()
        {
            AvailableLangauges = new Dictionary<string, string>(0);

            if (Program.cSQLiteManager.ExecuteReaderQuery("SELECT * FROM AvailableLanguages", out List<Dictionary<string, SQLiteManager.DbResultStruct>> dbResult))
            {
                foreach (Dictionary<string, SQLiteManager.DbResultStruct> row in dbResult)
                {
                    AvailableLangauges.Add(SQLiteManager.ConvertValue(row["Code"]), SQLiteManager.ConvertValue(row["Description"]));
                }
            }
        }

        private void InitializeTranslatedText()
        {
            TranslatedText = new Dictionary<long, Dictionary<string, string>>(0);

            if (Program.cSQLiteManager.ExecuteReaderQuery("SELECT * FROM Regions", out List<Dictionary<string, SQLiteManager.DbResultStruct>> dbResult))
            {
                foreach (Dictionary<string, SQLiteManager.DbResultStruct> row in dbResult)
                {
                    long id = SQLiteManager.ConvertValue(row["ID"]);
                    Dictionary<string, string> texts = new Dictionary<string, string>(0);

                    foreach (string lanCode in AvailableLangauges.Keys)
                    {
                        texts.Add(lanCode, SQLiteManager.ConvertValue(row[lanCode]));
                    }

                    TranslatedText.Add(id, texts);
                }
            }
        }
        #endregion

    }
}
