using EinfachDeutsch.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizType_TrueFalseView : ContentView
    {
        public QuizType_TrueFalseView()
        {
            InitializeComponent();
            BindingContext = new TrueFalseQuiz_ViewModel();
        }
    }
}