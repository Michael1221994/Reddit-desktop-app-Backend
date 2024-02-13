using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public interface IFeedRepository
    {
        List<Post> GetHomeFeed(string Id);
        List<Post> GetPopularFeed(string Id);
        List<Post> GetAllFeed();
        string PostRate(int Rating, int Id, string Type);
    }
}
