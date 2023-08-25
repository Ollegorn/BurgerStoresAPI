using Entities;
using ServiceContracts.DTOs.BurgerDtos;


namespace ServiceContracts.DTOs.StoreDtos
{
    public class StoreResponseDto
    {
        public int StoreId { get; set; }

        public string? StoreName { get; set; }

        public string? StoreLocation { get; set; }

        public string? StorePhoneNumber { get; set; }

        public bool IsStoreOpen { get; set; }

        public List<BurgerResponseWithoutIdDto>? Burgers { get; set; }

        /// <summary>
        /// Converts the <see cref="StoreResponseDto"/> object to an <see cref="Store"/> object.
        /// </summary>
        /// <returns>The converted <see cref="Store"/> object.</returns>
        public Store ToStore()
        {
            return new Store
            {
                StoreId = StoreId,
                StoreName = StoreName,
                StoreLocation = StoreLocation,
                StorePhoneNumber = StorePhoneNumber,
                IsStoreOpen = IsStoreOpen
            };
        }
        public bool IsOpen()
        {
            var date = DateTime.UtcNow;
            var time = date.Hour;
            if (time >= 20 && time <= 9)
                return false;
            return true;
        }

    }

    /// <summary>
    /// Provides extension methods for <see cref="Store"/> objects.
    /// </summary>
    public static class StoreExtensions
    {
        /// <summary>
        /// Converts an <see cref="Store"/> object to an <see cref="StoreResponseDto"/> object.
        /// </summary>
        /// <param name="store">The <see cref="Store"/> object to convert.</param>
        /// <returns>An <see cref="StoreResponseDto"/> object.</returns>
        public static StoreResponseDto ToStoreResponse(this Store store)
        {
            return new StoreResponseDto
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                StoreLocation = store.StoreLocation,
                StorePhoneNumber = store.StorePhoneNumber,
                IsStoreOpen = store.IsStoreOpen
            };
        }

        /// <summary>
        /// Converts a list of <see cref="Store"/> objects to a list of <see cref="StoreResponseDto"/> objects.
        /// </summary>
        /// <param name="stores">The list of <see cref="Store"/> objects to convert.</param>
        /// <returns>A list of <see cref="StoreResponseDto"/> objects.</returns>
        public static List<StoreResponseDto> ToStoreResponseList(this List<Store> stores)
        {
            var storeResponses = new List<StoreResponseDto>();
            foreach (var store in stores)
            {
                storeResponses.Add(store.ToStoreResponse());
            }
            return storeResponses;
        }


    }

}
