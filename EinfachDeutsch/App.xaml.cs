using EinfachDeutsch.Models;
using EinfachDeutsch.Services;
using Newtonsoft.Json;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;

namespace EinfachDeutsch
{
    public partial class App : Application
    {
        public static DatabaseService database { get; private set; }
        public App(string fullPath_db)
        {
            InitializeComponent();
            database = new DatabaseService(fullPath_db);

            //AddDatabaseEntries();
            MainPage = new SharedTransitionNavigationPage(new MainPage());
        }

        private void AddDatabaseEntries()
        {
            database.DeleteAll();

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://badearobert.ro/Germana/German_stuff.json");
                var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                if (rootObject.content.Count == 0) return;
                foreach (Content content in rootObject.content)
                {
                    if (content.name == "Verbs_mit_preposition")
                    {
                        HandleVerbs(content.entries);
                    }
                    else if (content.name == "Nouns")
                    {
                        HandleNouns(content.entries);
                    }
                }
            }

            /*
            database.Add(new FillEntryQuiz() { Question = "Fill entry question. Answer is: abc", CorrectResult = "abc" });
            database.Add(new FillEntryQuiz() { Question = "Fill entry question. Answer is: nah", CorrectResult = "nah" });
            */
        }

        private void HandleVerbs(List<Services.Entry> entries)
        {
            string[] cases = { "N", "G", "D", "A" };
            string[] verb_cases = { "D", "A" };

            string prepositions_choices = "von,auf,mit,uber,um,fur,bei,nach,gegen,zu";
            foreach (Services.Entry entry in entries)
            {
                string picked_verb_case = Convert.ToString(verb_cases[(new Random()).Next(2)]);
                database.Add(new TrueFalseQuiz()
                {
                    Question = entry.Word + " " + entry.Preposition + " + " + picked_verb_case + " ?",
                    Answer = (picked_verb_case == entry.Case)
                });

                database.Add(new SelectionQuiz()
                {
                    Question = "What is the case for the verb " + entry.Word,
                    CorrectResult = entry.Case,
                    Choices = "N,G,D,A"
                });
                database.Add(new SelectionQuiz()
                {
                    Question = "What is the preposition for the verb " + entry.Word,
                    CorrectResult = entry.Preposition,
                    Choices = prepositions_choices
                });

                database.Add(new TranslateWordsQuiz()
                {
                    Question = "How do you translate this verb? \r\n" + entry.Word,
                    CorrectResult = entry.Translation
                });

                database.Add(new TranslateWordsQuiz()
                {
                    Question = "What is the preposition for the verb " + entry.Word,
                    CorrectResult = entry.Preposition
                });
            }
        }
        private void HandleNouns(List<Services.Entry> entries)
        {
            string[] articles = { "der", "die", "das" };

            foreach (Services.Entry entry in entries)
            {
                string random_article = Convert.ToString(articles[(new Random()).Next(3)]);
                database.Add(new TrueFalseQuiz()
                {
                    Question = "The article for " + entry.Word + " is " + random_article,
                    Answer = (random_article == entry.Article)
                });

                database.Add(new SelectionQuiz()
                {
                    Question = "What is the article for the noun " + entry.Word,
                    CorrectResult = entry.Article,
                    Choices = "der,die,das"
                });
                database.Add(new SelectionQuiz()
                {
                    Question = "What is the article for the noun " + entry.Word,
                    CorrectResult = entry.Article,
                    Choices = "der,die,das"
                });

                database.Add(new TranslateWordsQuiz()
                {
                    Question = "How do you translate this noun? \r\n" + entry.Word,
                    CorrectResult = entry.Translation
                });
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
