using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class QuizType_SelectionViewModel : BaseQuizViewModel<SelectionQuiz>
    {
        public QuizType_SelectionViewModel()
        {
        }
        protected override void UpdateGermanTranslation()
        {
            GermanWord = App.database.Read<QuizDatabaseEntry>(CurrentQuestion.EntryReferenceId)?.FullEntry;
            Translation = App.database.Read<QuizDatabaseEntry>(CurrentQuestion.EntryReferenceId)?.Translation;
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
        public void OnSelectionChanged()
        {
            ValidateAnswer(null, _selectedItem);
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
