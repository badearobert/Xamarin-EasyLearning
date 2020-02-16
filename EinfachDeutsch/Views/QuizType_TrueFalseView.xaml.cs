using EinfachDeutsch.ViewModels;
using System;
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
            await AnimateAnswerImage(sender);
            await AnimateOut();

            if (sender == TrueButtonContainer)
            {
                vm?.TrueButtonPressed?.Execute(sender);
            }
            else if (sender == FalseButtonContainer)
            {
                vm?.FalseButtonPressed?.Execute(sender);
            }   
        }
        private void ScoreLabel_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName != "FormattedText")
                return;

            AnimateScoreInOut();
        }

        private void CurrentQuestion_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName != "FormattedText")
                return;

            AnimateIn();
        }

        private async Task AnimateIn()
        {
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


        private async Task AnimateScoreInOut()
        {
            var ScoreScalingOut = new Animation(v => ScoreLabel.Scale = v, 1, 1.1, Easing.SpringOut);
            var ScoreSlideOut = new Animation(v => ScoreLabel.TranslationX = v, 0, -this.Width, Easing.SpringOut);
            var ScoreSlideIn = new Animation(v => ScoreLabel.TranslationX = v, this.Width, 0, Easing.SpringOut);
            var ScoreScalingIn = new Animation(v => ScoreLabel.Scale = v, 1.1, 1, Easing.SpringIn);

            var parentAnimation = new Animation();

            parentAnimation.Add(0, 0.3, ScoreScalingOut);
            parentAnimation.Add(0.3, 0.6, ScoreSlideOut);
            parentAnimation.Add(0.6, 0.9, ScoreSlideIn);
            parentAnimation.Add(0.9, 1, ScoreScalingIn);

            parentAnimation.Commit(this, "TransitionAnimationScore", 16, 1000, null, (v, c) => { });
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