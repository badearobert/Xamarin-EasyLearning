using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class TranslateWordsQuiz_ViewModel : BaseQuizViewModel<TranslateWordsQuiz>
    {
        public TranslateWordsQuiz_ViewModel()
        {
            SubmitPressed = new Command<View>(OnSubmitPressed);
        }

        public ICommand SubmitPressed { get; set; }

        private void OnSubmitPressed(View view)
        {
            Entry entry = view as Entry;
            ValidateAnswer(view, entry.Text);
            entry.Text = "";
            LoadNextQuiz();
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
