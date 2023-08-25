using ServiceContracts.DTOs.BurgerDtos;

namespace RepositoryContracts
{
    public interface IBurgerRepository
    {
        /// <summary>
        /// Sends a request to BurgerAPI to get all the burgers a spesific store has.
        /// </summary>
        /// <param name="storeId">The store id. </param>
        /// <returns>A list of burgers.</returns>
        Task<List<BurgerResponseWithoutIdDto>> GetBurgers(int storeId);
    }
}
