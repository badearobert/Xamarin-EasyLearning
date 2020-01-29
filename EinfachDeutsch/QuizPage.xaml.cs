using EinfachDeutsch.Models;
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
            QuizContent.Children.Clear();

            if (quiz.Name == "True or False")
            {
                QuizContent.Children.Add(new QuizType_TrueFalseView());
            }
            else if (quiz.Name == "Guess the declination")
            {
                QuizContent.Children.Add(new QuizType_SelectionView());
            }
            else if (quiz.Name == "Fill the missing data")
            {
                QuizContent.Children.Add(new QuizType_FillEntryView());
            }
            else if (quiz.Name == "Translate words")
            {
                QuizContent.Children.Add(new QuizType_TranslateWordsView());
            }
            else
            {
                QuizContent.Children.Add(new Label { Text = "Error not found" });
            }
        }
    }
}
