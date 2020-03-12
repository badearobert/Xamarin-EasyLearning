using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EinfachDeutsch.ViewModels
{
    public class BaseQuiz : INotifyPropertyChanged
    {
        public bool IsPaused { get; set; } = true;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand QuizQuestionFinished { get; set; }
        public virtual void LoadNextQuiz()
        {

        }
        public void OnResume()
        {
            IsPaused = false;
            LoadNextQuiz();
        }
        public void OnPause()
        {
            IsPaused = true;
        }

        protected static int _score = 0;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }
        public void IncreaseScore()
        {
            Score++;
        }
        public void ResetScore()
        {
            Score = 0;
        }
    }
}
