using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EinfachDeutsch.ViewModels
{
    public class AllEntriesQuiz_ViewModel : BaseQuizViewModel<BaseQuizEntry>
    {
        public override void LoadData()
        {
            /*List<BaseQuizEntry> items = QuizService.Instance.LoadAllData();
            QuizData = new ObservableCollection<BaseQuizEntry>(items);
            TotalQuestionsCount = QuizData.Count;
            LoadNextQuiz();*/
        }
        public override void LoadNextQuiz()
        {
            //QuestionIndex = new Random().Next(QuizData.Count);
            //CurrentQuestion = QuizData[QuestionIndex];
        }
    }
}
