using EinfachDeutsch.Models;
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
    public partial class QuizType_AllEntries : ContentView
    {
        List<View> views = new List<View>() 
        {
            new QuizType_TrueFalseView(),
            new QuizType_TranslateWordsView(),
            new QuizType_SelectionView()
        };

        public int oldIndex { get; private set; } = -1;
        public QuizType_AllEntries()
        {
            InitializeComponent();
            (views[0].BindingContext as QuizType_TrueFalseViewModel).QuizQuestionFinished = new Command(Update);
            (views[1].BindingContext as QuizType_TranslateWordsViewModel).QuizQuestionFinished = new Command(Update);
            (views[2].BindingContext as QuizType_SelectionViewModel).QuizQuestionFinished = new Command(Update);

            Update();
        }

        private void Update()
        {
            int newIndex = new Random().Next(views.Count);

            if (newIndex != oldIndex)
            {
                QuizContent.Children.Clear();
                QuizContent.Children.Add(views[newIndex]);
            }
            if (oldIndex != -1) 
                (views[oldIndex].BindingContext as BaseQuiz).OnPause();

            (views[newIndex].BindingContext as BaseQuiz).OnResume();
            (views[newIndex].BindingContext as BaseQuiz).LoadNextQuiz();
            oldIndex = newIndex;
        }

    }
}
