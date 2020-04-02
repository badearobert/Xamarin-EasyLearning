using EinfachDeutsch.Common;
using EinfachDeutsch.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizType_FillEntryView : ContentView
    {
        private QuizType_FillEntryViewModel viewModel = new QuizType_FillEntryViewModel();
        private bool isChanging = false;

        List<Span> selections = new List<Span>();

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
            string[] parts = viewModel.CurrentQuestion.Question.Split(new string[] { "{}" }, StringSplitOptions.None);

            var formattedQuestion = new FormattedString();
            foreach (var part in parts)
            {
                formattedQuestion.Spans.Add(new Span { Text = part, ForegroundColor = Color.White });
                var span = new Span { Text = "___", ForegroundColor = Color.Red };
                selections.Add(span);
                formattedQuestion.Spans.Add(span);
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
                var btn = new Button() { Text = choice, BackgroundColor = Color.Yellow, TextColor = Color.Black };
                btn.Clicked += OnChoiceClicked;
                entries.Add(btn);
            }

            for (int i = 0; i < 4; ++i)
            {
                var btn = new Button() { Text = "Placeholder " + i, BackgroundColor = Color.Yellow, TextColor = Color.Black };
                btn.Clicked += OnChoiceClicked;
                entries.Add(btn);
        }
            var grid = new Grid();
            for (int i = 0; i < entries.Count; ++i) 
            {
                grid.Children.Add(entries[i], i / 3, i % 3);
            }
            AllChoices.Children.Clear();
            AllChoices.Children.Add(grid);
        }

        private void OnChoiceClicked(object sender, EventArgs e)
        {
            var obj = sender as Button;
        }
    }
}