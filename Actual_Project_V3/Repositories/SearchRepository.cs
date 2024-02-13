using Actual_Project_V3.Models;
using Microsoft.EntityFrameworkCore;

namespace Actual_Project_V3.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly Context context;

        public SearchRepository(Context _context)
        {
            this.context = _context;
        }
        public SearchResults Search (string searchTerm, int threshold)
        {
            var results = new SearchResults();
            var users = context.Users.ToList();
            var posts= context.Posts.ToList();
            var subreddits= context.Subreddits.ToList();

            results.Users = users
                .Where(u => LevenshteinSearch.IsSimilar(u.UserName, searchTerm,threshold))
                .ToList();

            results.Posts = posts
            .Where(p => p.Flair.Any(f => LevenshteinSearch.IsSimilar(f, searchTerm, threshold)) ||
                        LevenshteinSearch.IsSimilar(p.Title, searchTerm, threshold))
            .ToList();

            results.Subreddits = subreddits
                .Where(s => LevenshteinSearch.IsSimilar(s.Subreddit_Name, searchTerm, threshold) ||
                            LevenshteinSearch.IsSimilar(s.Subreddit_Genre, searchTerm, threshold) ||
                            LevenshteinSearch.IsSimilar(s.Subreddit_Alt_Name, searchTerm, threshold))
                .ToList();

            return results;
        }
    }            
}
