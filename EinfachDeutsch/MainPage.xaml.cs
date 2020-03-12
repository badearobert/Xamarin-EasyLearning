using EinfachDeutsch.Models;
using EinfachDeutsch.Themes;
using EinfachDeutsch.ViewModels;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EinfachDeutsch
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Content_QuizTypesViewModel();
            ThemeHelper.ChangeTheme("dark");
        }

        private void SetPageAnimation(BackgroundAnimation animation, long time)
        {
            SharedTransitionNavigationPage.SetBackgroundAnimation(this, animation);
            SharedTransitionNavigationPage.SetTransitionDuration(this, time);
        }

        private void QuizChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0) return;

            SetPageAnimation(BackgroundAnimation.SlideFromRight, 300);
            Navigation.PushAsync(new QuizPage(e.CurrentSelection[0] as QuizType));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
