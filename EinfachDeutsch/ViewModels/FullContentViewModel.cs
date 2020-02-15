using EinfachDeutsch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class FullContentViewModel : BindableObject
    {
        //ContentItems

        public FullContentViewModel()
        {
            LoadData();
        }
        private ObservableCollection<Services.Entry> _contentItems;
        public ObservableCollection<Services.Entry> ContentItems
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
            List<Services.Entry> concat = new List<Services.Entry>();
            foreach (var item in DatabaseEntries.Instance.rootObject.content)
            {
                concat.AddRange(item.entries);
            }
            ContentItems = new ObservableCollection<Services.Entry>(concat);
        }
    }
}
