using AutoMapper;
using FeedAggregator.BLL.Interfaces;
using FeedAggregator.DAL.Entities;
using FeedAggregator.DAL.Interfaces;
using FeedAggregator.Shared.Dtos;
using FeedAggregator.Shared.Requests;
using FeedParser;
using FeedParser.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<FeedDto> AddFeedToUser(FeedRequest request)
        {
            var items = await parser.Parse(request.ChanellUrl, request.FeedType);
            if (items == null) throw new Exception("Bad request");

            var userCollection = await uow.UserCollectionRepository
                                          .GetFirstOrDefaultAsync(
                                              predicate: o => o.UserId == request.UserId, 
                                              include: o => o.Include(s => s.FeedCollections));
            if(userCollection == null)
            {
                userCollection = await uow.UserCollectionRepository.CreateAsync(new UserCollection { UserId = request.UserId });
            }

            var feed = await uow.FeedRepository
                                .CreateAsync(new Feed()
                                {
                                    ChanellUrl = request.ChanellUrl,
                                    UserCollectionId = userCollection.Id,
                                });

            items.ToList().ForEach(async item => {
                var newFeedItem = mapper.Map<Item, FeedItem>(item);
                newFeedItem.FeedCollectionId = feed.Id;
                await uow.FeedItemRepository.CreateAsync(newFeedItem);
            });
            await uow.SaveAsync();

            return mapper.Map<Feed,FeedDto>(feed);
        }

        public async Task<bool> DeleteFeedFromUserAsync(int id)
        {
            var result = await uow.FeedRepository.DeleteAsync(id);
            await uow.SaveAsync();
            return result;
        }

        public Task UpdateFeeds()
        {
            Console.WriteLine("FEEDSERVICE");
            Console.WriteLine("FEEDSERVICE");
            Console.WriteLine("FEEDSERVICE");
            Console.WriteLine("FEEDSERVICE");
            Console.WriteLine("FEEDSERVICE");
            return Task.FromResult<object>(null);
        }
    }
}
