using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels.Learning
{
    public class LearningType_WordOfTheDayViewModel : BindableObject
    {
        public LearningType_WordOfTheDayViewModel()
        {
            UpdateWordOfTheDay();
        }

        private void UpdateWordOfTheDay()
        {
            string Today = DateTime.Today.ToString();
            if (Today == App.Configuration.LastStoredDate)
            {
                // get index and retrieve question
                SetWordOfTheDay(App.Configuration.WordOfTheDayIndex);
            }
            else
            {
                App.Configuration.SetLastStoredDate(Today);
                GenerateNewWordOfTheDay();
            }
        }

        private void SetWordOfTheDay(int value)
        {
            App.Configuration.SetWordOfTheDayIndex(value.ToString());
            CurrentEntry = App.database.Read<QuizDatabaseEntry>(value);
        }
        public void GenerateNewWordOfTheDay()
        {
            var entries = App.database.Read<QuizDatabaseEntry>();
            Random rnd = new Random();
            SetWordOfTheDay(rnd.Next(0, entries.Count));
        }

        private QuizDatabaseEntry _currentEntry = null;
        public QuizDatabaseEntry CurrentEntry
        {
            get { return _currentEntry; }
            set
            {
                _currentEntry = value;
                OnPropertyChanged();
            }
        }
    }
}
