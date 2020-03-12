using EinfachDeutsch.ViewModels;
using EinfachDeutsch.Views.Custom;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizType_TrueFalseView : ContentView
    {
        private bool isViewUpToDate = false;
        TrueFalseQuiz_ViewModel viewModel = new TrueFalseQuiz_ViewModel();
        public QuizType_TrueFalseView()
        {
            InitializeComponent();
            BindingContext = viewModel;
            AnswerResultContainer.SetOnTimerExpiredCallback(OnTimerExpired);
        }
        
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            OnTapPressed(sender);
        }
        private void OnTimerExpired()
        {
            OnTapPressed(null);
        }

        private async void OnTapPressed(object sender)
        {
            if (viewModel.IsPaused) return;
            if (isViewUpToDate) return;
            isViewUpToDate = true;
            bool is_correct =
                (sender == TrueButtonContainer && viewModel.CurrentQuestion.Answer) ||
                (sender == FalseButtonContainer && !viewModel.CurrentQuestion.Answer);
            
            await AnswerResultContainer.AnimateAnswerImage(is_correct);
            await AnimateOut();
            SelectOption(sender);
            viewModel?.QuizQuestionFinished?.Execute(null);

        }

        private void SelectOption(object sender)
        {
            if (sender == TrueButtonContainer)
            {
                viewModel?.TrueButtonPressed?.Execute(sender);
            }
            else if (sender == FalseButtonContainer)
            {
                viewModel?.FalseButtonPressed?.Execute(sender);
            }
            else
            {
                viewModel?.OnTimerExpired();
            }
        }

        private void CurrentQuestion_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (viewModel.IsPaused) return;
            if (e.PropertyName != "FormattedText")
                return;
            isViewUpToDate = false;
            _ = AnimateIn();
            AnswerResultContainer.StartAnimations();
        }

        private async Task AnimateIn()
        {
            if (this.AnimationIsRunning("TransitionAnimationIn")) return;
            var QuestionFadeOut = new Animation(v => CurrentQuestion.Opacity = v, 0, 1, Easing.SinIn);
            var TrueButttonSlideOut = new Animation(v => TrueButtonContainer.TranslationX = v, -this.Width, 0, Easing.SinIn);
            var FalseButttonSlideOut = new Animation(v => FalseButtonContainer.TranslationX = v, this.Width, 0, Easing.SinIn);

            var parentAnimation = new Animation();
            parentAnimation.Add(0.3, 1, QuestionFadeOut);
            parentAnimation.Add(0, 0.3, TrueButttonSlideOut);
            parentAnimation.Add(0, 0.3, FalseButttonSlideOut);

            parentAnimation.Commit(this, "TransitionAnimationIn", 16, 1000, null, (v, c) => { });
            await Task.Delay(1000);
        }
        private async Task AnimateOut()
        {
            if (this.AnimationIsRunning("TransitionAnimationOut")) return;

            var QuestionFadeOut = new Animation(v => CurrentQuestion.Opacity = v, 1, 0, Easing.SinOut);
            var TrueButttonSlideOut = new Animation(v => TrueButtonContainer.TranslationX = v, 0, -this.Width, Easing.SinOut);
            var FalseButttonSlideOut = new Animation(v => FalseButtonContainer.TranslationX = v, 0, this.Width, Easing.SinOut);

            var parentAnimation = new Animation();
            parentAnimation.Add(0, 0.3, QuestionFadeOut);
            parentAnimation.Add(0.3, 1, TrueButttonSlideOut);
            parentAnimation.Add(0.3, 1, FalseButttonSlideOut);

            parentAnimation.Commit(this, "TransitionAnimationOut", 16, 1000, null, (v, c) => { });
            await Task.Delay(1000);
        }
    }
}