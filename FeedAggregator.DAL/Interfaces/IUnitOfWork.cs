using System;
using System.Threading.Tasks;

namespace FeedAggregator.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveAsync();

        IUserCollectionRepository UserCollectionRepository { get; }
        IFeedRepository FeedRepository { get; }
        IFeedItemRepository FeedItemRepository { get; }
    }
}
