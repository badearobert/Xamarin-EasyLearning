using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class BaseLearningViewModel<T> : BindableObject where T : new()
    {
        private ObservableCollection<T> _entries = null;

        public ObservableCollection<T> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }
        public BaseLearningViewModel()
        {
            LoadData();
        }
        protected virtual void LoadData()
        {
            Entries = new ObservableCollection<T>(App.database.Read<T>());
        }
    }
}
