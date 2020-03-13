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
            Webpage = "https://badearobert.ro/Germana/German_stuff.json";

            if (Application.Current.Properties.ContainsKey("DataVersion"))
                DataVersion = Application.Current.Properties["DataVersion"].ToString();
        }

        public string Webpage { get; }
        public string DataVersion { get; } = "-";

        public async void SetVersion(string value)
        {
            Application.Current.Properties["DataVersion"] = value;
            await Application.Current.SavePropertiesAsync();
        }

    }
}
