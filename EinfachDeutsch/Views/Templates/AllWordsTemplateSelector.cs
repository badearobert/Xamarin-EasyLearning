using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EinfachDeutsch.Views.Templates
{
    public class AllWordsTemplateSelector : DataTemplateSelector
    {
        // not used for now, may be removed or used as reference later on
        public DataTemplate VerbsTemplate { get; set; }
        public DataTemplate NounsTemplate { get; set; }
        public DataTemplate AdverbsTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is null) return null;

            if (item is DatabaseEntry entry)
            {
                if (entry.Type == "Verb") return VerbsTemplate;
                if (entry.Type == "Nouns") return NounsTemplate;
                if (entry.Type == "Adverbs") return AdverbsTemplate;
            }
            throw new ArgumentException(nameof(AllWordsTemplateSelector));
        }
    }
}
