using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using EinfachDeutsch.ViewModels;
using EinfachDeutsch.Views;
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
    public partial class QuizPage : ContentPage
    {
        public QuizPage(QuizType quiz)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            Clear();

            if (quiz.View != null)
            {
                ((quiz.View as ContentView).BindingContext as BaseQuiz)?.ResetScore();
                ((quiz.View as ContentView).BindingContext as BaseQuiz)?.OnResume();
                QuizContent.Children.Add(quiz.View);
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Clear();
        }
        public void Clear()
        {
            foreach (View content in QuizContent.Children)
            {
                ((content as ContentView)?.BindingContext as BaseQuiz)?.OnPause();
            }
            QuizContent.Children.Clear();
        }
    }
}
