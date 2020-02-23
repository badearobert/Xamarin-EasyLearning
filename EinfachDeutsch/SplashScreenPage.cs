using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Xamarin.Forms;

namespace EinfachDeutsch
{
    public class SplashScreenPage : ContentPage
    {
        Timer timer = new Timer() { Interval = 7500 };

        Label LoadingLabel = new Label
        {
            Text = "Loading database...",
            TextColor = Color.White,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 30
        };
        public SplashScreenPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            //this.BackgroundColor = Color.FromHex("#404E5A");
            this.BackgroundColor = Color.FromHex("#cc0066");

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star } );
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star } );
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star } );

            grid.Children.Add(LoadingLabel);
            Grid.SetRow(LoadingLabel, 1);

            SplashPageContentView obj = new SplashPageContentView();
            grid.Children.Add(obj);
            Grid.SetRow(obj, 2);
            this.Content = grid;

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await LoadingLabel.ScaleTo(1.1, 2500, Easing.SinIn);
            await LoadingLabel.ScaleTo(0.9, 2500, Easing.SinOut);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            timer.Stop();
        }
    }
}
