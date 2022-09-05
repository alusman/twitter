using Core;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class TwitterClient : ITwitterClient
    {

        private readonly HttpClient _httpClient;

        public TwitterClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<Tweet>> GetTweetsAsync(string query, int size = 10)
        {
            var uri = $"tweets/search/recent?max_results={size}";

            if (!string.IsNullOrEmpty(query))
            {
                uri += $"&query={query}";
            }

            var responseString = await _httpClient.GetStringAsync(uri);

            var result = JsonConvert.DeserializeObject<TwitterResult>(responseString);

            if (result is null)
                return new List<Tweet>();

            return result.Data;
        }
    }
}