using EinfachDeutsch.Models.Challenges;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EinfachDeutsch.ViewModels.Challenges
{
    class Challenge_BasicViewModel : BindableObject
    {
        private int CurrentIndex = 0;
        private List<BaseChallengeEntry> Entries = null;
        private BaseChallengeEntry _currentEntry = null;

        public BaseChallengeEntry CurrentEntry
        {
            get { return _currentEntry; }
            set
            {
                _currentEntry = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadButtonPressed { get; set; }
        public Challenge_BasicViewModel()
        {
            LoadData();
            LoadButtonPressed = new Command(OnLoadButtonPressed);
        }

        protected virtual void LoadData()
        {
            Entries = new List<BaseChallengeEntry>()
            {
                new BaseChallengeEntry() { Name = "Reading Challenge 1", Description = "Read along a chapteer of an audiobook, or another piece of writing with accompanying audio"},
                new BaseChallengeEntry() { Name = "Writing Challenge 1", Description = "Choose a photo and describe it in as much detail as you can"},
                new BaseChallengeEntry() { Name = "Listening Challenge 1", Description = "Watch a videeo with narration that describes it, such as a nature documentary or instructional video"},
                new BaseChallengeEntry() { Name = "Speaking Challenge 1", Description = "Take a movie and start explaining what happened in it"},
                new BaseChallengeEntry() { Name = "Vocabulary Challenge 1", Description = "Choose a song in your target language, and look up and study any unfamiliar words in it"},

                new BaseChallengeEntry() { Name = "Reading Challenge 2", Description = "Play a video game in your target language"},
                new BaseChallengeEntry() { Name = "Writing Challenge 2", Description = "Write instructions on how to do something you know how to do"},
                new BaseChallengeEntry() { Name = "Listening Challenge 2", Description = "Find an online stream of a radio station, pay attention to both the music and what the announcers say"},
                new BaseChallengeEntry() { Name = "Speaking Challenge 2", Description = "Listen to a piece of audio and try to repeat wwhat you hear."},
                new BaseChallengeEntry() { Name = "Vocabulary Challenge 2", Description = "Create a vocabulary list post, including words you are studying as well as any related words you already know."},

                new BaseChallengeEntry() { Name = "Reading Challenge 3", Description = "Talk with someone via text with someone else learning your target language, or a native speaker learning your language"},
                new BaseChallengeEntry() { Name = "Writing Challenge 3", Description = "Write a summary of something you've read in your target language."},
                new BaseChallengeEntry() { Name = "Listening Challenge 3", Description = "Watch a video demonstrating a craft project, recipe or other task and follow the instructions."},
                new BaseChallengeEntry() { Name = "Speaking Challenge 3", Description = "Explain to someone, or record yourself explaining, how to do something."},
                new BaseChallengeEntry() { Name = "Vocabulary Challenge 3", Description = "Try to write a small story or other piece of writing using as many of your vocab wwords as you can."},

                new BaseChallengeEntry() { Name = "Reading Challenge 4", Description = "Read an article or a chapter of a book in your target language."},
                new BaseChallengeEntry() { Name = "Writing Challenge 4", Description = "Write a small story in your target language."},
                new BaseChallengeEntry() { Name = "Listening Challenge 4", Description = "Exchange audio wiwth someone else learning your target language, or a native speaker learning  your language."},
                new BaseChallengeEntry() { Name = "Speaking Challenge 4", Description = "Read out loud something in your target language."},
                new BaseChallengeEntry() { Name = "Vocabulary Challenge 4", Description = "Make a list with 5 vocab wwords and create a sentence containing all of them."},

                new BaseChallengeEntry() { Name = "Reading Challenge 5", Description = "-"},
                new BaseChallengeEntry() { Name = "Writing Challenge 5", Description = "-"},
                new BaseChallengeEntry() { Name = "Listening Challenge 5", Description = "Watch a dubbed piece of movie you're familiar with."},
                new BaseChallengeEntry() { Name = "Speaking Challenge 5", Description = "Tell a story"},
                new BaseChallengeEntry() { Name = "Vocabulary Challenge 5", Description = "-"},
            };
            CurrentEntry = Entries[CurrentIndex];
        }

        private void OnLoadButtonPressed()
        {
            CurrentIndex = (CurrentIndex + 1) % Entries.Count;
            CurrentEntry = Entries[CurrentIndex];
        }
    }
}
