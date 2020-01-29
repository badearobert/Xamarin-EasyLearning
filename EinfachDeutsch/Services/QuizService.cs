using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EinfachDeutsch.Services
{
    public class QuizService
    {
        private static QuizService _instance;
        public static QuizService Instance
        {
            get
            {
                if (_instance == null) _instance = new QuizService();
                return _instance;
            }
        }

        public List<TrueFalseQuiz> GetTrueFalseQuestions()
        {
            return new List<TrueFalseQuiz>
            {
                new TrueFalseQuiz() { Question = "The answer to this one is true", Answer = true },
                new TrueFalseQuiz() { Question = "The answer to this one is false", Answer = false },
            };
        }



        
    }
}
