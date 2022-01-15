using PDM_TP04.Helper;
using PDM_TP04.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDM_TP04
{
    public partial class App : Application
    {

        static SQLiteDataBaseHelper database;

        public static SQLiteDataBaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteDataBaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nina.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new AlunoPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
