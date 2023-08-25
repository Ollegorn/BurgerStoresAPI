using ServiceContracts.DTOs.BurgerDtos;

namespace ServiceContracts.Burgers
{
    public interface IBurgerGetterService
    {
        /// <summary>
        /// Ask the repository to get the burgers for the store with the provided id.
        /// </summary>
        /// <param name="storeId">The id of the store.</param>
        /// <returns>A list of burgers.</returns>
        Task<List<BurgerResponseWithoutIdDto>> GetBurgersForStore(int storeId);
    }
}
