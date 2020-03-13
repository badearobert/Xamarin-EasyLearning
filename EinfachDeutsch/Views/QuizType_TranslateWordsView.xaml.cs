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
        private bool isViewUpToDate = false;
        private TranslateWordsQuiz_ViewModel viewModel = new TranslateWordsQuiz_ViewModel();
        public QuizType_TranslateWordsView()
        {
            InitializeComponent();
            BindingContext = viewModel;
            AnswerResultContainer.SetOnTimerExpiredCallback(OnTimerExpired);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (viewModel.IsPaused) return;
            if (isViewUpToDate) return;
            isViewUpToDate = true;

            bool is_correct = (UserInputField.Text == viewModel.CurrentQuestion.CorrectResult);

            await AnswerResultContainer.AnimateAnswerImage(is_correct);
            viewModel.OnSubmitPressed(UserInputField);
            viewModel.QuizQuestionFinished?.Execute(null);
        }

        private void Label_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (viewModel.IsPaused) return;
            if (e.PropertyName != "Text")
                return;
            isViewUpToDate = false;
            AnswerResultContainer.StartAnimations();
        }
        private void OnTimerExpired()
        {
            Button_Clicked(null, null);
        }
    }
}