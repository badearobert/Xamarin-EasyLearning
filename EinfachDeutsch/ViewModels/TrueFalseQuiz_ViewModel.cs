using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class TrueFalseQuiz_ViewModel : BaseQuizViewModel<TrueFalseQuiz>
    {
        public TrueFalseQuiz_ViewModel()
        {
            TrueButtonPressed = new Command<View>(OnTruePressed);
            FalseButtonPressed = new Command<View>(OnFalsePressed);
        }

        protected override void UpdateGermanTranslation()
        {
            GermanWord = App.database.Read<DatabaseEntry>(CurrentQuestion.EntryReferenceId)?.FullEntry;
            Translation = App.database.Read<DatabaseEntry>(CurrentQuestion.EntryReferenceId)?.Translation;
        }

        public ICommand TrueButtonPressed { get; set; }
        public ICommand FalseButtonPressed { get; set; }

        private void OnTruePressed(View view)
        {
            ValidateAnswer(view, true);
        }

        private void OnFalsePressed(View view)
        {
            ValidateAnswer(view, false);
        }

        private void ValidateAnswer(View view, bool result)
        {
            if (result == CurrentQuestion.Answer)
            {
                OnCorrectAnswer(view);
            }
            else
            {
                OnWrongAnswer(view);
            }
        }
        public override void OnTimerExpired()
        {
            OnWrongAnswer(null);
        }
    }
}
