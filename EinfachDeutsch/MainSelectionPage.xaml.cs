using EinfachDeutsch.Themes;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainSelectionPage : ContentPage
    {
        public MainSelectionPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();

            ThemeHelper.ChangeTheme("dark");
            SharedTransitionNavigationPage.SetBackgroundAnimation(this, BackgroundAnimation.Fade);
            SharedTransitionNavigationPage.SetTransitionDuration(this, 500);
        }

        private void OnLearningButtonPressed(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new SharedTransitionNavigationPage(new LearningSelectionPage()));
        }

        private void OnQuizButtonPressed(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new SharedTransitionNavigationPage(new QuizSelectionPage()));
        }
    }
}