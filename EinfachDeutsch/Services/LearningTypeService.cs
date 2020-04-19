using EinfachDeutsch.Models;
using EinfachDeutsch.Views;
using EinfachDeutsch.Views.LearningType;
using EinfachDeutsch.Views.LearningType.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EinfachDeutsch.Services
{
    public class LearningTypeService
    {
        private static LearningTypeService _instance;
        public static LearningTypeService Instance
        {
            get
            {
                if (_instance == null) _instance = new LearningTypeService();
                return _instance;
            }
        }

        public List<LearningType> Entries = new List<LearningType>()
        {
            new LearningType() { Id = 1, BackgroundColor = "#7BED8D", Name = "Basics", Description = "TBD", View = new LearningType_BasicsView() },
            new LearningType() { Id = 2, BackgroundColor = "#20A39E", Name = "Expressions", Description = "TBD", View = new LearningType_ExpressionsView() },
            new LearningType() { Id = 3, BackgroundColor = "#FFBA49", Name = "Sentences", Description = "TBD", View = new LearningType_SentencesView() },
            new LearningType() { Id = 4, BackgroundColor = "#B780FF", Name = "Idioms", Description = "TBD", View = new LearningType_IdiomsView() },
            new LearningType() { Id = 5, BackgroundColor = "#FFBA49", Name = "Word of the day", Description = "TBD", View = new LearningType_WordOfTheDayView() },
            new LearningType() { Id = 6, BackgroundColor = "#00FFFF", Name = "Media player", Description = "TBD", View = new LearningType_MediaPlayerView() },
            new LearningType() { Id = 7, BackgroundColor = "#00FF00", Name = "Full Content", Description = "TBD", View = new LearningType_FullContentView() },
            new LearningType() { Id = 8, BackgroundColor = "#00FF00", Name = "Conjunctions (When)", Description = "TBD", View = new LearningType_ConjunctionsView() },
            new LearningType() { Id = 9, BackgroundColor = "#00FF00", Name = "Prepositions", Description = "TBD", View = new LearningType_PrepositionsView() },
            new LearningType() { Id = 10, BackgroundColor = "#00FF00", Name = "Tense reference", Description = "TBD", View = new LearningType_TenseView() },
            new LearningType() { Id = 11, BackgroundColor = "#7BED8D", Name = "Personal Pronomen", Description = "TBD", View = new LearningType_PersonalPronomenView() },
            new LearningType() { Id = 12, BackgroundColor = "#20A39E", Name = "Adjektiv Deklination", Description = "TBD", View = new LearningType_AdjektivDeklinationView() },
            new LearningType() { Id = 13, BackgroundColor = "#FFBA49", Name = "Cases - Nominative", Description = "TBD", View = new LearningType_Cases_Nominative() },
            new LearningType() { Id = 14, BackgroundColor = "#B780FF", Name = "Cases - Accusative", Description = "TBD", View = new LearningType_Cases_Accusative() },
            new LearningType() { Id = 15, BackgroundColor = "#FFBA49", Name = "Cases - Dative", Description = "TBD", View = new LearningType_Cases_Dative() },
            new LearningType() { Id = 16, BackgroundColor = "#00FFFF", Name = "Cases - Genitive", Description = "TBD", View = new LearningType_Cases_Genitive() },
        };
    }
}
