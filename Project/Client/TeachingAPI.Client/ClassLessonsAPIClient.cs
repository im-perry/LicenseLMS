using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using TeachingAPI.Models;
using TokensService;
using Microsoft.AspNetCore.Authorization;
using IdentityModel.Client;

namespace TeachingAPI.Client
{
    [Authorize]
    public class ClassLessonsAPIClient
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public ClassLessonsAPIClient(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ClassLesson>> GetAllLessons()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("teachingapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                client.BaseAddress = new Uri("https://localhost:5449/");

                var response = client.GetAsync("ClassLessons");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ClassLesson>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        public async Task<ClassLesson> CreateLesson(ClassLesson lesson)
        {
            var tokenResponse = await _tokenService.GetToken("teachingapi.read");

            _httpClient
                    .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5449/");

            var request = new HttpRequestMessage(HttpMethod.Post, $"ClassLessons");
            request.Content = new StringContent(JsonConvert.SerializeObject(lesson), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<ClassLesson>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<ClassLesson> GetDetails(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("teachingapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5449/");

            var request = new HttpRequestMessage(HttpMethod.Get, $"ClassLessons/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<ClassLesson>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task DeleteLesson(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("teachingapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5449/");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"ClassLessons/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<ClassLesson>();
                readTask.Wait();
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<ClassLesson> UpdateLesson(ClassLesson lesson)
        {
            var tokenResponse = await _tokenService.GetToken("teachingapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5449/");

            var request = new HttpRequestMessage(HttpMethod.Put, $"ClassLessons/{lesson}");
            request.Content = JsonContent.Create<ClassLesson>(lesson);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<ClassLesson>();
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
