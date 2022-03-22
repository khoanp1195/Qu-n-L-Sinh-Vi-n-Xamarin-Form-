using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UngDungQuanLy.Data;
using System.IO;

namespace UngDungQuanLy
{
    public partial class App : Application
    {
        private static QLSV _db;
        public static QLSV db { 
            get
            {
                if (_db == null)
                    _db = new QLSV(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "qlsv.db3"));
                return _db;
                    
            }
        }



        public App()
        {
            InitializeComponent();

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
