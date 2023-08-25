using Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace ServiceContracts.DTOs.StoreDtos
{
    public class StoreAddRequestDto
    {

        [Required(ErrorMessage = "The StoreName field is required.")]
        [StringLength(30, ErrorMessage = "The StoreName field must not exceed 30 characters.")]
        public string? StoreName { get; set; }


        [Required(ErrorMessage = "The StoreLocation field is required.")]
        [StringLength(30, ErrorMessage = "The StoreLocation field must not exceed 30 characters.")]
        public string? StoreLocation { get; set; }


        [Required(ErrorMessage = "The StorePhoneNumber field is required.")]
        public string? StorePhoneNumber { get; set; }


        [Required]
        public string? BurgerIds { get; set; }

        public Store ToStore()
        {
            return new Store
            {
                StoreName = StoreName,
                StoreLocation = StoreLocation,
                StorePhoneNumber = StorePhoneNumber,
                BurgerIds = BurgerIds
            };
        }

        public StoreAddRequestDto FixStoreBurgerString(StoreAddRequestDto storeAddRequestDto)
        {

            var matches = Regex.Matches(storeAddRequestDto.BurgerIds, @"\d+");

            // Format the output with "burgerIds=" before each digit
            string result = string.Join("&", matches
                .OfType<Match>()
                .Where(match => !string.IsNullOrEmpty(match.Value))
                .Select(match => "ids=" + match.Value));

            storeAddRequestDto.BurgerIds = result;
            return storeAddRequestDto;

        }
    }
}
