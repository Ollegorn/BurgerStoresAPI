﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Burgers;
using ServiceContracts.DTOs.StoreDtos;
using ServiceContracts.Stores;
using Services.Stores;

namespace BurgerStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreAdderService _adderService;
        private readonly IStoreGetterService _getterService;
        private readonly IBurgerGetterService _burgerGetterService;
        private readonly IStoreDeleterService _deleterService;
        private readonly IStoreUpdaterService _updaterService;
        public StoresController(IStoreAdderService storeAdderService,IStoreGetterService storeGetterService, IBurgerGetterService burgerGetterService, IStoreDeleterService deleterService,IStoreUpdaterService storeUpdaterService)
        {
            _adderService = storeAdderService;
            _getterService = storeGetterService;
            _burgerGetterService = burgerGetterService;
            _deleterService = deleterService;
            _updaterService = storeUpdaterService;

        }


        /// <summary>
        /// Retrieves all the stores.
        /// </summary>
        /// <returns>A list of <see cref="StoreResponseDto"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<List<StoreResponseDto>>> GetAllStores()
        {
            var stores = await _getterService.GetAllStores();
            foreach (var store in stores)
            {
                store.Burgers = await _burgerGetterService.GetBurgersForStore(store.StoreId);
            }
            return Ok(stores);
        }

        /// <summary>
        /// Retrieves the store with the specified id.
        /// </summary>
        /// <param name="id">The id of the store.</param>
        /// <returns>A <see cref="StoreResponseDto"/>.</returns>
        [HttpGet("{id}")]
        public async Task<StoreResponseDto> GetStoreById(int id)
        {
            var store = await _getterService.GetStoreById(id);

            store.Burgers = await _burgerGetterService.GetBurgersForStore(store.StoreId);

            return store;
        }

        /// <summary>
        /// Adds a new store.
        /// </summary>
        /// <param name="storeAddRequestDTO">The store details.</param>
        /// <returns>The added store.</returns>
        [HttpPost]
        public async Task<ActionResult<StoreResponseDto>> AddStore(StoreAddRequestDto storeAddRequestDTO)
        {
            var addedStore = await _adderService.AddStore(storeAddRequestDTO);

            return CreatedAtAction(nameof(GetStoreById), new { id = addedStore.StoreId }, addedStore);
        }

        /// <summary>
        /// Deletes a store.
        /// </summary>
        /// <param name="id">The id of the store.</param>
        /// <returns>Not found or Deleted Successfully.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStore(int id)
        {
            var isDeleted = await _deleterService.DeletStoreById(id);

            if (!isDeleted)
                return NotFound("Not found");

            
            return Ok("Deleted Successfully");

        }

        /// <summary>
        /// Updates an existing Store.
        /// </summary>
        /// <param name="storeUpdateRequestDto">The id of the store to be updated and the new details.</param>
        /// <returns>Not found or Ok message.</returns>
        [HttpPut("id")]
        public async Task<ActionResult> UpdateBurger(StoreUpdateRequestDto storeUpdateRequestDto)
        {
            //logg
            var updateStore= await _updaterService.UpdateStore(storeUpdateRequestDto);

            if (!updateStore)
                return NotFound("Store doesn't exist");

            return Ok("Updated Successfully");
        }
    }
}
