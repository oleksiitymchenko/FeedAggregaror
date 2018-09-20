using AutoMapper;
using FeedAggregator.DAL.Data;
using FeedAggregator.DAL.Interfaces;
using FeedAggregator.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace FeedAggregator.DAL
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        public UnitOfWork(FeedAggregatorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private FeedAggregatorDbContext _context;
        private IMapper _mapper;
        private IUserCollectionRepository _userCollectionRepository;
        private IFeedRepository _feedCollectionRepository;
        private IFeedItemRepository _feedItemRepository;

        public IUserCollectionRepository UserCollectionRepository => _userCollectionRepository ?? (_userCollectionRepository = new UserCollectionRepository(_context, _mapper));

        public IFeedRepository FeedCollectionRepository => _feedCollectionRepository ?? (_feedCollectionRepository = new FeedRepository(_context, _mapper));

        public IFeedItemRepository FeedItemRepository => _feedItemRepository ?? (_feedItemRepository = new FeedItemRepository(_context, _mapper));

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~IUnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
