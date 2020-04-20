using EinfachDeutsch.Themes;
using EinfachDeutsch.ViewModels.Learning;
using Plugin.LocalNotifications;
using Plugin.SharedTransitions;
using System;

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

            LoadWordOfTheDay();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ThemeHelper.ChangeTheme("dark");
        }
        private void LoadWordOfTheDay()
        {
            var vm = new LearningType_WordOfTheDayViewModel();
            CrossLocalNotifications.Current.Show("EinfachDeutsch", "Word of the day is " + vm.CurrentEntry.FullEntry, 1, DateTime.Now.AddHours(2));
        }
        private void OnLearningButtonPressed(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new SharedTransitionNavigationPage(new LearningSelectionPage()));
        }
        private void OnQuizButtonPressed(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new SharedTransitionNavigationPage(new QuizSelectionPage()));
        }
        private void OnChallengeButtonPressed(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new SharedTransitionNavigationPage(new ChallengeSelectionPage()));
        }
    }
}