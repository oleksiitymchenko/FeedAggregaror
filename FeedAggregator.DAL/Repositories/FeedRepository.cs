using AutoMapper;
using FeedAggregator.DAL.Data;
using FeedAggregator.DAL.Entities;
using FeedAggregator.DAL.Interfaces;

namespace FeedAggregator.DAL.Repositories
{
    public class FeedRepository: Repository<Feed>, IFeedRepository
    {
        public FeedRepository(FeedAggregatorDbContext context, IMapper mapper):base(context, mapper)
        {

        }
    }
}
