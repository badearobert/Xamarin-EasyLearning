using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class Content_LearningTypesViewModel : BindableObject
    {
        public Content_LearningTypesViewModel()
        {
            LoadData();
        }
        private LearningType _currentItem;
        private ObservableCollection<LearningType> _learningTypes;
        public ObservableCollection<LearningType> LearningTypes
        {
            get { return _learningTypes; }
            set
            {
                _learningTypes = value;
                OnPropertyChanged();
            }
        }

        public LearningType CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged();
            }
        }

        private void LoadData()
        {
            LearningTypes = new ObservableCollection<LearningType>(LearningTypeService.Instance.Entries);
        }
    }
}
