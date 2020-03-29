using EinfachDeutsch.ViewModels.Learning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch.Views.LearningType
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LearningType_WordOfTheDayView : ContentView
    {
        public LearningType_WordOfTheDayView()
        {
            InitializeComponent();
            BindingContext = new LearningType_WordOfTheDayViewModel();
        }

        private void ChangeWordOfTheDay(object sender, EventArgs e)
        {
            (BindingContext as LearningType_WordOfTheDayViewModel).GenerateNewWordOfTheDay();
        }

        private void AddToFavorites(object sender, EventArgs e)
        {

        }
    }
}