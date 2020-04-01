using EinfachDeutsch.Common;
using EinfachDeutsch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizType_FillEntryView : ContentView
    {
        private QuizType_FillEntryViewModel viewModel = new QuizType_FillEntryViewModel();
        private bool isViewUpToDate = false;
        private bool isChanging = false;
        public QuizType_FillEntryView()
        {
            InitializeComponent();
            BindingContext = viewModel;
            AnswerResultContainer.SetOnTimerExpiredCallback(OnTimerExpired);
            AnswerResultContainer.StartAnimations();
        }

        private void OnTimerExpired()
        {
            OnValidatePressed(null, null);
        }

        private async void OnValidatePressed(object sender, EventArgs e)
        {
            bool is_correct = Helper.ValidateAnswer("", "");

            await AnswerResultContainer.AnimateAnswerImage(is_correct);
            isChanging = false;
            viewModel.QuizQuestionFinished?.Execute(null);
        }

        private void CurrentQuestionLabel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Text" || isChanging) 
                return;
            isChanging = true;
            SetQuestion();
            SetChoices();
            AnswerResultContainer.StartAnimations();
        }
        private void SetQuestion()
        {
            //Question = "Test for fill entry, noun is {} and article is {}",
            //CorrectResult = entry.Word + "," + entry.Article,

            string[] parts = viewModel.CurrentQuestion.Question.Split(new string[] { "{}" }, StringSplitOptions.None);

            var formattedQuestion = new FormattedString();
            foreach (var part in parts)
            {
                formattedQuestion.Spans.Add(new Span { Text = part, ForegroundColor = Color.White });
                formattedQuestion.Spans.Add(new Span { Text = "___", ForegroundColor = Color.Red });
            }

            CurrentQuestionLabel.Text = "";
            CurrentQuestionLabel.FormattedText = formattedQuestion;
        }
        private void SetChoices()
        {
            string[] choices = viewModel.CurrentQuestion.CorrectResult.Split(',');
            List<Button> entries = new List<Button>();
            

            foreach (var choice in choices)
            {
                entries.Add(new Button()
                {
                    Text = choice,
                    BackgroundColor = Color.Yellow,
                    TextColor = Color.Black,
                });
            }

            for (int i = 0; i < 4; ++i)
            {
                entries.Add(new Button()
                {
                    Text = "Placeholder " + i,
                    BackgroundColor = Color.Yellow,
                    TextColor = Color.Black,
                });
            }
            var grid = new Grid();
            for (int i = 0; i < entries.Count; ++i) 
            {
                grid.Children.Add(entries[i], i / 3, i % 3);
            }
            AllChoices.Children.Clear();
            AllChoices.Children.Add(grid);
        }
    }
}