using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using ScheduleAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TokensService;

namespace ScheduleAPI.Client
{
    [Authorize]
    public class ScheduleAPIClient
    {
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public ScheduleAPIClient(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("scheduleapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                client.BaseAddress = new Uri("https://localhost:5448/");

                var response = client.GetAsync("schedules");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Schedule>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        public async Task<Schedule> CreateSchedule(Schedule schedule)
        {
            var tokenResponse = await _tokenService.GetToken("scheduleapi.read");

            _httpClient
                    .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5448/");

            var request = new HttpRequestMessage(HttpMethod.Post, $"Schedules");
            request.Content = new StringContent(JsonConvert.SerializeObject(schedule), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Schedule>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Schedule> GetDetails(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("scheduleapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5448/");

            var request = new HttpRequestMessage(HttpMethod.Get, $"Schedules/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Schedule>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task DeleteSchedule(Guid id)
        {
            var tokenResponse = await _tokenService.GetToken("scheduleapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5448/");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Schedules/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Schedule>();
                readTask.Wait();
            }
            else
            {
                throw new Exception("Unable to get content");
            }

        }

        public async Task<Schedule> UpdateSchedule(Schedule schedule)
        {
            var tokenResponse = await _tokenService.GetToken("scheduleapi.read");

            _httpClient
                .SetBearerToken(tokenResponse.AccessToken);

            _httpClient.BaseAddress = new Uri("https://localhost:5448/");

            var request = new HttpRequestMessage(HttpMethod.Put, $"Schedules/{schedule}");
            request.Content = JsonContent.Create<Schedule>(schedule);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<Schedule>();
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
