using System;
using System.Collections.Generic;
using System.Text;

namespace EinfachDeutsch.Models
{
    public class RootObject
    {
        public string name { get; set; }
        public string author { get; set; }
        public string version { get; set; }
        public string upload_date { get; set; }
        public List<Content> content { get; set; }
        public List<BasicContent> basic_learning_content { get; set; }
    }

    public class Content
    {
        public string name { get; set; }
        public List<QuizDatabaseEntry> entries { get; set; }
    }

    public class BasicContent
    {
        public string name { get; set; }
        public List<BaseLearningEntry> entries { get; set; }
    }
}
