using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EinfachDeutsch.Models
{
    [Table("QuizDatabaseEntry")]
    public class QuizDatabaseEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FullEntry 
        { 
            get => 
                Article + (Word?.Length > 0 ? " " : "") + Word +
                (Preposition?.Length > 0 ? " " : "") + Preposition +
                (Case?.Length > 0 ? " " : "") + Case; 
        }
        public string Word { get; set; } = "";
        public string Preposition { get; set; } = "";
        public string Case { get; set; } = "";
        public string Translation { get; set; } = "";
        public string Article { get; set; } = "";
        public string Type { get; set; } = "";
        public string Difficulty { get; set; } = "";
        public string Index { get; set; } = "";
        public string References { get; set; } = "";
    }


}
