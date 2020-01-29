using EinfachDeutsch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels
{
    public class BaseQuizViewModel<T> : BindableObject where T: new()
    {
        public BaseQuizViewModel() 
        {
            LoadData();
        }

        private int _score = 0;
        private int question_index = 0;

        private T _currentQuestion;
        private ObservableCollection<T> _quizData;
        public T CurrentQuestion
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
        public ObservableCollection<T> QuizData
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
            QuizData = new ObservableCollection<T>(QuizService.Instance.LoadData<T>());
            LoadNextQuiz();
        }

        protected void LoadNextQuiz()
        {
            CurrentQuestion = QuizData[(question_index++ % QuizData.Count)];
        }

        protected void OnCorrectAnswer(View view)
        {
            IncreaseScore();
            _ = AnimateButton(view);
        }
        protected void OnWrongAnswer(View view)
        {
            _ = AnimateButton(view);
        }

        private void IncreaseScore()
        {
            Score++;
        }
        private async Task AnimateButton(View view)
        {
            if (view == null) return;
            await view.ScaleTo(1.5, 50, Easing.Linear);
            await Task.Delay(100);
            await view.ScaleTo(1, 50, Easing.Linear);
        }

    }

}
