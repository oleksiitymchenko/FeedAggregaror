using AutoMapper;
using FeedAggregator.DAL.Data;
using FeedAggregator.DAL.Entities;

namespace FeedAggregator.DAL.Repositories
{
    public class FeedItemRepository: Repository<FeedItem>
    {
        public FeedItemRepository(FeedAggregatorDbContext context, IMapper mapper): base(context, mapper)
        {

        }
    }
}
