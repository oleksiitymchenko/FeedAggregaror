using AutoMapper;
using FeedAggregator.DAL.Data;
using FeedAggregator.DAL.Entities;
using FeedAggregator.DAL.Interfaces;

namespace FeedAggregator.DAL.Repositories
{
    public class FeedItemRepository: Repository<FeedItem>, IFeedItemRepository
    {
        public FeedItemRepository(FeedAggregatorDbContext context, IMapper mapper): base(context, mapper)
        {

        }
    }
}
