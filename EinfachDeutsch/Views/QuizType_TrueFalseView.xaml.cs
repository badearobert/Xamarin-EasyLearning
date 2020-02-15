using EinfachDeutsch.ViewModels;
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

        private void CurrentQuestion_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Text")
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

            parentAnimation.Commit(this, "TransitionAnimation", 16, 1000, null, (v, c) => { });
            await Task.Delay(1000);
        }
        private async Task AnimateOut()
        {
            var QuestionFadeOut = new Animation(v => CurrentQuestion.Opacity = v, 1, 0, Easing.SinOut);
            var TrueButttonSlideOut = new Animation(v => TrueButtonContainer.TranslationX = v, 0, -this.Width, Easing.SinOut);
            var FalseButttonSlideOut = new Animation(v => FalseButtonContainer.TranslationX = v, 0, this.Width, Easing.SinOut);

            var parentAnimation = new Animation();
            parentAnimation.Add(0, 0.3, QuestionFadeOut);
            parentAnimation.Add(0.3, 1, TrueButttonSlideOut);
            parentAnimation.Add(0.3, 1, FalseButttonSlideOut);

            parentAnimation.Commit(this, "TransitionAnimation", 16, 1000, null, (v, c) => { });
            await Task.Delay(1000);
        }

    }
}