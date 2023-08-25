using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Burgers;
using ServiceContracts.DTOs.BurgerDtos;

namespace BurgerStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurgerController : ControllerBase
    {
        private readonly IBurgerGetterService _getterService;
        public BurgerController(IBurgerGetterService burgerGetterService)
        {
            _getterService = burgerGetterService;
        }
        
        /// <summary>
        /// Retrieves all the burgers of store with the specified id.
        /// </summary>
        /// <param name="storeId">The store id.</param>
        /// <returns>A list of <see cref="BurgerResponseWithoutIdDto"/>.</returns>
        [HttpGet]
        public async Task<List<BurgerResponseWithoutIdDto>> GetAllBurgersForStore(int storeId)
        {
            var burgers = await _getterService.GetBurgersForStore(storeId);


            return burgers;

        }
    }
}
