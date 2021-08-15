using GroupsAPI.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TokensService;

namespace GroupsAPI.Client
{
    [Authorize]
    public class GroupsAPIClient
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public GroupsAPIClient(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("groupsapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                client.BaseAddress = new Uri("https://localhost:5446/");

                var response = client.GetAsync("groups");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Group>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        public async Task<Group> CreateGroup(Group group)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                    .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Post, $"Groups");
            request.Content = new StringContent(JsonConvert.SerializeObject(group), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Group>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Group> GetDetails(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Get, $"Groups/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Group>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task DeleteGroup(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Groups/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Group>();
                readTask.Wait();
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Group> UpdateGroup(Group group)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.write");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Put, $"Groups/{group}");
            request.Content = JsonContent.Create<Group>(group);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Group>();
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
