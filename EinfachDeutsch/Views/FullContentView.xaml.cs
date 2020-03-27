using EinfachDeutsch.Models;
using EinfachDeutsch.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullContentView : ContentView
    {
        private int pickerItemIndex = -1;
        private int sortedIndex = -1;
        public FullContentView()
        {
            InitializeComponent();
            BindingContext = new FullContentViewModel();
            PickerItem.SelectedIndex = 0;
            PickerSorted.SelectedIndex = 0;
        }

        ObservableCollection<DatabaseEntry> getCollection(string selection, string sortBy)
        {
            ObservableCollection<DatabaseEntry> newSelection = null;

            var allItems = (BindingContext as FullContentViewModel).RawData;

            switch (selection)
            {
                case "All": { newSelection = new ObservableCollection<DatabaseEntry>(allItems); break; }
                case "Verbs": { newSelection = new ObservableCollection<DatabaseEntry>(allItems.Where(item => item.Type == "Verb")); break; }
                case "Nouns": { newSelection = new ObservableCollection<DatabaseEntry>(allItems.Where(item => item.Type == "Noun")); break; }
                case "Adverbs": { newSelection = new ObservableCollection<DatabaseEntry>(allItems.Where(item => item.Type == "Adverb")); break; }
                default: { throw new Exception("Missing selection"); }
            }

            Func<DatabaseEntry, string> byAlphabet = item => item.Word;
            Func<DatabaseEntry, string> byDifficulty = item => item.Difficulty;

            newSelection = new ObservableCollection<DatabaseEntry>(newSelection.OrderBy((sortBy == "Alphabetically") ? byAlphabet : byDifficulty));


            return newSelection;
        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerItemIndex == PickerItem.SelectedIndex) return;
            pickerItemIndex = PickerItem.SelectedIndex;

            string sel_name = PickerItem.SelectedItem as string;
            string sort_name = PickerSorted.SelectedItem as string;
            ColViewItems.ItemsSource = getCollection(sel_name, sort_name);
        }

        private void PickerSorted_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sortedIndex == PickerSorted.SelectedIndex) return;
            sortedIndex = PickerSorted.SelectedIndex;

            string sel_name = PickerItem.SelectedItem as string;
            string sort_name = PickerSorted.SelectedItem as string;
            ColViewItems.ItemsSource = getCollection(sel_name, sort_name);
        }
    }
}