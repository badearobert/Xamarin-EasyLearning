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
        private string _germanWord { get; set; }
        public string GermanWord
        {
            get
            {
                return _germanWord;
            }
            set
            {
                _germanWord = value;
                OnPropertyChanged();
            }
        }
        private string _translation { get; set; }
        public string Translation
        {
            get
            {
                return _translation;
            }
            set
            {
                _translation = value;
                OnPropertyChanged();
            }
        }
        
        public TrueFalseQuiz_ViewModel()
        {
            TrueButtonPressed = new Command<View>(OnTruePressed);
            FalseButtonPressed = new Command<View>(OnFalsePressed);

            GermanWord = App.database.Read<DatabaseEntry>(CurrentQuestion.EntryReferenceId)?.FullEntry;
            Translation = App.database.Read<DatabaseEntry>(CurrentQuestion.EntryReferenceId)?.Translation;

            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentQuestion")
            {
                GermanWord = App.database.Read<DatabaseEntry>(CurrentQuestion.EntryReferenceId)?.FullEntry;
                Translation = App.database.Read<DatabaseEntry>(CurrentQuestion.EntryReferenceId)?.Translation; 
            }
        }

    public ICommand TrueButtonPressed { get; set; }
        public ICommand FalseButtonPressed { get; set; }

        private void OnTruePressed(View view)
        {
            ValidateAnswer(view, true);
            LoadNextQuiz(); 
        }

        private void OnFalsePressed(View view)
        {
            ValidateAnswer(view, false);
            LoadNextQuiz();
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
            LoadNextQuiz();
        }
    }
}
