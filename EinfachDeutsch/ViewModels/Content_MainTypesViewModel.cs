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
    public class Content_MainTypesViewModel : BindableObject
    {
        public Content_MainTypesViewModel()
        {
            LoadData();
        }
        private LearningType _learningCurrentItem;
        public LearningType LearningCurrentItem
        {
            get { return _learningCurrentItem; }
            set
            {
                _learningCurrentItem = value;
                OnPropertyChanged();
            }
        }
        private QuizType _quizCurrentItem;
        public QuizType QuizCurrentItem
        {
            get { return _quizCurrentItem; }
            set
            {
                _quizCurrentItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LearningType> _learningTypes;
        private ObservableCollection<QuizType> _quizTypes;

        public ObservableCollection<LearningType> LearningTypes
        {
            get { return _learningTypes; }
            set
            {
                _learningTypes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<QuizType> QuizTypes
        {
            get { return _quizTypes; }
            set
            {
                _quizTypes = value;
                OnPropertyChanged();
            }
        }

        private void LoadData()
        {
            QuizTypes = new ObservableCollection<QuizType>(QuizTypeService.Instance.GetQuizTypes());
            LearningTypes = new ObservableCollection<LearningType>(LearningTypeService.Instance.GetLearningTypes());
        }
    }
}
