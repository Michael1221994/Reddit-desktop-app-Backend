using Actual_Project_V3.Models;
using Actual_Project_V3.ExtensionMethods;
using Actual_Project_V3.Repositories;

namespace Actual_Project_V3.Repositories
{
    public class FeedRepository : IFeedRepository
    {
        private readonly Context context;
        private List<Post> allposts;

        public FeedRepository(Context _context)
        {
            context = _context;
            allposts = context.Set<Post>().ToList();
        }

        public List<Post> GetHomeFeed(string Id)
        {

            List<Post> Today_Ordered_post = allposts.Where(post => post.Posted_When.ThisDay() && post.User_Id == Id).OrderBy(post => post.Posted_When).ToList();
            return Today_Ordered_post;
            //List<Post> Todaypost = new List<Post>();
            //List<Post> Today_Ordered_post = new List<Post>();
            //foreach (Post post in allposts)
            //{
            //    if (post.Posted_When.ThisDay())
            //    {
            //        Todaypost.Add(post);
            //        Today_Ordered_post = Todaypost.OrderBy(post => post.Posted_When).ToList();
            //    }
            //}
            //return Today_Ordered_post;
        }

        public List<Post> GetPopularFeed(string Id)
        {
            List<Post> Popular_Feed_Ordered = allposts.Where(post => post.Posted_When.ThisDay() && post.User_Id == Id).OrderByDescending(post => post.Number_of_Upvotes).ToList();
            return Popular_Feed_Ordered;
            //List<Post> Popular_Feed = new List<Post>();
            //List<Post> Popular_Feed_Ordered = new List<Post>();
            //foreach (Post post in allposts)
            //{
            //    if (post.Posted_When.ThisDay())
            //    {
            //        Popular_Feed.Add(post);
            //        Popular_Feed_Ordered = Popular_Feed.OrderByDescending(post => post.Number_of_Upvotes).ToList();
            //    }
            //}
            //return Popular_Feed_Ordered;
        }

        public List<Post> GetAllFeed()
        {
            
            List<Post> orderedPosts = allposts.OrderByDescending(post => post.Number_of_Upvotes).ToList();
            return orderedPosts;
        }

        public string PostRate(int Rating, int Id, string Type)
        {
            string confirm=" ";
            if (Type == "post")
            {
                Post Specific_Post = context.Posts.Find(Id);
                if (Specific_Post != null)
                {
                    if (Rating == 1)
                    {
                        Specific_Post.Number_of_Upvotes++;
                        confirm = "Post Upvoted";
                    }
                    else if (Rating == 0)
                    {
                        Specific_Post.Number_Of_DownVotes++;
                        confirm = "Post Downvoted";
                    }
                    context.SaveChanges();
                    
                }
                else
                {
                    confirm = "Post fail";
                }
            }
            else if (Type == "comment")
            {
                Comment Specific_comment = context.Comments.Find(Id);
                if (Specific_comment != null)
                {
                    if (Rating == 1)
                    {
                        Specific_comment.Upvote_Count++;
                        confirm = "comment Upvoted";
                    }
                    else if (Rating == 0)
                    {
                        Specific_comment.Downvote_Count++;
                        confirm = "Comment Downvoted";
                    }
                    context.SaveChanges();

                }
                else
                {
                    confirm = "Comment fail";
                }
            }
            else { confirm = "Unknown Type"; }


            return confirm;
        }
    }
}
