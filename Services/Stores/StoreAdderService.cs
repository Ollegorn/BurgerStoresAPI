using RepositoryContracts;
using ServiceContracts.DTOs.StoreDtos;
using ServiceContracts.Stores;

namespace Services.Stores
{
    public class StoreAdderService : IStoreAdderService
    {
        private readonly IStoreRepository _repository;

        public StoreAdderService(IStoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<StoreResponseDto> AddStore(StoreAddRequestDto storeAddRequestDTO)
        {
            storeAddRequestDTO.FixStoreBurgerString(storeAddRequestDTO);
            var store = storeAddRequestDTO.ToStore();

            var addedStore = await _repository.AddStore(store);
            var addedStoreToResponse = addedStore.ToStoreResponse();
            return addedStoreToResponse;
        }
    }
}
