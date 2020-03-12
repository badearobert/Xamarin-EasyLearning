using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreView : ContentView
    {
        public ScoreView()
        {
            InitializeComponent();
        }
        private void ScoreLabel_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName != "FormattedText")
                return;

             AnimateScoreInOut();
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
    }
}