using EinfachDeutsch.Models;
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
    public partial class LearningPage : ContentPage
    {
        public LearningPage(LearningType type)
        {
            InitializeComponent();
            LearningContent.Children.Clear();
            LearningContent.Children.Add(type.View);
    }
}