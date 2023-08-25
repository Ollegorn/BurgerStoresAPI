﻿using Entities;
using RepositoryContracts;
using ServiceContracts.DTOs.BurgerDtos;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Repositories
{
    public class BurgerRepository : IBurgerRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IStoreRepository _storeRepository;
        public BurgerRepository(IStoreRepository storeRepository, IHttpClientFactory httpClientFactory)
        {
            _storeRepository = storeRepository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<BurgerResponseWithoutIdDto>> GetBurgers(int storeId)
        {
            Store storeBasedOnId = await _storeRepository.GetStoreById(storeId);
            //create http client
            HttpClient httpClient = _httpClientFactory.CreateClient();

            var jwtToken = "";
            //move the token later on

            // Set JWT token in the headers
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", jwtToken);

            //create http request
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:7181/api/Burger/BurgersByIds?{storeBasedOnId.BurgerIds}"),

            };

            //send request
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            //read response body
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            if (responseBody == null)
                throw new InvalidOperationException("No response from server");

            //convert response body from json to object
            List<BurgerResponseDto> pizzaResponseDTO = JsonSerializer.Deserialize<List<BurgerResponseDto>>(responseBody);
            List<BurgerResponseWithoutIdDto> pizzasssss = new List<BurgerResponseWithoutIdDto>();
            foreach (BurgerResponseDto pizza in pizzaResponseDTO)
            {
                pizzasssss.Add(pizza.HideBurgerId(pizza));

            }

            return pizzasssss;

        }
    }
}
