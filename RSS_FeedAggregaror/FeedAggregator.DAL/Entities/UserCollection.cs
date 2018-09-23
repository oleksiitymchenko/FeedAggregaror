using System.Collections.Generic;

namespace FeedAggregator.DAL.Entities
{
    public class UserCollection: Entity
    {
        public string UserId { get; set; } 

        public IList<Feed> FeedCollections { get; set; }
    }
}
