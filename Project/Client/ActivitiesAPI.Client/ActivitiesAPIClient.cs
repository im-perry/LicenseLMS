using ActivitiesAPI.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TokensService;

namespace ActivitiesAPI.Client
{
    [Authorize]
    public class ActivitiesAPIClient
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public ActivitiesAPIClient(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;
            
        }

        public async Task<IEnumerable<Activity>> GetAllActivities()
        {
            using(var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("activitiesapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                client.BaseAddress = new Uri("https://localhost:5445/");

                var response = client.GetAsync("activities");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Activity>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        public async Task<Activity> CreateActivity(Activity activity)
        {
            var tokenResponse = await _tokenService.GetToken("activitiesapi.read");

            _httpClient
                    .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5445/");

            var request = new HttpRequestMessage(HttpMethod.Post, $"Activities");
            request.Content = new StringContent(JsonConvert.SerializeObject(activity), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Activity>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }
            
        }

        public async Task<Activity> GetDetails(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("activitiesapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5445/");

            var request = new HttpRequestMessage(HttpMethod.Get, $"Activities/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Activity>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }
            
        }

        public async Task DeleteActivity(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("activitiesapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5445/");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Activities/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Activity>();
                readTask.Wait();
            }
            else
            {
                throw new Exception("Unable to get content");
            }
            
        }

        public async Task<Activity> UpdateActivity(Activity activity)
        {
            var tokenResponse = await _tokenService.GetToken("activitiesapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5445/");

            var request = new HttpRequestMessage(HttpMethod.Put, $"Activities/{activity}");
            request.Content = JsonContent.Create<Activity>(activity);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Activity>();
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
