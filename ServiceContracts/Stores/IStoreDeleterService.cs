using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Stores
{
    public interface IStoreDeleterService
    {
        /// <summary>
        /// Deletes the store with the given id.
        /// </summary>
        /// <param name="storeId">The id of the store to be deleted</param>
        /// <returns>True or false</returns>
        Task<bool> DeletStoreById(int storeId);
    }
}
