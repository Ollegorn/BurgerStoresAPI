using ServiceContracts.DTOs.StoreDtos;


namespace ServiceContracts.Stores
{
    public interface IStoreGetterService
    {
        /// <summary>
        /// Asks the repository to get all the stores in the database.
        /// </summary>
        /// <returns>A list of <see cref="StoreResponseDto"/>.</returns>
        Task<List<StoreResponseDto>> GetAllStores();


        /// <summary>
        /// Asks the repository to get the store with the spesifci id.
        /// </summary>
        /// <param name="id">The id of the store</param>
        /// <returns>A <see cref="StoreResponseDto"/> object.</returns>
        Task<StoreResponseDto> GetStoreById(int id);
    }
}
