using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
                new QuizType() { Id = 1, Name = "True or False", BackgroundColor = "#7BED8D", Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae" },
                new QuizType() { Id = 2, Name = "Guess the declination", BackgroundColor = "#20A39E", Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae" },
                new QuizType() { Id = 3, Name = "Translate words", BackgroundColor = "#FFBA49", Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae" },
                new QuizType() { Id = 4, Name = "Fill the missing data", BackgroundColor = "#B780FF", Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae" },
                new QuizType() { Id = 5, Name = "All quiz types", BackgroundColor = "#00FF00", Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae" },
              };
        }
    }
}