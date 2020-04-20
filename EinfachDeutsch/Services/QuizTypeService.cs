using EinfachDeutsch.Models;
using EinfachDeutsch.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EinfachDeutsch.Services
{
    public class QuizTypeService
    {
        private static QuizTypeService _instance;
        public static QuizTypeService Instance
        {
            get
            {
                if (_instance == null) _instance = new QuizTypeService();
                return _instance;
            }
        }
        public List<QuizType> Entries = new List<QuizType>()
        {
                new QuizType() { Id = 1, Name = "True or False", BackgroundColor = "#7BED8D", Description = "Choose between true or false. 50% chance is good enough", View = new QuizType_TrueFalseView() },
                new QuizType() { Id = 2, Name = "Guess the declination", BackgroundColor = "#20A39E", Description = "Select the correct answer", View = new QuizType_SelectionView()  },
                new QuizType() { Id = 3, Name = "Translate words", BackgroundColor = "#FFBA49", Description = "Do you know the word in your main language?", View = new QuizType_TranslateWordsView()  },
                new QuizType() { Id = 4, Name = "Fill the missing data", BackgroundColor = "#B780FF", Description = "This is not implementted yet", View = new QuizType_FillEntryView()  },
                new QuizType() { Id = 5, Name = "All in one", BackgroundColor = "#00FF00", Description = "Combination of all quiz types", View = new QuizType_AllEntries()  },
                new QuizType() { Id = 6, Name = "TBD", BackgroundColor = "#ff4dff", Description = "TBD", View = new QuizType_FillEntryView()  },
        };
    }
}