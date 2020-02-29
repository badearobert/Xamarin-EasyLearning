using EinfachDeutsch.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class FullContentViewModel : BindableObject
    {
        public FullContentViewModel()
        {
            LoadData();
        }
        private ObservableCollection<DatabaseEntry> _contentItems;
        public ObservableCollection<DatabaseEntry> ContentItems
        {
            get { return _contentItems; }
            set
            {
                _contentItems = value;
                OnPropertyChanged();
            }
        }

        private void LoadData()
        {
            var entries = App.database.Read<DatabaseEntry>();
            ContentItems = new ObservableCollection<DatabaseEntry>(entries);
        }
    }
}
