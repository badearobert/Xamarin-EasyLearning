using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EinfachDeutsch.Models
{
    [Table("SelectionQuiz")]
    public class SelectionQuiz : BaseQuizEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Choices { get; set; }
        public string CorrectResult { get; set; }
        public int EntryReferenceId { get; set; }
    }

}
