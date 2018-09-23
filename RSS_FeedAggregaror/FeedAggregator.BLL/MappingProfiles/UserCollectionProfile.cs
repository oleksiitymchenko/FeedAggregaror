using AutoMapper;
using FeedAggregator.DAL.Entities;
using FeedAggregator.Shared.Dtos;

namespace FeedAggregator.BLL.MappingProfiles
{
    public class UserCollectionProfile : Profile
    {
        public UserCollectionProfile()
        {
            CreateMap<UserCollection, UserCollection>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<UserCollection, UserCollectionDto>();       
        }
    }
}
