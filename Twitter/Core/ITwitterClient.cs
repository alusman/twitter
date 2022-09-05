namespace Core
{
    public interface ITwitterClient
    {
        Task<IList<Tweet>> GetTweetsAsync(string query, int size);
    }
}