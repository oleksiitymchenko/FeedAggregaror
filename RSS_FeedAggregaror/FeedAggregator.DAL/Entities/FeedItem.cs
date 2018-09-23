using System;

namespace FeedAggregator.DAL.Entities
{
    public class FeedItem: Entity
    {
        public string Link { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public int FeedCollectionId { get; set; }
        public Feed FeedCollection { get; set; }
    }
}
