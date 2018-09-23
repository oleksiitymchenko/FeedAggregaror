using AutoMapper;
using FeedAggregator.DAL.Entities;
using FeedAggregator.Shared.Dtos;

namespace FeedAggregator.BLL.MappingProfiles
{
    public class FeedProfile: Profile
    {
        public FeedProfile()
        {
            CreateMap<Feed, Feed>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<Feed, FeedDto>();

            CreateMap<FeedDto, Feed>();
        }
    }
}
