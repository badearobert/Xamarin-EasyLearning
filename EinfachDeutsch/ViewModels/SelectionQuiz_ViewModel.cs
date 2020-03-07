using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class SelectionQuiz_ViewModel : BaseQuizViewModel<SelectionQuiz>
    {
        public SelectionQuiz_ViewModel()
        {
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (SelectedItem != null)
                { 
                    OnSelectionChanged();
                    SelectedItem = null;
                    OnPropertyChanged();
                }
            }
        }
        private void OnSelectionChanged()
        {
            ValidateAnswer(null, _selectedItem);
            QuizQuestionFinished?.Execute(null);
        }
        private void ValidateAnswer(View view, string result)
        {
            if (result == CurrentQuestion.CorrectResult)
            {
                OnCorrectAnswer(view);
            }
            else
            {
                OnWrongAnswer(view);
            }
        }
    }
}
