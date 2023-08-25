using Entities;

namespace RepositoryContracts
{
    public interface IStoreRepository
    {
        /// <summary>
        /// Adds a store to the repository.
        /// </summary>
        /// <param name="store">The store to add.</param>
        /// <returns>The added store object.</returns>
        Task<Store> AddStore(Store store);


        /// <summary>
        /// Updates a store in the repository.
        /// </summary>
        /// <param name="store">The updated store.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        Task<bool> UpdateStore(Store store);


        /// <summary>
        /// Deletes a store from the repository based on its store ID.
        /// </summary>
        /// <param name="storeId">The ID of the store to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        Task<bool> DeleteStore(int storeId);


        /// <summary>
        /// Retrieves a store from the repository based on its store ID.
        /// </summary>
        /// <param name="storeId">The ID of the store.</param>
        /// <returns>The store matching the store ID, or null if not found.</returns>
        Task<Store> GetStoreById(int storeId);


        /// <summary>
        /// Retrieves all stores from the repository.
        /// </summary>
        /// <returns>A list of stores.</returns>
        Task<List<Store>> GetAllStores();
    }
}