using Core;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Infrastructure
{
    public class TwitterClient : ITwitterClient
    {

        private readonly HttpClient _httpClient;

        public TwitterClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<Tweet>> GetTweetsAsync(int count = 20)
        {
            var uri = $@"tweets/search/recent?query=dotnetcore, azure&max_results={count}";

            var responseString = await _httpClient.GetStringAsync(uri);

            var result = JsonConvert.DeserializeObject<TwitterResult>(responseString);

            if (result is null)
                return new List<Tweet>();

            return result.Data;
        }
    }
}