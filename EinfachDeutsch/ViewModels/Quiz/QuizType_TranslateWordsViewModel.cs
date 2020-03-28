using EinfachDeutsch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class QuizType_TranslateWordsViewModel : BaseQuizViewModel<TranslateWordsQuiz>
    {
        public QuizType_TranslateWordsViewModel()
        {
            SubmitPressed = new Command<View>(OnSubmitPressed);
        }
        protected override void UpdateGermanTranslation()
        {
            GermanWord = App.database.Read<QuizDatabaseEntry>(CurrentQuestion.EntryReferenceId)?.FullEntry;
            Translation = App.database.Read<QuizDatabaseEntry>(CurrentQuestion.EntryReferenceId)?.Translation;
        }

        public ICommand SubmitPressed { get; set; }

        public void OnSubmitPressed(View view)
        {
            Entry entry = view as Entry;
            ValidateAnswer(view, entry.Text);
            entry.Text = "";
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
