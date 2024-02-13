using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Context context;

        public CommentRepository(Context _context)
        {
            context = _context;
        }

        public string CreateComment(Comment comment)
        {
            User user = context.Users.Find(comment.User_Id) ;
            Post post= context.Posts.Find(comment.Post_Id) ;
            if(post != null && user!=null)
            {
                Comment newcomment = new Comment()
                {
                    User_Id=comment.User_Id,
                    Post_Id=post.Post_Id,
                    Sub_Id=post.Sub_Id,
                    Comments=comment.Comments,
                    Reply_To=comment.Reply_To,
                    Commented_When=comment.Commented_When,
                    Downvote_Count=comment.Downvote_Count,
                    Upvote_Count=comment.Upvote_Count
                };
                context.Comments.Add(newcomment);
                context.SaveChanges();
                return "success";
            }
            else if(user!=null && post == null)
            {
                return "no post found by that post Id";
            }
            else if (user == null && post != null)
            {
                return "no user found by that post Id";
            }
            else
            {
                return "no user and no post found by those Ids";
            }
        }
        public List<Comment> GetComment(int postId)
        {
            List<Comment> comments = new List<Comment>();
            Post post = context.Posts.Find(postId);
            if (post != null)
            {
                comments= context.Comments.Where(s => s.Post_Id == postId).ToList(); 
                return comments;
            }
            return null; 
        }

        public List<Comment> GetUserComment(string User_Id)
        {
            List<Comment> comments = new List<Comment>();
            User user = context.Users.Find(User_Id);
            if (user != null)
            {
                comments = context.Comments.Where(s => s.User_Id == User_Id).ToList();
                return comments;
            }
            return null; // Or throw an exception if required
        }

        public string UpdateComment(Comment comment)
        {
            Comment existingComment = context.Comments.Find(comment.Comment_Id);
            string confirmation = "";
            if (existingComment != null)
            {
                existingComment.Comments = comment.Comments;
                existingComment.Commented_When = comment.Commented_When;
                existingComment.Upvote_Count = comment.Upvote_Count;
                existingComment.Downvote_Count = comment.Downvote_Count;
                //context.Comments.Update(existingComment);
                context.SaveChanges();
                confirmation = "success";                
            }
            else
            {
                confirmation = "fail";  // Handle not found case
            }
            return confirmation;
        }

        public string DeleteComment(int commentId)
        {
            Comment comment = context.Comments.Find(commentId);
            string confirmation = "";
            if (comment != null)
            {
                context.Comments.Remove(comment);
                context.SaveChanges();
                confirmation = "success";
            }
            else
            {
                confirmation = "fail";
                // Handle not found case
            }
            return confirmation;
        }
    }
}
