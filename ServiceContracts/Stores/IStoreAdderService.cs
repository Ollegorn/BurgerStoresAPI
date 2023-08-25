using ServiceContracts.DTOs.StoreDtos;

namespace ServiceContracts.Stores
{
    public interface IStoreAdderService
    {
        /// <summary>
        /// Adds a new store.
        /// </summary>
        /// <param name="storeAddRequestDto">The store details.</param>
        /// <returns>A <see cref="StoreResponseDto"/>.</returns>
        Task<StoreResponseDto> AddStore(StoreAddRequestDto storeAddRequestDto);
    }
}