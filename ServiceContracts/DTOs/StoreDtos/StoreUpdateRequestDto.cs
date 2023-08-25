using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceContracts.DTOs.StoreDtos
{
    public class StoreUpdateRequestDto
    {
        public int StoreId { get; set; }

        [Required(ErrorMessage = "The StoreName field is required.")]
        [StringLength(30, ErrorMessage = "The StoreName field must not exceed 30 characters.")]
        public string? StoreName { get; set; }


        [Required(ErrorMessage = "The StoreLocation field is required.")]
        [StringLength(30, ErrorMessage = "The StoreLocation field must not exceed 30 characters.")]
        public string? StoreLocation { get; set; }


        [Required(ErrorMessage = "The StorePhoneNumber field is required.")]
        public string? StorePhoneNumber { get; set; }


        public string? BurgerIds { get; set; }


        /// <summary>
        /// Converts the <see cref="StoreUpdateRequestDto"/> to a <see cref="Store"/> object.
        /// </summary>
        /// <returns>A <see cref="Store"/> object.</returns>
        public Store ToStore()
        {
            return new Store
            {
                StoreId = StoreId,
                StoreName = StoreName,
                StoreLocation = StoreLocation,
                StorePhoneNumber = StorePhoneNumber,
                BurgerIds = BurgerIds
            };
        }


        /// <summary>
        /// Converts the string the user inputs for new <see cref="Store"/> objects into a comma seperated string.
        /// </summary>
        /// <param name="StoreUpdateRequestDto"> A <see cref="StoreUpdateRequestDto"/> object. </param>
        /// <returns> A <see cref="StoreUpdateRequestDto"/> object. </returns>
        public StoreUpdateRequestDto FixStoreBurgerString(StoreUpdateRequestDto storeUpdateRequestDTO)
        {

            var matches = Regex.Matches(storeUpdateRequestDTO.BurgerIds, @"\d+");

            // Format the output with "ids=" before each digit
            string result = string.Join("&", matches
                .OfType<Match>()
                .Where(match => !string.IsNullOrEmpty(match.Value))
                .Select(match => "ids=" + match.Value));

            storeUpdateRequestDTO.BurgerIds = result;
            return storeUpdateRequestDTO;

        }
    }
}
