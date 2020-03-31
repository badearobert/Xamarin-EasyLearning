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
        public QuizType_FillEntryView()
        {
            InitializeComponent();
            BindingContext = viewModel;
            AnswerResultContainer.SetOnTimerExpiredCallback(OnTimerExpired);
            SetQuestion();
            SetChoices();
            AnswerResultContainer.StartAnimations();
        }
        private void SetQuestion()
        {
            var formattedQuestion = new FormattedString();
            formattedQuestion.Spans.Add(new Span { Text = "to be ", ForegroundColor = Color.Red });

            formattedQuestion.Spans.Add(new Span { Text = "linked with ", ForegroundColor = Color.AliceBlue });
            formattedQuestion.Spans.Add(new Span { Text = "current question", ForegroundColor = Color.Green });
            CurrentQuestionLabel.FormattedText = formattedQuestion;
        }
        private void SetChoices()
        {
            var grid = new Grid();

            for (int i = 0; i < 9; ++i)
            {
                var button = new Button()
                {
                    Text = "Choice " + i.ToString(),
                    BackgroundColor = Color.Yellow,
                    TextColor = Color.Black,
                };
                grid.Children.Add(button, i / 3, i % 3);
            }
            AllChoices.Children.Add(grid);
        }
        private void OnTimerExpired()
        {
            OnValidatePressed(null, null);
        }

        private async void OnValidatePressed(object sender, EventArgs e)
        {
            bool is_correct = Helper.ValidateAnswer("", "");

            await AnswerResultContainer.AnimateAnswerImage(is_correct);
            viewModel.QuizQuestionFinished?.Execute(null);
        }
    }
}