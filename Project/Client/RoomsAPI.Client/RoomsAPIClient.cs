using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using RoomsAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TokensService;

namespace RoomsAPI.Client
{
    [Authorize]
    public class RoomsAPIClient
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public RoomsAPIClient(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                client.BaseAddress = new Uri("https://localhost:5447/");

                var response = client.GetAsync("rooms");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Room>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        public async Task<Room> CreateRoom(Room room)
        {
            var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

            _httpClient
                    .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5447/");

            var request = new HttpRequestMessage(HttpMethod.Post, $"Rooms");
            request.Content = new StringContent(JsonConvert.SerializeObject(room), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Room>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Room> GetDetails(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5447/");

            var request = new HttpRequestMessage(HttpMethod.Get, $"Rooms/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Room>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task DeleteRoom(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5447/");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Rooms/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Room>();
                readTask.Wait();
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Room> UpdateRoom(Room room)
        {
            var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5447/");

            var request = new HttpRequestMessage(HttpMethod.Put, $"Rooms/{room}");
            request.Content = JsonContent.Create<Room>(room);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Room>();
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
