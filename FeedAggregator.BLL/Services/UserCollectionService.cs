using AutoMapper;
using FeedAggregator.BLL.Interfaces;
using FeedAggregator.DAL.Entities;
using FeedAggregator.DAL.Interfaces;
using FeedAggregator.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FeedAggregator.BLL.Services
{
    public class UserCollectionService : IUserCollectionService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UserCollectionService(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        public async Task<UserCollectionDto> CreateUserCollectionAsync()
        {
            var entity = new UserCollection()
            {
                UserId = Guid.NewGuid().ToString()
            };

            var result = await uow.UserCollectionRepository.CreateAsync(entity);
            if (result == null) return null;
            await uow.SaveAsync();
            return mapper.Map<UserCollection, UserCollectionDto>(result);
        }

        public async Task<bool> DeleteUserCollectionAsync(int id)
        {
            var result = await uow.UserCollectionRepository.DeleteAsync(id);
            await uow.SaveAsync();
            return result;
        }

        public async Task<UserCollectionDto> GetUserCollectionByUserIdAsync(string id)
        {
            var entity = await uow.UserCollectionRepository
                                  .GetFirstOrDefaultAsync(
                                      predicate: u => u.UserId == id,
                                      include: uc => uc.Include(u => u.FeedCollections));

            if (entity == null) return null;

            return mapper.Map<UserCollection, UserCollectionDto>(entity);
        }
    }
}
