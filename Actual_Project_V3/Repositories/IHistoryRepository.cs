using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public interface IHistoryRepository
    {
        string PostHistory(History history);
        List<Post> GetHistory(string Id);
        string ClearHistory(string Id);
    }
}
