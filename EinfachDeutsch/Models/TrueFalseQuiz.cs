using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EinfachDeutsch.Models
{
    [Table("TrueFalseQuiz")]
    public class TrueFalseQuiz
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Question { get; set; }
        public bool Answer { get; set; }
        public int EntryReferenceId { get; set; }
    }
}
