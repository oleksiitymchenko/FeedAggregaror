﻿using FeedParser.Entities;

namespace FeedAggregator.Shared.Requests
{
    public class FeedRequest
    {
        public string UserId { get; set; }
        public string ChanellUrl { get; set; }
        public FeedType FeedType { get; set; }
    }
}
