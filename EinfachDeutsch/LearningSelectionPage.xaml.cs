using EinfachDeutsch.Services;
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
            LearningContent.Children.Clear();

            View view = LearningTypeService.Instance.CreateFrom(0);
            if (view != null)
            {
                LearningContent.Children.Add(view);
            }
        }
    }
}