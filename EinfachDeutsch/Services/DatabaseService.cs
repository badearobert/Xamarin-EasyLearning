using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EinfachDeutsch.Services
{
    public class DatabaseService
    {
        private readonly string db_path;

        public DatabaseService(string path)
        {
            this.db_path = path;
        }

        public QuizType Read<QuizType>(int index) where QuizType : new()
        {
            QuizType data = default(QuizType);
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<QuizType>();
                data = conn.Find<QuizType>(index);
            }
            return data;
        }

        public List<QuizType> Read<QuizType>() where QuizType : new()
        {
            List<QuizType> data = new List<QuizType>();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<QuizType>();
                data = conn.Table<QuizType>().ToList();
            }
            return data;
        }
        
        public bool Update<QuizType>(QuizType entry)
        {
            bool result = false;
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<QuizType>();
                result = (1 == conn.Update(entry));
            }
            return result;
        }
        
        public bool Add<QuizType>(QuizType entry)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<QuizType>();
                var numberOfRows = conn.Insert(entry);
                return (numberOfRows > 0);
            }
        }
        public bool Delete<QuizType>(QuizType entry)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<QuizType>();
                var numberOfRows = conn.Delete<QuizType>(entry);
                return (numberOfRows > 0);
            }
        }
        public bool Delete<QuizType>(int index) where QuizType : new()
        {
            try
            {
                var items = Read<QuizType>();
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
                {
                    conn.CreateTable<QuizType>();
                    var numberOfRows = conn.Delete<QuizType>(index);
                    return (numberOfRows > 0);
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public void DeleteAll()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(this.db_path))
            {
                conn.DropTable<TrueFalseQuiz>();
                conn.DropTable<FillEntryQuiz>();
                conn.DropTable<SelectionQuiz>();
                conn.DropTable<TranslateWordsQuiz>();
            }
        }
    }
}
