using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using Newtonsoft.Json;
using Plugin.LocalNotifications;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EinfachDeutsch
{
    public partial class App : Application
    {
        public static DatabaseService database { get; private set; }
        public static Configuration Configuration { get; private set; }
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public App(string fullPath_db)
        {
            InitializeComponent();
            Device.SetFlags(new string[]{ "MediaElement_Experimental" });
            MainPage = new SharedTransitionNavigationPage(new SplashScreenPage());

            Configuration = new Configuration();
            database = new DatabaseService(fullPath_db);
            LoadDatabaseAsync();
        }

        private async void LoadDatabaseAsync()
        {
            await Task.Run(() => DatabaseEntries.Instance.ResetDatabaseEntries());
            MainPage = new SharedTransitionNavigationPage(new MainSelectionPage());

            CrossLocalNotifications.Current.Show("EinfachDeutsch", "Word of the day - TBD", 1, DateTime.Now.AddHours(2));
        }
    }
}
