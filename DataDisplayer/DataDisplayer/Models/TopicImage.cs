using System.Collections.Generic;

namespace DataDisplayer.Models
{
    public class TopicImage
    {
        public int TopicId { get; set; }
        public string FileName { get; set; }
        public string AltText { get; set; }
        public int Position { get; set; } // For ordering multiple images per topic
    }
}
