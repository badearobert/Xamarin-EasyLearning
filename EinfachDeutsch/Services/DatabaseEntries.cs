using EinfachDeutsch.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
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
                var json = wc.DownloadString("https://badearobert.ro/Germana/German_stuff.json");
                Instance.rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                if (Instance.rootObject.version == "1.00") return;
                if (Instance.rootObject.content.Count == 0) return;

                App.database.DeleteAll();

                foreach (Content content in Instance.rootObject.content)
                {
                    if (content.name == "Verbs_mit_preposition" || content.name == "Verbs")
                    {
                        HandleVerbs(content.entries);
                    }
                    else if (content.name == "Nouns" || content.name == "Adverbs")
                    {
                        HandleNouns(content.entries);
                    }
                }
            }
        }

        private void HandleVerbs(List<DatabaseEntry> entries)
        {
            string[] cases = { "N", "G", "D", "A" };
            string[] verb_cases = { "D", "A" };

            string prepositions_choices = "von,auf,mit,uber,um,fur,bei,nach,gegen,zu";
            foreach (DatabaseEntry entry in entries)
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
                    Question = "What is the case for the verb " + entry.Word,
                    CorrectResult = entry.Case,
                    Choices = "N,G,D,A",
                    EntryReferenceId = entry.Id
                });
                App.database.Add(new SelectionQuiz()
                {
                    Question = "What is the preposition for the verb " + entry.Word,
                    CorrectResult = entry.Preposition,
                    Choices = prepositions_choices,
                    EntryReferenceId = entry.Id
                });

                App.database.Add(new TranslateWordsQuiz()
                {
                    Question = "How do you translate this verb? \r\n" + entry.Word,
                    CorrectResult = entry.Translation,
                    EntryReferenceId = entry.Id
                });

                App.database.Add(new TranslateWordsQuiz()
                {
                    Question = "What is the preposition for the verb " + entry.Word,
                    CorrectResult = entry.Preposition,
                    EntryReferenceId = entry.Id
                });
            }
        }
        private void HandleNouns(List<DatabaseEntry> entries)
        {
            string[] articles = { "der", "die", "das" };

            foreach (DatabaseEntry entry in entries)
            {
                App.database.Add(entry);

                string random_article = Convert.ToString(articles[(new Random()).Next(3)]);
                App.database.Add(new TrueFalseQuiz()
                {
                    Question = "The article for " + entry.Word + " is " + random_article,
                    Answer = (random_article == entry.Article),
                    EntryReferenceId = entry.Id
                });

                App.database.Add(new SelectionQuiz()
                {
                    Question = "What is the article for the noun " + entry.Word,
                    CorrectResult = entry.Article,
                    Choices = "der,die,das",
                    EntryReferenceId = entry.Id
                });
                App.database.Add(new SelectionQuiz()
                {
                    Question = "What is the article for the noun " + entry.Word,
                    CorrectResult = entry.Article,
                    Choices = "der,die,das",
                    EntryReferenceId = entry.Id
                });

                App.database.Add(new TranslateWordsQuiz()
                {
                    Question = "How do you translate this noun? \r\n" + entry.Word,
                    CorrectResult = entry.Translation,
                    EntryReferenceId = entry.Id
                });
            }
        }
    }
}
