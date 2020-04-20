using Xamarin.Forms;

namespace EinfachDeutsch.Models
{
    public class QuizType
    {
        public int Id { get; set; }
        public string BackgroundColor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public View View { get; set; }
    }
}
