﻿using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _dbContext;
        public StoreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<Store> AddStore(Store store)
        {
            _dbContext.Add(store);
            await _dbContext.SaveChangesAsync();
            return store;
        }

        public async Task<bool> DeleteStore(int storeId)
        {
            var storeToDelete = await _dbContext.Stores.FindAsync(storeId);
            if (storeToDelete == null)
                return false;

            _dbContext.Stores.Remove(storeToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Store>> GetAllStores()
        {
            var stores = await _dbContext.Stores.ToListAsync();

            return stores;
        }

        public async Task<Store> GetStoreById(int storeId)
        {
            var store = await _dbContext.Stores.FindAsync(storeId);

            return store;
        }

        public Task<bool> UpdateStore(Store store)
        {
            throw new NotImplementedException();
        }
    }
}