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
    public class SpecializationsAPIClient
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public SpecializationsAPIClient(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<Specialisation>> GetAllSpecialisations()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("groupsapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                client.BaseAddress = new Uri("https://localhost:5446/");

                var response = client.GetAsync("specialisations");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Specialisation>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        public async Task<Specialisation> CreateSpecialisation(Specialisation specialisation)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                    .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Post, $"Specialisations");
            request.Content = new StringContent(JsonConvert.SerializeObject(specialisation), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Specialisation>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Specialisation> GetDetails(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Get, $"Specialisations/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Specialisation>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task DeleteSpecialisation(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Specialisations/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Specialisation>();
                readTask.Wait();
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Specialisation> UpdateSpecialisation(Specialisation specialisation)
        {
            var tokenResponse = await _tokenService.GetToken("groupsapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5446/");

            var request = new HttpRequestMessage(HttpMethod.Put, $"Specialisations/{specialisation}");
            request.Content = JsonContent.Create<Specialisation>(specialisation);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Specialisation>();
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
