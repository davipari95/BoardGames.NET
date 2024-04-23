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
    /// <summary>
    /// Class for managing languages and translations
    /// </summary>
    public class RegionManager
    {
        #region ===== VARIABLES =====

        #region ===== FIELDS FOR VARIABLES =====
        private Dictionary<string, string> _AvailableLanguages;
        private Dictionary<long, Dictionary<string, string>> _TranslatedText;
        #endregion

        /// <summary>
        /// List of available languages.
        /// </summary>
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

        /// <summary>
        /// Dictionary containing translated texts.<br/>
        /// To retrieve the translated text you should use this variable like
        /// <code>
        /// TranslatedText[<i>language_reference</i>][<i>langauge_code</i>]
        /// </code>
        /// where <c><i>language_reference</i></c> is the data ID of the text and <c><i>language_code</i></c> is the three letter language ISO code.
        /// </summary>
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
        /// <summary>
        /// Initialize the class.<br/>
        /// In this constructor all informations will be retrieved from the database.
        /// </summary>
        public RegionManager()
        {
            InitializeAvailableLangauges();
            InitializeTranslatedText();
        }
        #endregion

        #region ===== METHODS =====
        /// <summary>
        /// Translate all <see cref="ITranslatable"/> elements inside a control.
        /// </summary>
        /// <param name="container">Control that you want translate, translating even subcontrols.</param>
        public void TranslateAllElementsInControl(Control container)
        {
            TranslateAllElementsInControl(container, Program.cSettingsManager.ActiveLangauge);
        }

        /// <summary>
        /// Translate all <see cref="ITranslatable"/> elements inside a control.
        /// </summary>
        /// <param name="container">Control that you want translate, translating even subcontrols.</param>
        /// <param name="languageCode">Three characters ISO langauge code.</param>
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

        /// <summary>
        /// Retrieve all <see cref="ITranslatable"/> components inside the control.<br/>
        /// If <paramref name="c"/> is an <see cref="ITranslatable"/> element, returns <paramref name="c"/> too.
        /// </summary>
        /// <param name="c">Control where you want retrieve all <see cref="ITranslatable"/> elements.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieve a collection containing the <see cref="ITranslatable"/> elements inside a <see cref="MenuStrip"/>.
        /// </summary>
        /// <param name="menu">Menu where you want to retrieve all <see cref="ITranslatable"/> elements.</param>
        /// <returns></returns>
        public static ICollection<ITranslatable> GetMenuStripTranslatableElements(MenuStrip menu)
        {
            List<ITranslatable> objects = new List<ITranslatable>(0);

            foreach (ToolStripItem item in menu.Items)
            {
                if (item is ToolStripDropDownItem)
                {
                    objects.AddRange(GetAllDropDownItemsInMenuItem((ToolStripDropDownItem)item));
                }
            }

            return objects;
        }

        /// <summary>
        /// Retrieve a collection containing the <see cref="ITranslatable"/> elements inside a <see cref="ToolStripMenuItem"/>.<br/>
        /// If <paramref name="menuItem"/> is a <see cref="ITranslatable"/> element, returns it too.
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public static ICollection<ITranslatable> GetAllDropDownItemsInMenuItem(ToolStripDropDownItem menuItem)
        {
            List<ITranslatable> objects = new List<ITranslatable>(0);

            if (menuItem is ITranslatable) objects.Add((ITranslatable)menuItem);

            foreach (ToolStripItem item in menuItem.DropDownItems)
            {
                if (item is ToolStripDropDownItem)
                {
                    objects.AddRange(GetAllDropDownItemsInMenuItem((ToolStripDropDownItem)item)); 
                }
            }

            return objects;
        }

        /// <summary>
        /// Retrieve a translated text.
        /// </summary>
        /// <param name="languageReference">Lanague ID of the translation.</param>
        /// <param name="languageCode">Three letter ISO language code (<c>eng</c>; <c>ita</c>; ...)<br/>
        /// If this value is <see langword="null"/> return the translation of the active language.<br/>
        /// Default value is <see langword="null"/>.</param>
        /// <returns>A translated text of the language passed on <paramref name="languageCode"/>.</returns>
        public string GetTranslatedText(long languageReference, string? languageCode = null)
        {
            if (languageCode == null)
            {
                languageCode = Program.cSettingsManager.ActiveLangauge;
            }

            return TranslatedText[languageReference][languageCode];
        }

        /// <summary>
        /// Retrieve a translated text with parameters.
        /// </summary>
        /// <param name="languageReference">Langauge ID of the translation.</param>
        /// <param name="languageCode">Three letter ISO language code (<c>eng</c>; <c>ita</c>; ...)<br/>
        /// Set this value to <see langword="null"/> to use the actual ative language.</param>
        /// <param name="args">Arguments used to substitute <tt>{0}</tt>, <tt>{1}</tt>, ...</param>
        /// <returns>A translated text of the language passed on <paramref name="languageCode"/> with <paramref name="args"/> values.</returns>
        public string GetTranslatedText(long languageReference, string? languageCode, params object[] args)
        {
            return string.Format(GetTranslatedText(languageReference, languageCode), args);
        }

        /// <summary>
        /// Show a message dialog with a translated text.
        /// </summary>
        /// <param name="messageLangaugeReference">Text ID of the message.</param>
        /// <param name="titleLangaugeReference">Text ID of the title.</param>
        /// <param name="buttons">
        /// Which buttons you want to see (OK, Cancel, Yes, No, ...).<br/>
        /// Default value is <see cref="MessageBoxButtons.OK"/>.
        /// </param>
        /// <param name="icon">
        /// Icon type to show.<br/>
        /// Default value is <see cref="MessageBoxIcon.None"/>.
        /// </param>
        /// <returns>
        /// Wich button is pressed.
        /// </returns>
        public DialogResult ShowTranslatedMessageDialog(long messageLangaugeReference, long titleLangaugeReference, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            string message = GetTranslatedText(messageLangaugeReference);
            string title = GetTranslatedText(titleLangaugeReference);

            return MessageBox.Show(message, title, buttons, icon);
        }

        /// <summary>
        /// Load the variable <see cref="AvailableLangauges"/> reading the informations from DataBase.
        /// </summary>
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

        /// <summary>
        /// Initialize the variable <see cref="TranslatedText"/> reading informations from DataBase.
        /// </summary>
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
