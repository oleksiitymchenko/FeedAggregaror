using System.Collections.Generic;

namespace FeedAggregator.DAL.Entities
{
    public class Feed:Entity
    {
        public string ChanellUrl { get; set; }

        public int UserCollectionId { get; set; }
        public UserCollection UserCollection { get; set; }

        public IList<FeedItem> FeedItems { get; set; }
    }
}
