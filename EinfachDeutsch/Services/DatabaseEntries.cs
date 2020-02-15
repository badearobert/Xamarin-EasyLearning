using System;
using System.Collections.Generic;
using System.Text;

namespace EinfachDeutsch.Services
{
    public class DatabaseEntries
    {
        private static DatabaseEntries _instance;
        public static DatabaseEntries Instance
        {
            get
            {
                if (_instance == null) _instance = new DatabaseEntries();
                return _instance;
            }
        }
        public RootObject rootObject;
    }

    public class Entry
    {
        public string FullEntry { get { return Article + " " + Word + " " + Preposition + " " + Case; }  }
        public string Word { get; set; }
        public string Preposition { get; set; }
        public string Case { get; set; }
        public string Translation { get; set; }
        public string Article { get; set; }
    }

    public class Content
    {
        public string name { get; set; }
        public List<Entry> entries { get; set; }
    }

    public class RootObject
    {
        public string name { get; set; }
        public string author { get; set; }
        public string version { get; set; }
        public string upload_date { get; set; }
        public List<Content> content { get; set; }
    }
}
