using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace EinfachDeutsch.Droid
{
    [Activity(Theme= "@style/SplashScreenTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
        }
        protected override void OnResume()
        { 
            base.OnResume();
            StartMainActivity(); 
        }
        async void StartMainActivity()
        {
            await Task.Run(() => {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            });
        }
    }
}