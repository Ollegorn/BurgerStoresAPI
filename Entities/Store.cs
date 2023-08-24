using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Store
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


        public bool IsStoreOpen { get; set; }

        public string? BurgerIds { get; set; }
    }
}