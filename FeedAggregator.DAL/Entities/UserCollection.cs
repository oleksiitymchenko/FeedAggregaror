using System.Collections.Generic;

namespace FeedAggregator.DAL.Entities
{
    public class UserCollection: Entity
    {
        public string UserId { get; set; } //uId that firebase will return 

        public IList<FeedCollection> FeedCollections { get; set; }
    }
}
