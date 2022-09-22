using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite1.Interface;
using SQLite1.DA;

namespace SQLite1
{
    public partial class App : Application
    {
        static DataBase da;

        public static DataBase dao
        {
            get
            {

                if (da == null)
                {
                    da = new DataBase(DependencyService.Get<IStdLocHelper>().GetLocalFilePath("studentdb.db"));
                }

                return da;
            }

        }

        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage();

            MainPage = new NavigationPage(new MainPage());
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
