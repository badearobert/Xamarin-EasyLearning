﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EinfachDeutsch.Models
{
    [Table("TranslateWordsQuiz")]
    public class TranslateWordsQuiz
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Question { get; set; }
        public string CorrectResult { get; set; }
    }
}
