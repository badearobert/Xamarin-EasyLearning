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

        public List<T> LoadData<T>() where T : new()
        {
            return App.database.Read<T>();
        }        
    }
}
