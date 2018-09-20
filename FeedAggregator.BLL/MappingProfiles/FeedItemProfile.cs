using AutoMapper;
using FeedAggregator.DAL.Entities;
using FeedAggregator.Shared.Dtos;

namespace FeedAggregator.BLL.MappingProfiles
{
    public class FeedItemProfile: Profile
    {
        public FeedItemProfile()
        {
            CreateMap<FeedItem, FeedItem>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<FeedItem, FeedItemDto>();                
        }
    }
}
