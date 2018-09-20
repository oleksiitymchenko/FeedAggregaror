using System.Collections.Generic;

namespace FeedAggregator.Shared.Dtos
{
    public class UserCollectionDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public IList<FeedDto> FeedCollections { get; set; }
    }
}
