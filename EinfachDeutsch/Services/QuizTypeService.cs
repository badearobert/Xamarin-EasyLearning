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

        public List<QuizType> GetQuizTypes()
        {
            return new List<QuizType>
            {
                new QuizType() { Id = 1, Name = "True or False", BackgroundColor = "#7BED8D", Description = "Choose between true or false. 50% chance is good enough"},
                new QuizType() { Id = 2, Name = "Guess the declination", BackgroundColor = "#20A39E", Description = "Select the correct answer" },
                new QuizType() { Id = 3, Name = "Translate words", BackgroundColor = "#FFBA49", Description = "Do you know the word in your main language?" },
                new QuizType() { Id = 4, Name = "Fill the missing data", BackgroundColor = "#B780FF", Description = "This is not implementted yet" },
                new QuizType() { Id = 5, Name = "All in one", BackgroundColor = "#00FF00", Description = "Combination of all quiz types" },
                new QuizType() { Id = 6, Name = "TBD", BackgroundColor = "#ff4dff", Description = "TBD" },
              };
        }

        public View CreateFrom(QuizType quiz)
        {
            switch (quiz.Id)
            {
                case 1: return new QuizType_TrueFalseView();
                case 2: return new QuizType_SelectionView();
                case 3: return new QuizType_TranslateWordsView();
                case 4: return new QuizType_FillEntryView();
                case 5: return new QuizType_AllEntries();
                case 6: return new QuizType_FillEntryView(); 
                default: throw new Exception("CreateFrom() case not handled: " + quiz.Id); 
            }
        }
    }
}