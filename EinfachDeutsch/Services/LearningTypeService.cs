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
                new LearningType() { Id = 1, BackgroundColor = "#7BED8D", Name = "All content", Description = "TBD" },
                new LearningType() { Id = 2, BackgroundColor = "#20A39E", Name = "TBD", Description = "TBD" },
            };
        }

        public View CreateFrom(int idx)
        {
            switch (idx)
            {
                case 1:return new FullContentView();
                default: return new Label() { Text = "TBD" };
            }
        }
    }
}
