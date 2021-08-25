using IdentityModel.Client;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TokensService;
using TeachingAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace TeachingAPI.Client
{
    [Authorize]
    public class ClassesAPIClient
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public ClassesAPIClient(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("teachingapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                client.BaseAddress = new Uri("https://localhost:5449/");

                var response = client.GetAsync("classes");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Class>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        public async Task<Class> CreateClass(Class classs)
        {
            var tokenResponse = await _tokenService.GetToken("teachingapi.read");

            _httpClient
                    .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5449/");

            var request = new HttpRequestMessage(HttpMethod.Post, $"Classes");
            request.Content = new StringContent(JsonConvert.SerializeObject(classs), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Class>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Class> GetDetails(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("teachingapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5449/");

            var request = new HttpRequestMessage(HttpMethod.Get, $"Classes/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Class>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task DeleteClass(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("teachingapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5449/");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Classes/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Class>();
                readTask.Wait();
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Class> UpdateClass(Class classs)
        {
            var tokenResponse = await _tokenService.GetToken("teachingapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5449/");

            var request = new HttpRequestMessage(HttpMethod.Put, $"Classes/{classs}");
            request.Content = JsonContent.Create<Class>(classs);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Class>();
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
