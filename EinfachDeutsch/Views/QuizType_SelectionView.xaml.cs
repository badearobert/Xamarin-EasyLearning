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
    public partial class QuizType_SelectionView : ContentView
    {
        private SelectionQuiz_ViewModel viewModel = new SelectionQuiz_ViewModel();
        private bool isViewUpToDate = false;
        public QuizType_SelectionView()
        {
            InitializeComponent();
            BindingContext = viewModel;
            AnswerResultContainer.SetOnTimerExpiredCallback(OnTimerExpired);
        }

        private async void EntireCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewModel.IsPaused || isViewUpToDate) return;
            isViewUpToDate = true;
            var result = "";
            if (sender != null) result = (sender as CollectionView)?.SelectedItem.ToString();
            bool is_correct = result.Equals(viewModel.CurrentQuestion.CorrectResult);
            await AnswerResultContainer.AnimateAnswerImage(is_correct);
            viewModel.OnSelectionChanged();
            viewModel.QuizQuestionFinished?.Execute(null);
        }

        private void Label_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (viewModel.IsPaused) return;
            if (e.PropertyName != "Text")
                return;
            
            AnswerResultContainer.StartAnimations();
            isViewUpToDate = false;
        }
        private void OnTimerExpired()
        {
            EntireCollection_SelectionChanged(null, null);
        }
    }
}