using EinfachDeutsch.Models;
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
            InitializeComponent();
            foreach (View content in QuizContent.Children)
            {
                ((content as ContentView)?.BindingContext as BaseQuiz)?.OnPause();
            }
            QuizContent.Children.Clear();

            View view;
            switch (quiz.Id)
            {
                case 1: view = new QuizType_TrueFalseView(); break;
                case 2: view = new QuizType_SelectionView(); break;
                case 3: view = new QuizType_FillEntryView(); break;
                case 4: view = new QuizType_TranslateWordsView(); break;
                case 5: view = new QuizType_AllEntries(); break;
                default: view = new Label { Text = "Error not found" }; break;
            }
            if (quiz.Id >=1 && quiz.Id < 5)
            {
                ((view as ContentView).BindingContext as BaseQuiz)?.ResetScore();
                ((view as ContentView).BindingContext as BaseQuiz)?.OnResume();
            }
            QuizContent.Children.Add(view);
        }
    }
}
