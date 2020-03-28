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
    public partial class LearningType_FullContentView : ContentView
    {
        private int pickerItemIndex = -1;
        private int sortedIndex = -1;
        public LearningType_FullContentView()
        {
            InitializeComponent();
            BindingContext = new LearningType_FullContentViewModel();
            PickerItem.SelectedIndex = 0;
            PickerSorted.SelectedIndex = 0;
        }

        ObservableCollection<QuizDatabaseEntry> getCollection(string selection, string sortBy)
        {
            ObservableCollection<QuizDatabaseEntry> newSelection = null;

            var allItems = (BindingContext as LearningType_FullContentViewModel).RawData;

            switch (selection)
            {
                case "All": { newSelection = new ObservableCollection<QuizDatabaseEntry>(allItems); break; }
                case "Verbs": { newSelection = new ObservableCollection<QuizDatabaseEntry>(allItems.Where(item => item.Type == "Verb")); break; }
                case "Nouns": { newSelection = new ObservableCollection<QuizDatabaseEntry>(allItems.Where(item => item.Type == "Noun")); break; }
                case "Adverbs": { newSelection = new ObservableCollection<QuizDatabaseEntry>(allItems.Where(item => item.Type == "Adverb")); break; }
                default: { throw new Exception("Missing selection"); }
            }

            Func<QuizDatabaseEntry, string> byAlphabet = item => item.Word;
            Func<QuizDatabaseEntry, string> byDifficulty = item => item.Difficulty;

            newSelection = new ObservableCollection<QuizDatabaseEntry>(newSelection.OrderBy((sortBy == "Alphabetically") ? byAlphabet : byDifficulty));


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