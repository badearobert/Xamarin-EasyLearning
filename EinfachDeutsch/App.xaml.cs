using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using Plugin.SharedTransitions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch
{
    public partial class App : Application
    {
        public static DatabaseService database { get; private set; }
        public App(string fullPath_db)
        {
            InitializeComponent();
            database = new DatabaseService(fullPath_db);

            AddDatabaseEntries();
            MainPage = new SharedTransitionNavigationPage(new MainPage());
        }

        private void AddDatabaseEntries()
        {
            database.DeleteAll();
            database.Add(new TrueFalseQuiz() { Question = "The answer to this one is true", Answer = true });
            database.Add(new TrueFalseQuiz() { Question = "The answer to this one is false", Answer = false });

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
