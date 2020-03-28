using EinfachDeutsch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LearningType_IdiomsView : ContentView
    {
        public LearningType_IdiomsView()
        {
            InitializeComponent();
            BindingContext = new LearningType_IdiomsViewModel();
        }
    }
}