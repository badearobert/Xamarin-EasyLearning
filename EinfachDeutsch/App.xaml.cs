using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Plugin.SharedTransitions;
using Shiny;
using Shiny.Notifications;
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
            //await Task.Run(() => DatabaseEntries.Instance.ResetDatabaseEntries());
            MainPage = new SharedTransitionNavigationPage(new MainSelectionPage());
        }

        protected override async void OnStart()
        {
            await SendNotificationNow();
            await ScheduleLocalNotification("1",new DateTimeOffset(DateTime.Now.AddHours(-3).AddSeconds(10)));
            await ScheduleLocalNotification("2",new DateTimeOffset(DateTime.Now.AddSeconds(10)));
            await ScheduleLocalNotification("3",new DateTimeOffset(DateTime.UtcNow.AddHours(-3).AddSeconds(10)));
            await ScheduleLocalNotification("4",new DateTimeOffset(DateTime.UtcNow.AddSeconds(10)));
            await ScheduleLocalNotification("5", DateTimeOffset.UtcNow.AddMinutes(1));
        }

        Task SendNotificationNow()
        {
            var notification = new Notification
            {
                Title = "Testing Local Notifications",
                Message = "Hello boss",
            };

            return ShinyHost.Resolve<INotificationManager>().RequestAccessAndSend(notification);
        }

        Task ScheduleLocalNotification(string msg, DateTimeOffset scheduledTime)
        {
            var notification = new Notification
            {
                Title = "Testing Local Notifications",
                Message = "Test work for - " + msg,
                ScheduleDate = scheduledTime
            };

            return ShinyHost.Resolve<INotificationManager>().Send(notification);
        }
    }
}
