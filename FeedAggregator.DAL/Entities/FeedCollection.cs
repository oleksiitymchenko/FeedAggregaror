using System.Collections.Generic;

namespace FeedAggregator.DAL.Entities
{
    public class FeedCollection:Entity
    {
        public string ChanellUrl { get; set; }

        public IList<FeedItem> FeedItems { get; set; }
    }
}
