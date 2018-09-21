using AutoMapper;
using FeedAggregator.BLL.Interfaces;
using FeedAggregator.DAL.Interfaces;
using FeedAggregator.Shared.Dtos;
using FeedAggregator.Shared.Requests;
using FeedParser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FeedAggregator.BLL.Services
{
    public class FeedService : IFeedService
    {
        public FeedService(IUnitOfWork unitOfWork, IMapper automapper, ItemsParser itemsParser)
        {
            uow = unitOfWork;
            mapper = automapper;
            parser = itemsParser;
        }

        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ItemsParser parser;

        public Task<FeedDto> AddFeedToUser(FeedRequest request)
        {
            
            
        }

        public Task<bool> DeleteFeedFromUser(FeedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
