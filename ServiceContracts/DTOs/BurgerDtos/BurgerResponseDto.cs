using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTOs.BurgerDtos
{
    public class BurgerResponseDto
    {
        public int id { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public string? ingredients { get; set; }

        public BurgerResponseWithoutIdDto HideBurgerId(BurgerResponseDto burgerResponse)
        {
            return new BurgerResponseWithoutIdDto
            {

                BurgerName = burgerResponse.name,
                BurgerPrice = burgerResponse.price,
                BurgerIngredients = burgerResponse.ingredients
            };

        }
        public List<BurgerResponseWithoutIdDto> ToBurgerResponseWithoutIdDTOList(List<BurgerResponseDto> burgers)
        {
            var burgerResponses = new List<BurgerResponseWithoutIdDto>();
            foreach (var burger in burgers)
            {
                burgerResponses.Add(burger.HideBurgerId(burger));
            }
            return burgerResponses;
        }
    }
}

