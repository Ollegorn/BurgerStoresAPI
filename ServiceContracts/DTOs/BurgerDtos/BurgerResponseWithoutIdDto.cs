using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTOs.BurgerDtos
{
    public class BurgerResponseWithoutIdDto
    {
        public string? BurgerName { get; set; }
        public decimal BurgerPrice { get; set; }
        public string? BurgerIngredients { get; set; }
    }
}
