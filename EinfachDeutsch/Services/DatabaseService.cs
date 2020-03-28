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

        public T Read<T>(int index) where T : new()
        {
            T data = default(T);
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<T>();
                data = conn.Find<T>(index);
            }
            return data;
        }

        public List<T> Read<T>() where T : new()
        {
            List<T> data = new List<T>();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<T>();
                data = conn.Table<T>().ToList();
            }
            return data;
        }
        
        public bool Update<T>(T entry)
        {
            bool result = false;
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<T>();
                result = (1 == conn.Update(entry));
            }
            return result;
        }
        
        public bool Add<T>(T entry)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<T>();
                var numberOfRows = conn.Insert(entry);
                return (numberOfRows > 0);
            }
        }
        public bool Delete<T>(T entry)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.CreateTable<T>();
                var numberOfRows = conn.Delete<T>(entry);
                return (numberOfRows > 0);
            }
        }
        public bool Delete<T>(int index) where T : new()
        {
            try
            {
                var items = Read<T>();
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
                {
                    conn.CreateTable<T>();
                    var numberOfRows = conn.Delete<T>(index);
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
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(db_path))
            {
                conn.DropTable<TrueFalseQuiz>();
                conn.DropTable<FillEntryQuiz>();
                conn.DropTable<SelectionQuiz>();
                conn.DropTable<TranslateWordsQuiz>();
                conn.DropTable<QuizDatabaseEntry>();
            }
        }
    }
}
