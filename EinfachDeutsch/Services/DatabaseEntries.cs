using EinfachDeutsch.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace EinfachDeutsch.Services
{
    public class DatabaseEntries
    {
        private static DatabaseEntries _instance;
        public static DatabaseEntries Instance
        {
            get
            {
                if (_instance == null) _instance = new DatabaseEntries();
                return _instance;
            }
        }
        public RootObject rootObject;


        public async void ResetDatabaseEntries()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(App.Configuration.Webpage);
                Instance.rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                if (Instance.rootObject.version == App.Configuration.DataVersion) return;
                App.Configuration.SetVersion(Instance.rootObject.version);

                if (Instance.rootObject.content.Count == 0) return;

                App.database.DeleteAll();
                HandleQuizEntries(Instance.rootObject.content);
                HandleBasics(Instance.rootObject.basic_learning_content);
            }
        }
    
        private void HandleQuizEntries(List<Content> entries)
        {
            foreach (Content entry in entries)
            {
                switch (entry.name)
                {
                    case "Verbs_mit_preposition":
                    case "Verbs":
                        {
                            HandleVerbs(entry.entries);
                            break;
                        }
                    case "Nouns":
                    case "Adverbs":
                        {
                            HandleNouns(entry.entries);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void HandleBasics(List<BasicContent> entries)
        {

            foreach (BasicContent entry in entries)
            {
                
                switch (entry.name)
                {
                    case "Basics":
                        entry.entries.ForEach(
                            item => App.database.Add(new BasicLearningEntry() { Sentence = item.Sentence, Translation = item.Translation }));
                        break;
                    case "Expressions":
                        entry.entries.ForEach(
                            item => App.database.Add(new ExpressionsLearningEntry() { Sentence = item.Sentence, Translation = item.Translation }));
                        break;
                    case "Sentences":
                        entry.entries.ForEach(
                            item => App.database.Add(new SentenceLearningEntry() { Sentence = item.Sentence, Translation = item.Translation }));
                        break;
                    case "Idioms":
                        entry.entries.ForEach(
                            item => App.database.Add(new IdiomLearningEntry() { Sentence = item.Sentence, Translation = item.Translation, Description = item.Description }));
                        break;

                    default:
                        break;
                }

            }
        }
    
        private void HandleVerbs(List<QuizDatabaseEntry> entries)
        {
            string[] cases = { "N", "G", "D", "A" };
            string[] verb_cases = { "D", "A" };

            string prepositions_choices = "von,auf,mit,uber,um,fur,bei,nach,gegen,zu";
            foreach (QuizDatabaseEntry entry in entries)
            {
                App.database.Add(entry);

                string picked_verb_case = Convert.ToString(verb_cases[(new Random()).Next(2)]);
                App.database.Add(new TrueFalseQuiz()
                {
                    Question = entry.Word + " " + entry.Preposition + " + " + picked_verb_case + " ?",
                    Answer = (picked_verb_case == entry.Case),
                    EntryReferenceId = entry.Id
                });

                App.database.Add(new SelectionQuiz()
                {
                    Question = "What is the case for this verb ?\r\n" + entry.Word,
                    CorrectResult = entry.Case,
                    Choices = "N,G,D,A",
                    EntryReferenceId = entry.Id
                });
                App.database.Add(new SelectionQuiz()
                {
                    Question = "What is the preposition for this verb ?\r\n" + entry.Word,
                    CorrectResult = entry.Preposition,
                    Choices = prepositions_choices,
                    EntryReferenceId = entry.Id
                });

                App.database.Add(new TranslateWordsQuiz()
                {
                    Question = "How do you translate this verb ?\r\n" + entry.Word,
                    CorrectResult = entry.Translation,
                    EntryReferenceId = entry.Id
                });

                App.database.Add(new TranslateWordsQuiz()
                {
                    Question = "What is the preposition for this verb ?\r\n" + entry.Word,
                    CorrectResult = entry.Preposition,
                    EntryReferenceId = entry.Id
                });
            }
        }
        private void HandleNouns(List<QuizDatabaseEntry> entries)
        {
            string[] articles = { "der", "die", "das" };

            foreach (QuizDatabaseEntry entry in entries)
            {
                App.database.Add(entry);

                string random_article = Convert.ToString(articles[(new Random()).Next(3)]);
                App.database.Add(new TrueFalseQuiz()
                {
                    Question = "The article for " + entry.Word + " is...? \r\n" + random_article,
                    Answer = (random_article == entry.Article),
                    EntryReferenceId = entry.Id
                });

                App.database.Add(new SelectionQuiz()
                {
                    Question = "What is the article for this noun ?\r\n" + entry.Word,
                    CorrectResult = entry.Article,
                    Choices = "der,die,das",
                    EntryReferenceId = entry.Id
                });
                App.database.Add(new SelectionQuiz()
                {
                    Question = "What is the article for this noun ?\r\n" + entry.Word,
                    CorrectResult = entry.Article,
                    Choices = "der,die,das",
                    EntryReferenceId = entry.Id
                });

                App.database.Add(new TranslateWordsQuiz()
                {
                    Question = "How do you translate this noun ?\r\n" + entry.Word,
                    CorrectResult = entry.Translation,
                    EntryReferenceId = entry.Id
                });
            }
        }
    }
}
