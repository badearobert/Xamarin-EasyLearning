using EinfachDeutsch.Models;
using EinfachDeutsch.Themes;
using EinfachDeutsch.ViewModels;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainSelectionPage : ContentPage
    {
        public int idx = 0;

        private Content_MainTypesViewModel viewModel = new Content_MainTypesViewModel();

        public MainSelectionPage()
        {
            InitializeComponent();
            BindingContext = viewModel;

            ThemeHelper.ChangeTheme("dark");
            SharedTransitionNavigationPage.SetBackgroundAnimation(this, BackgroundAnimation.Fade);
            SharedTransitionNavigationPage.SetTransitionDuration(this, 500);
        }

        private void SetPageAnimation(BackgroundAnimation animation, long time)
        {
            SharedTransitionNavigationPage.SetBackgroundAnimation(this, animation);
            SharedTransitionNavigationPage.SetTransitionDuration(this, time);
        }

        private void QuizCarousel_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            if (e.CurrentItem == null || e.PreviousItem == null) return;
            List<Color> colors = new List<Color>() { Color.Red, Color.Yellow, Color.Blue, Color.Green };
            
            MainSelectionContent.BackgroundColor = colors[idx++ % colors.Count];
        }

        private void LearningCarousel_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            if (e.CurrentItem == null || e.PreviousItem == null) return;
            List<Color> colors = new List<Color>() { Color.Red, Color.Yellow, Color.Blue, Color.Green };
            
            MainSelectionContent.BackgroundColor = colors[idx++ % colors.Count];
        }
        private void OnQuizClicked(object sender, EventArgs e)
        {
            SetPageAnimation(BackgroundAnimation.SlideFromRight, 750);

            Navigation.PushAsync(new QuizPage(viewModel.QuizCurrentItem));
            //QuizCarousel.CurrentItem = null;
        }
        private void OnLearningClicked(object sender, EventArgs e)
        {
            SetPageAnimation(BackgroundAnimation.SlideFromRight, 750);

            Navigation.PushAsync(new LearningPage(viewModel.LearningCurrentItem));
            //LearningCarousel.CurrentItem = null;
        }
    }
}