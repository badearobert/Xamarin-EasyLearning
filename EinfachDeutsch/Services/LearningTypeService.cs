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

        public List<string> GetLearningTypes()
        {
            return new List<string>
            {
                "tbd"
            };
        }

        public View CreateFrom(int idx)
        {
            switch (idx)
            {
                case 0:return new Label() { Text = "TBD" };
                case 1: return new QuizType_TrueFalseView();

                default: throw new Exception("CreateFrom() case not handled: " + idx);
            }
        }
    }
}
