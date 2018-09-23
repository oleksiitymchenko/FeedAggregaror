using System.Collections.Generic;

namespace FeedAggregator.Shared.Dtos
{
    public class FeedDto
    {
        public int Id { get; set; }

        public string ChanellUrl { get; set; }

        public IList<FeedItemDto> FeedItems { get; set; }

    }
}
