using RepositoryContracts;
using ServiceContracts.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stores
{
    public class StoreDeleterService : IStoreDeleterService
    {
        private readonly IStoreRepository _repository;
        public StoreDeleterService(IStoreRepository storeRepository)
        {
            _repository = storeRepository;
        }

        public async Task<bool> DeletStoreById(int storeId)
        {
            var isDeleted = await _repository.DeleteStore(storeId);

            return isDeleted;
        }
    }
}
