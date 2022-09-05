using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API_UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwitterController : ControllerBase
    {
        private readonly TwitterClient _twitterClient;

        public TwitterController(TwitterClient twitterClient)
        {
            _twitterClient = twitterClient;
        }

        [HttpGet]
        public async Task<IList<Tweet>> Get()
        {
            var query = "dotnetcore, azure";

            var result = await _twitterClient.GetTweetsAsync(query, 20);

            return result;
        }
    }
}