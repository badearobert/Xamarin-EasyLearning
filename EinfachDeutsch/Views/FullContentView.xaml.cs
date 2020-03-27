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
            var allItems = (BindingContext as FullContentViewModel).RawData;
            ObservableCollection<DatabaseEntry> newSelection = null;

            if (selection == "All") { newSelection = new ObservableCollection<DatabaseEntry>(allItems); }
            if (selection == "Verbs") { newSelection = new ObservableCollection<DatabaseEntry>(allItems.Where(item => item.Type == "Verb")); }
            if (selection == "Nouns") { newSelection = new ObservableCollection<DatabaseEntry>(allItems.Where(item => item.Type == "Noun")); }
            if (selection == "Adverbs") { newSelection = new ObservableCollection<DatabaseEntry>(allItems.Where(item => item.Type == "Adverb")); }

            if (sortBy == "Alphabetically")
                newSelection = new ObservableCollection<DatabaseEntry>(newSelection.OrderBy(item => item.Word));
            else
                newSelection = new ObservableCollection<DatabaseEntry>(newSelection.OrderBy(item => item.Translation));

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