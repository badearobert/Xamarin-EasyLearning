using EinfachDeutsch.ViewModels;
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
    public partial class QuizType_TrueFalsePage : ContentPage
    {
        public QuizType_TrueFalsePage()
        {
            InitializeComponent();
            BindingContext = new TrueFalseQuiz_ViewModel();
        }
    }
}