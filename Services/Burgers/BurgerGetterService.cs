using RepositoryContracts;
using ServiceContracts.Burgers;
using ServiceContracts.DTOs.BurgerDtos;

namespace Services.Burgers
{
    public class BurgerGetterService : IBurgerGetterService
    {
        private readonly IBurgerRepository _repository; 
        public BurgerGetterService(IBurgerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BurgerResponseWithoutIdDto>> GetBurgersForStore(int storeId)
        {
            var burgersResponse = await _repository.GetBurgers(storeId);


            return burgersResponse;

        }
    }
}
