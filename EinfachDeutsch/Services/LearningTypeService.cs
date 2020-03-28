using EinfachDeutsch.Models;
using EinfachDeutsch.Views;
using System;
using System.Collections.Generic;
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

        public List<LearningType> GetLearningTypes()
        {
            return new List<LearningType>
            {
                new LearningType() { Id = 1, BackgroundColor = "#7BED8D", Name = "Basics", Description = "TBD" },
                new LearningType() { Id = 2, BackgroundColor = "#20A39E", Name = "Expressions", Description = "TBD" },
                new LearningType() { Id = 3, BackgroundColor = "#FFBA49", Name = "Sentences", Description = "TBD" },
                new LearningType() { Id = 4, BackgroundColor = "#B780FF", Name = "Idioms", Description = "TBD" },
                new LearningType() { Id = 5, BackgroundColor = "#00FF00", Name = "Full Content", Description = "TBD" },
            };
        }

        public View CreateFrom(int idx)
        {
            switch (idx)
            {
                case 1:return new LearningType_BasicsView();
                case 2:return new LearningType_ExpressionsView();
                case 3:return new LearningType_SentencesView();
                case 4:return new LearningType_IdiomsView();
                case 5:return new LearningType_FullContentView();
                default: return new Label() { Text = "TBD" };
            }
        }
    }
}
