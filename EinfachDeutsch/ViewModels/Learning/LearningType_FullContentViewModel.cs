using EinfachDeutsch.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class LearningType_FullContentViewModel : BindableObject
    {
        public LearningType_FullContentViewModel()
        {
            LoadData();
        }
        private void LoadData()
        {
            RawData = App.database.Read<QuizDatabaseEntry>();

            //ContentItems = new ObservableCollection<DatabaseEntry>(RawData);
            PickerItemsSource = new ObservableCollection<string>() { "All", "Verbs", "Nouns", "Adverbs" };
        }
        public List<QuizDatabaseEntry> RawData { get; private set; }
        private ObservableCollection<QuizDatabaseEntry> _contentItems = null;
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

        public ObservableCollection<QuizDatabaseEntry> ContentItems
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
