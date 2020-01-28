using EasyDeutsch.Models;
using EasyDeutsch.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyDeutsch.ViewModels
{
    public class TrueFalseQuiz_ViewModel : BindableObject
    {
        public TrueFalseQuiz_ViewModel()
        {
            LoadData();
            TrueButtonPressed = new Command<object>(OnTruePressed);
            FalseButtonPressed = new Command<object>(OnFalsePressed);
        }

        public ICommand TrueButtonPressed { get; set; }
        public ICommand FalseButtonPressed { get; set; }

        private int _score = 0;
        private int question_index = 0;

        private TrueFalseQuiz _currentQuestion;
        private ObservableCollection<TrueFalseQuiz> _quizData;
        public TrueFalseQuiz CurrentQuestion
        {
            get { return _currentQuestion; }
            set
            {
                _currentQuestion = value;
                OnPropertyChanged();
            }
        }
       
        public int Score
        {
            get { return _score; }
            set 
            { 
                _score = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TrueFalseQuiz> QuizData
        {
            get { return _quizData; }
            set
            {
                _quizData = value;
                OnPropertyChanged();
            }
        }

        private void LoadData()
        {
            QuizData = new ObservableCollection<TrueFalseQuiz>(QuizService.Instance.GetTrueFalseQuestions());
            ChangeQuestion();
        }
        private void OnTruePressed(object view)
        {
            if (true == CurrentQuestion.Answer)
            {
                IncreaseScore();
                _ = AnimateButton((View)view);
            }
            ChangeQuestion();
        }
        private void OnFalsePressed(object view)
        {
            if (false == CurrentQuestion.Answer)
            {
                IncreaseScore();
                _ = AnimateButton((View)view);
            }
            ChangeQuestion();
        }
        private void ChangeQuestion()
        {
            CurrentQuestion = QuizData[(question_index++ % QuizData.Count)];
        }

        private void IncreaseScore()
        {
            Score++;
        }

        private async Task AnimateButton(View view)
        {
            await view.ScaleTo(1.5, 50, Easing.Linear);
            await Task.Delay(100);
            await view.ScaleTo(1, 50, Easing.Linear);
        }
    }
}
