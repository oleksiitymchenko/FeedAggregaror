﻿using FeedAggregator.Shared.Dtos;
using System.Threading.Tasks;

namespace FeedAggregator.BLL.Interfaces
{
    public interface IUserCollectionService
    {
        Task<UserCollectionDto> GetUserCollectionByUserIdAsync(string id);

        Task<UserCollectionDto> CreateUserCollectionAsync();

        Task<bool> DeleteUserCollectionAsync(int id);
    }
}
