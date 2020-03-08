using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static EinfachDeutsch.Views.Custom.TimerView;

namespace EinfachDeutsch.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnswerResultView : ContentView
    {
        public AnswerResultView()
        {
            InitializeComponent();
        }

        public void SetOnTimerExpiredCallback(TimerExpiredHandler callback)
        {
            QuestionCustomTimer.TimerExpired += callback;
        }
        private void TimerExpiredHandler()
        {
            _ = AnimateAnswerImage(false);
        }

        public async Task AnimateAnswerImage(bool is_correct)
        {
            if (this.AnimationIsRunning("TransitionAnimationAnswer")) return;
            await QuestionCustomTimer.StopTimer();

            string answer_correct = "https://cdn.pixabay.com/photo/2012/04/24/13/49/tick-40143_960_720.png";
            string answer_incorrect = "https://cdn.pixabay.com/photo/2012/04/13/00/22/red-31226_960_720.png";

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
            await ShowResult();
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

        public void StartAnimations()
        {
            QuestionCustomTimer.StartAnimations();
        }
    }
}