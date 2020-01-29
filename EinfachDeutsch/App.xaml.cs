using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
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

            database.Add(new SelectionQuiz() { Question = "Selection quiz: result is 0", CorrectResult = "0", Choices = "0,1,2,3" });
            database.Add(new SelectionQuiz() { Question = "Selection quiz: result is 1", CorrectResult = "1", Choices = "0,1,2,3" });
            database.Add(new SelectionQuiz() { Question = "Selection quiz: result is 2", CorrectResult = "2", Choices = "0,1,2,3" });
            database.Add(new SelectionQuiz() { Question = "Selection quiz: result is 3", CorrectResult = "3", Choices = "0,1,2,3" });

            database.Add(new TranslateWordsQuiz() { Question = "Translate words question. Answer is: happy", CorrectResult = "happy" });
            database.Add(new TranslateWordsQuiz() { Question = "Translate words question. Answer is: sad", CorrectResult = "sad" });
            database.Add(new TranslateWordsQuiz() { Question = "Translate words question. Answer is: yoy", CorrectResult = "yoy" });

            database.Add(new FillEntryQuiz() { Question = "Fill entry question. Answer is: abc", CorrectResult = "abc" });
            database.Add(new FillEntryQuiz() { Question = "Fill entry question. Answer is: nah", CorrectResult = "nah" });
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
