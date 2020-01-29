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
    public partial class QuizType_TranslateWordsView : ContentView
    {
        public QuizType_TranslateWordsView()
        {
            InitializeComponent();
            BindingContext = new TranslateWordsQuiz_ViewModel();
        }
    }
}