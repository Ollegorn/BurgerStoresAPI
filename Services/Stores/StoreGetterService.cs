using RepositoryContracts;
using ServiceContracts.DTOs.StoreDtos;
using ServiceContracts.Stores;


namespace Services.Stores
{
    public class StoreGetterService : IStoreGetterService
    {
        private readonly IStoreRepository _repository;
        public StoreGetterService(IStoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StoreResponseDto>> GetAllStores()
        {
            var stores = await _repository.GetAllStores();
            var storeResponses = stores.ToStoreResponseList();
            foreach (var store in storeResponses)
            {
                store.IsStoreOpen = store.IsOpen();
            }
            return storeResponses;
        }

        public async Task<StoreResponseDto> GetStoreById(int id)
        {
            var store = await _repository.GetStoreById(id);
            var storeResponseDTO = store.ToStoreResponse();
            storeResponseDTO.IsStoreOpen = storeResponseDTO.IsOpen();
            return storeResponseDTO;
        }
    }
}
