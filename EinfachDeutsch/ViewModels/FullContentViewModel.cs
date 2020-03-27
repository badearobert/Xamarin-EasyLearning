using EinfachDeutsch.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class FullContentViewModel : BindableObject
    {
        public FullContentViewModel()
        {
            LoadData();
        }
        private void LoadData()
        {
            RawData = App.database.Read<DatabaseEntry>();

            //ContentItems = new ObservableCollection<DatabaseEntry>(RawData);
            PickerItemsSource = new ObservableCollection<string>() { "All", "Verbs", "Nouns", "Adverbs" };
        }
        public List<DatabaseEntry> RawData { get; private set; }
        private ObservableCollection<DatabaseEntry> _contentItems = null;
        private ObservableCollection<string> _pickerItemsSource = null;

        public ObservableCollection<string> PickerItemsSource
        {
            get { return _pickerItemsSource; }
            set
            {
                _pickerItemsSource = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DatabaseEntry> ContentItems
        {
            get { return _contentItems; }
            set
            {
                _contentItems = value;
                OnPropertyChanged();
            }
        }


    }
}
