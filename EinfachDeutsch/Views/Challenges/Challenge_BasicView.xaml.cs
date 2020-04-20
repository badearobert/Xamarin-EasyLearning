using EinfachDeutsch.ViewModels.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch.Views.Challenges
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Challenge_BasicView : ContentView
    {
        public Challenge_BasicView()
        {
            InitializeComponent();
            BindingContext = new Challenge_BasicViewModel();
        }
    }
}