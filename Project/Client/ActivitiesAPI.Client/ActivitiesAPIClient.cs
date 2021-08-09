using ActivitiesAPI.Models;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TokensService;

namespace ActivitiesAPI.Client
{
    public class ActivitiesAPIClient
    {
        private readonly ITokenService _tokenService;

        public ActivitiesAPIClient(ITokenService tokenService)
        {
            _tokenService = tokenService;
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
    }
}
