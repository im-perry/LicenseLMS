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
    public class SubgroupsAPIClient
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public SubgroupsAPIClient(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<Subgroup>> GetAllSubgroups()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("groupsapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                client.BaseAddress = new Uri("https://localhost:5446/");

                var response = client.GetAsync("subgroups");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Subgroup>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        public async Task<Subgroup> CreateSubgroup(Subgroup subgroup)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                    .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Post, $"Subgroups");
            request.Content = new StringContent(JsonConvert.SerializeObject(subgroup), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Subgroup>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Subgroup> GetDetails(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Get, $"Subgroups/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Subgroup>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task DeleteSubgroup(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Subgroups/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Subgroup>();
                readTask.Wait();
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Subgroup> UpdateSubgroup(Subgroup subgroup)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Put, $"Subgroups/{subgroup}");
            request.Content = JsonContent.Create<Subgroup>(subgroup);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Subgroup>();
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
