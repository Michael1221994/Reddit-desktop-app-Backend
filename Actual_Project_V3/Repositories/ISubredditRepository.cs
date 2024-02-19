using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public interface ISubredditRepository
    {
        Task<string> CreateSubreddit(Subreddit subreddit);
        string UpdateSubreddit(Subreddit subreddit);
        string DeleteSubreddit(int subredditId);
        Subreddit GetSubreddit(int subredditId);
        string JoinSubreddit(int Sub_Id, string User_Id);
        string LeaveSubreddit(int sub_id, string User_Id);
        List<Subreddit> GetSubreddits(string Id);
    }
}
