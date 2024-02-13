using Actual_Project_V3.ExtensionMethods;
using Actual_Project_V3.Models;
using Microsoft.AspNetCore.Mvc;
namespace Actual_Project_V3.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly Context context;
        private List<Post> allposts;

        public PostRepository(Context _context)
        {
            context = _context;
            allposts = context.Set<Post>().ToList();
        }

        public List<Post> GetHotPosts()
        {
            List<Post> todayHotOrderedPosts =allposts.AsEnumerable()
                .Where(post => post.Posted_When.ThisDay())
                .OrderByDescending(post => post.Number_of_Upvotes)
                .ToList();
            if(todayHotOrderedPosts != null)
            {
                return todayHotOrderedPosts;
            }
            else
            {
                return null;
            }
            
        }

        public List<Post> GetNewPosts()
        {
            List<Post> todayNewOrderedPosts = allposts
                .Where(post => post.Posted_When.ThisDay())
                .OrderByDescending(post => post.Posted_When)
                .ToList();
            return todayNewOrderedPosts;
        }

        public List<Post> GetTopPosts(string when)
        {
            List<Post> filteredPosts = when switch
            {
                "This Day" => allposts
                    .Where(post => post.Posted_When.ThisDay())
                    .OrderByDescending(post => post.Number_of_Upvotes)
                    .ToList(),
                "This Week" => allposts
                    .Where(post => post.Posted_When.ThisWeek())
                    .OrderByDescending(post => post.Number_of_Upvotes)
                    .ToList(),
                "This Month" => allposts
                    .Where(post => post.Posted_When.ThisMonth())
                    .OrderByDescending(post => post.Number_of_Upvotes)
                    .ToList(),
                "This Year" => allposts
                    .Where(post => post.Posted_When.ThisYear())
                    .OrderByDescending(post => post.Number_of_Upvotes)
                    .ToList(),
                _ => new List<Post>() 
            };
            return filteredPosts;
        }

        public List<Post> GetControversialPosts(string when)
        {
            List<Post> filteredPosts = when switch
            {
                "This Day" => allposts
                    .Where(post => post.Posted_When.ThisDay())
                    .OrderByDescending(post => post.Number_Of_Comments)
                    .ToList(),
                "This Week" => allposts
                    .Where(post => post.Posted_When.ThisWeek())
                    .OrderByDescending(post => post.Number_Of_Comments)
                    .ToList(),
                "This Month" => allposts
                    .Where(post => post.Posted_When.ThisMonth())
                    .OrderByDescending(post => post.Number_Of_Comments)
                    .ToList(),
                "This Year" => allposts
                    .Where(post => post.Posted_When.ThisYear())
                    .OrderByDescending(post => post.Number_Of_Comments)
                    .ToList(),
                _ => new List<Post>() // Default to an empty list if invalid period
            };
            return filteredPosts;
        }

        public List<Post> GetSubPosts(int Sub_Id, string filter, string filterwithdate)
        {
            Subreddit subreddit = context.Subreddits.Find(Sub_Id);
            if (subreddit != null)
            {
                List<Post> filteredpostswithdate = filterwithdate switch
                {
                    "This Day" => allposts.Where(post => post.Posted_When.ThisDay()).ToList(),
                    "This Week" => allposts.Where(post => post.Posted_When.ThisWeek()).ToList(),
                    "This Month" => allposts.Where(post => post.Posted_When.ThisMonth()).ToList(),
                    "This Year" => allposts.Where(post => post.Posted_When.ThisYear()).ToList(),
                    _ => allposts // Default to all time
                };
                List<Post> filteredposts = filter switch
                {
                    "hot" => filteredpostswithdate.OrderByDescending(post => post.Number_of_Upvotes).ToList(),
                    "New" => filteredpostswithdate.OrderByDescending(post => post.Posted_When).ToList(),
                    "Top" => filteredpostswithdate.OrderByDescending(post => post.Number_of_Upvotes).ToList(),
                    "Controversial" => filteredpostswithdate.OrderByDescending(post => post.Number_Of_Comments).ToList(),
                    _ => filteredpostswithdate
                };
                return filteredposts;
            }
            else return null;
        }
    }
}
