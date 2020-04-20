using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class Content_QuizTypesViewModel : BindableObject
    {
        public Content_QuizTypesViewModel()
        {
            LoadData();
        }
        private QuizType _currentItem;
        private ObservableCollection<QuizType> _quizTypes;
        public ObservableCollection<QuizType> QuizTypes
        {
            get { return _quizTypes; }
            set
            {
                _quizTypes = value;
                OnPropertyChanged();
            }
        }

        public QuizType CurrentItem
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
            QuizTypes = new ObservableCollection<QuizType>(QuizTypeService.Instance.Entries);
        }
    }
}
