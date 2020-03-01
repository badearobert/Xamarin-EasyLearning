using EinfachDeutsch.ViewModels;
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
            QuestionCustomTimer.TimerExpired += TimerExpiredHandler;
        }
        
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            OnTapPressed(sender);
        }

        private void TimerExpiredHandler()
        {
            OnTapPressed(null);
        }
        private async void OnTapPressed(object sender)
        {
            await QuestionCustomTimer.StopTimer();
            await AnimateAnswerImage(sender);
            await ShowResult();
            await AnimateOut();

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
            
            AnimateIn();
            QuestionCustomTimer.StartAnimations();
        }

        private async Task ShowResult()
        {
            if (this.AnimationIsRunning("ShowResultAnimation")) return;
            var ResultFadeIn = new Animation(v => AnswerResult.Opacity = v, 0, 1, Easing.SinIn);
            var ResultFadeOut = new Animation(v => AnswerResult.Opacity = v, 1, 0, Easing.SinOut);

            var parentAnimation = new Animation();
            parentAnimation.Add(0, 0.3, ResultFadeIn);
            parentAnimation.Add(0.8, 1.0, ResultFadeOut);
            parentAnimation.Commit(this, "ShowResultAnimation", 16, 1500, null, (v, c) => { });
            await Task.Delay(1500);
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




        private async Task AnimateAnswerImage(object sender)
        {
            if (this.AnimationIsRunning("TransitionAnimationAnswer")) return;

            string answer_correct = "https://cdn.pixabay.com/photo/2012/04/24/13/49/tick-40143_960_720.png";
            string answer_incorrect = "https://cdn.pixabay.com/photo/2012/04/13/00/22/red-31226_960_720.png";

            bool is_correct =
                (sender == TrueButtonContainer && vm.CurrentQuestion.Answer) ||
                (sender == FalseButtonContainer && !vm.CurrentQuestion.Answer);

            string answer = is_correct ? answer_correct : answer_incorrect;
            AnswerImage.Source = ImageSource.FromUri(new Uri(answer));
            AnswerImage.Opacity = 1;

            var AnswerImageScalingIn = new Animation(v => AnswerImage.Scale = v, 1, 5, Easing.SpringOut);
            var AnswerImageScalingOut = new Animation(v => AnswerImage.Scale = v, 5, 4, Easing.SpringOut);
            var AnswerImageFading = new Animation(v => AnswerImage.Opacity = v, 1, 0, Easing.SpringOut);

            var parentAnimation = new Animation();

            parentAnimation.Add(0, 0.7, AnswerImageScalingIn);
            parentAnimation.Add(0.7, 1, AnswerImageScalingOut);
            parentAnimation.Add(0.6, 1, AnswerImageFading);

            parentAnimation.Commit(this, "TransitionAnimationAnswer", 16, 1000, null, (v, c) => { });
            await Task.Delay(1000);
        }

    }
}