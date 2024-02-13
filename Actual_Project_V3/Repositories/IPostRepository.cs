using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetHotPosts();
        List<Post> GetNewPosts();
        List<Post> GetTopPosts(string when);
        List<Post> GetControversialPosts(string when);
        List<Post> GetSubPosts(int Sub_Id, string filter, string filterwithdate);
    }
}
