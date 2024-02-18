using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public interface ISearchRepository
    {
        SearchResults Search(string searchTerm, int levenshteinThreshold);
    }
}
