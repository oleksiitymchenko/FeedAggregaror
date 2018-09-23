using FeedAggregator.Shared.Dtos;
using FeedAggregator.Shared.Requests;
using System.Threading.Tasks;

namespace FeedAggregator.BLL.Interfaces
{
    public interface IFeedService
    {
        Task<FeedDto> AddFeedToUser(FeedRequest request);

        Task<bool> DeleteFeedFromUserAsync(int id);

        Task UpdateFeeds();
    }
}
