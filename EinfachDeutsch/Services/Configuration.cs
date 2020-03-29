using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EinfachDeutsch.Services
{
    public class Configuration
    {
        public Configuration()
        {
            if (Application.Current.Properties.ContainsKey("DataVersion"))
                DataVersion = Application.Current.Properties["DataVersion"].ToString();

            if (Application.Current.Properties.ContainsKey("LastStoredDate"))
                LastStoredDate = Application.Current.Properties["LastStoredDate"].ToString();

            if (Application.Current.Properties.ContainsKey("WordOfTheDayIndex"))
            {
                int result = -1;
                if (int.TryParse(Application.Current.Properties["WordOfTheDayIndex"].ToString(), out result)) 
                    WordOfTheDayIndex = result;
            }
        }

        public string Webpage { get; private set; } = "https://badearobert.ro/Germana/German_stuff.json";

        public string DataVersion { get; private set; } = "-";
        public string LastStoredDate { get; private set; } = "";
        public int WordOfTheDayIndex { get; private set; } = -1;
        private async void SaveProperty(string prop, string value)
        {
            Application.Current.Properties[prop] = value;
            await Application.Current.SavePropertiesAsync();
        }

        public void SetVersion(string value)
        {
            DataVersion = value;
            SaveProperty("DataVersion", value);
        }
        public void SetLastStoredDate(string value)
        {
            LastStoredDate = value;
            SaveProperty("LastStoredDate", value);
        }
        public void SetWordOfTheDayIndex(string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                WordOfTheDayIndex = result;
                SaveProperty("WordOfTheDayIndex", value);
            }
        }
    }
}
