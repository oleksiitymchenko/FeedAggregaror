using System;

namespace FeedAggregator.DAL.Entities
{
    public class FeedItem: Entity
    {
        public string Link { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public FeedCollection FeedCollection { get; set; }
    }
}
