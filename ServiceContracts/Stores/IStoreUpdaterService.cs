using ServiceContracts.DTOs.StoreDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Stores
{
    public interface IStoreUpdaterService
    {
        /// <summary>
        /// Updates an existing Store.
        /// </summary>
        /// <param name="StoreUpdateRequestDto">The updated details of the store.</param>
        /// <returns>The updated store.</returns>
        Task<bool> UpdateStore(StoreUpdateRequestDto updateRequestDto);
    }
}
