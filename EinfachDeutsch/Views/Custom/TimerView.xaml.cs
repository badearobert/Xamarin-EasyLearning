using EinfachDeutsch.Custom;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerView : ContentView
    {
        private bool _wasCancelled = false;
        public delegate void TimerExpiredHandler();
        public event TimerExpiredHandler TimerExpired;
        public void RaiseEventTimerExpired()
        {
            if (false == _wasCancelled)
            {
                TimerExpired?.Invoke();
            }
            _wasCancelled = false;
        }
        public int MaxTimerWidth { get; set; }
        public TimerView()
        {
            MaxTimerWidth = App.ScreenWidth;
            InitializeComponent();
        }
        public async void StartAnimations()
        {
            if (this.AnimationIsRunning("TimerAnimation"))
            {
                return;
            }
            TimerPanel.WidthRequest = 50;
            TimerPanel.Scale = 0;

            int delay = 300;
            var anim = new Animation();
            anim.Add(0, 0.8, new Animation(t => { TimerPanel.Scale = t; }, 0, 1, Easing.SinInOut));
            anim.Add(0.7, 1.0, new Animation(t => { TimerPanel.WidthRequest = t; }, 50, MaxTimerWidth, Easing.SinInOut));
            anim.Commit(this, "TimerAnimation", 16, (uint)delay, null, (v, c) => StartTimerAsync() );
            await Task.Delay(delay);
        }

        public async Task StartTimerAsync()
        {
            if (this.AnimationIsRunning("TimerAnimation"))
            {
                return;
            }
            TimerPanel.BackgroundColor = Color.LightGreen;
            uint total_time = 15000;
            var anim = new Animation();
            anim.Add(0, 1.0, new Animation(t => { TimerPanel.WidthRequest = t; }, MaxTimerWidth, 0, Easing.SinInOut));

            anim.Commit(this, "TimerAnimation", 16, total_time, null, (v, c) => RaiseEventTimerExpired() );

            await TimerPanel.ColorTo(Color.LightGreen, Color.Yellow, c => TimerPanel.BackgroundColor = c, 5000);
            await TimerPanel.ColorTo(Color.Yellow, Color.Red, c => TimerPanel.BackgroundColor = c, 3000);
            await TimerPanel.ColorTo(Color.Red, Color.DarkRed, c => TimerPanel.BackgroundColor = c, 7000);
        }
        private async Task SetTimerToZeroAsync()
        {
            int delay = 500;
            var anim = new Animation();
            anim.Add(0, 1.0, new Animation(t => { TimerPanel.WidthRequest = t; }, TimerPanel.WidthRequest, 0, Easing.SinIn));

            anim.Commit(this, "TimerAnimation", 16, (uint)delay);
            await TimerPanel.ColorTo(Color.LightGreen, Color.Yellow, c => TimerPanel.BackgroundColor = c, 150);
            await TimerPanel.ColorTo(Color.Yellow, Color.Red, c => TimerPanel.BackgroundColor = c, 150);
            await TimerPanel.ColorTo(Color.Red, Color.DarkRed, c => TimerPanel.BackgroundColor = c, 200);
            await Task.Delay(delay);
        }
        public async Task StopTimer()
        {
            if (this.AnimationIsRunning("TimerAnimation"))
            {
                _wasCancelled = true;
                this.AbortAnimation("TimerAnimation");
                await SetTimerToZeroAsync();
            }
        }
    }
}