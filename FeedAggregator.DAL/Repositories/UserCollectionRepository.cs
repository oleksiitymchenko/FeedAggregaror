using FeedAggregator.DAL.Entities;
using AutoMapper;
using FeedAggregator.DAL.Data;
using FeedAggregator.DAL.Interfaces;

namespace FeedAggregator.DAL.Repositories
{
    public class UserCollectionRepository: Repository<UserCollection>, IUserCollectionRepository
    {
        public UserCollectionRepository(FeedAggregatorDbContext context, IMapper mapper): base(context, mapper)
        {

        }
    }
}
