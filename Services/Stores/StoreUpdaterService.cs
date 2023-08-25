using RepositoryContracts;
using ServiceContracts.DTOs.StoreDtos;
using ServiceContracts.Stores;

namespace Services.Stores
{
    public class StoreUpdaterService : IStoreUpdaterService
    {
        private readonly IStoreRepository _repository;
        public StoreUpdaterService(IStoreRepository storeRepository)
        {
            _repository = storeRepository;
        }

        public async Task<bool> UpdateStore(StoreUpdateRequestDto updateRequestDto)
        {
            updateRequestDto.FixStoreBurgerString(updateRequestDto);

            var store = updateRequestDto.ToStore();

            var updatedStore = await _repository.UpdateStore(store);

            if (updatedStore)
                return true;

            return false;
        }
    }
}
