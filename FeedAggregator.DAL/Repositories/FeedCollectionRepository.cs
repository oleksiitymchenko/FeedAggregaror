using AutoMapper;
using FeedAggregator.DAL.Data;
using FeedAggregator.DAL.Entities;

namespace FeedAggregator.DAL.Repositories
{
    public class FeedCollectionRepository: Repository<FeedCollection>
    {
        public FeedCollectionRepository(FeedAggregatorDbContext context, IMapper mapper):base(context, mapper)
        {

        }
    }
}
