namespace Core
{
    public interface ITwitterClient
    {
        Task<IList<Tweet>> GetTweetsAsync(int count);
    }
}