using EinfachDeutsch.Models;
using EinfachDeutsch.ViewModels.Learning;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EinfachDeutsch.Views.LearningType
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LearningType_MediaPlayerView : ContentView
    {
        LearningType_MediaPlayerViewModel vm = new LearningType_MediaPlayerViewModel();
        public LearningType_MediaPlayerView()
        {
            InitializeComponent();
            App.database.Delete<MediaLearningEntry>();
            App.database.Add(new MediaLearningEntry() { Description = "Description for the video", Url = "https://sec.ch9.ms/ch9/5d93/a1eab4bf-3288-4faf-81c4-294402a85d93/XamarinShow_mid.mp4" });

            BindingContext = vm;
        }
    }
}