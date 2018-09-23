using System;

namespace FeedAggregator.Shared.Dtos
{
    public class FeedItemDto
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
