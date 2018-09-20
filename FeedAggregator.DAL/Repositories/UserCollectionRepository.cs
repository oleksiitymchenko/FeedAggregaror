using FeedAggregator.DAL.Entities;
using AutoMapper;
using FeedAggregator.DAL.Data;

namespace FeedAggregator.DAL.Repositories
{
    public class UserCollectionRepository: Repository<UserCollection>
    {
        public UserCollectionRepository(FeedAggregatorDbContext context, IMapper mapper): base(context, mapper)
        {

        }
    }
}
