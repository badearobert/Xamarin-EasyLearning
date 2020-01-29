using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EinfachDeutsch.Themes
{
    public class ThemeHelper
    {
        public static string CurrentTheme;

        public static void Toggle()
        {
            string newTheme = (CurrentTheme == "light") ? "dark" : "light";
            ChangeTheme(newTheme);
        }

        public static void ChangeTheme(string theme)
        {
            if (theme == CurrentTheme) return;

            App.Current.Resources.MergedDictionaries.Clear();
            App.Current.Resources.Clear();
            ResourceDictionary applicationResourceDictionary = App.Current.Resources;
            ResourceDictionary newTheme = null;
            switch (theme.ToLowerInvariant())
            {
                case "light": 
                    newTheme = new LightTheme();
                    break;
                case "dark": 
                    newTheme = new DarkTheme();
                    break;
                default:break;
            }

            foreach (var merged in newTheme.MergedDictionaries)
            {
                applicationResourceDictionary.MergedDictionaries.Add(merged);
            }
            ManuallyCopyThemes(newTheme, applicationResourceDictionary);
            CurrentTheme = theme;
        }
        private static void ManuallyCopyThemes(ResourceDictionary fromResource, ResourceDictionary toResource)
        {
            foreach (var item in fromResource.Keys)
            {
                toResource[item] = fromResource[item];
            }
        }

    }
}
