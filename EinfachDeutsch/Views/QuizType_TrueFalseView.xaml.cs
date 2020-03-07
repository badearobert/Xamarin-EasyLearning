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
        TrueFalseQuiz_ViewModel vm = new TrueFalseQuiz_ViewModel();

        public QuizType_TrueFalseView()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            OnTapPressed(sender);
        }

        private async void OnTapPressed(object sender)
        {
            bool is_correct =
                (sender == TrueButtonContainer && vm.CurrentQuestion.Answer) ||
                (sender == FalseButtonContainer && !vm.CurrentQuestion.Answer);
            await AnswerResultContainer.AnimateAnswerImage(is_correct);
            await AnimateOut();
            SelectOption(sender);
        }

        private void SelectOption(object sender)
        {
            if (sender == TrueButtonContainer)
            {
                vm?.TrueButtonPressed?.Execute(sender);
            }
            else if (sender == FalseButtonContainer)
            {
                vm?.FalseButtonPressed?.Execute(sender);
            }
            else
            {
                vm?.OnTimerExpired();
            }
        }

        private void CurrentQuestion_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName != "FormattedText")
                return;

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