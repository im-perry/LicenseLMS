using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TokensService;
using Type = RoomsAPI.Models.Type;

namespace RoomsAPI.Client
{
    [Authorize]
    public class TypesAPIClient
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public TypesAPIClient(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<Type>> GetAllTypes()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                client.BaseAddress = new Uri("https://localhost:5447/");

                var response = client.GetAsync("types");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Type>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        public async Task<Type> CreateType(Type type)
        {
            var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

            _httpClient
                    .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5447/");

            var request = new HttpRequestMessage(HttpMethod.Post, $"Types");
            request.Content = new StringContent(JsonConvert.SerializeObject(type), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Type>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Type> GetDetails(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5447/");

            var request = new HttpRequestMessage(HttpMethod.Get, $"Types/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Type>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task DeleteType(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5447/");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Types/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Type>();
                readTask.Wait();
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Type> UpdateRoom(Type type)
        {
            var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5447/");

            var request = new HttpRequestMessage(HttpMethod.Put, $"Types/{type}");
            request.Content = JsonContent.Create<Type>(type);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Type>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }
    }
}
