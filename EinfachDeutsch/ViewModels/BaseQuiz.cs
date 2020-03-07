﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EinfachDeutsch.ViewModels
{
    public class BaseQuiz : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand QuizQuestionFinished { get; set; }
        public virtual void LoadNextQuiz()
        {

        }
        public virtual void OnResume()
        {

        }
        public virtual void OnPause()
        {

        }
    }
}