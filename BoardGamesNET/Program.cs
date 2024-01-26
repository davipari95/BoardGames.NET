using BoardGamesNET.Classes.Objects;
using BoardGamesNET.Classes.Forms;

namespace BoardGamesNET
{
    internal static class Program
    {
        public static MainForm MainForm { get; private set; }
        public static SQLiteManager cSQLiteManager { get; private set; }
        public static RegionManager cRegionManager { get; private set; }
        public static SettingsManager cSettingsManager { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            cSQLiteManager = new SQLiteManager("Data/Data.db");
            cRegionManager = new RegionManager();
            cSettingsManager = new SettingsManager();

            Application.Run(MainForm = new MainForm());
        }
    }
}