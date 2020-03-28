using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using EinfachDeutsch.ViewModels;
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
    public partial class LearningSelectionPage : ContentPage
    {
        public LearningSelectionPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();

            BindingContext = new Content_LearningTypesViewModel();
        }
        private void ItemChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0) return;

            SharedTransitionNavigationPage.SetBackgroundAnimation(this, BackgroundAnimation.SlideFromRight);
            SharedTransitionNavigationPage.SetTransitionDuration(this, 500);

            Navigation.PushAsync(new LearningPage(e.CurrentSelection[0] as LearningType));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}