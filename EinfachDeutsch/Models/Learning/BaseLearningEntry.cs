using SQLite;

namespace EinfachDeutsch.Models
{
    [Table("BaseLearningEntry")]
    public class BaseLearningEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Sentence { get; set; } = "";
        public string Translation { get; set; } = "";
        public string Description { get; set; } = "";
    }
    [Table("BasicLearningEntry")]
    public class BasicLearningEntry : BaseLearningEntry { }

    [Table("IdiomLearningEntry")]
    public class IdiomLearningEntry : BaseLearningEntry { }

    [Table("SentenceLearningEntry")]
    public class SentenceLearningEntry : BaseLearningEntry { }

    [Table("ExpressionsLearningEntry")]
    public class ExpressionsLearningEntry : BaseLearningEntry { }


    [Table("MediaLearningEntry")]
    public class MediaLearningEntry
    {
        public string Url { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
