using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public class upvotedownvoteRepository : Iupvotedownvote
    {
        private readonly Context context;
        //private List<Post> allposts;

        public upvotedownvoteRepository(Context _context)
        {
            context = _context;
            //allposts = context.Set<Post>().ToList();
        }
        public string PostRate(string User_Id, int Id, int Rating, string Type)//need  to check if the same user already downvoted or upvoted
        {
            string confirm = "";
            if (Type == "post")
            {
                Post Specific_Post = context.Posts.Find(Id);
                UpvoteDownvote check = context.UpvoteDownvote.FirstOrDefault(check => check.Post_Id == Id && check.User_Id == User_Id);
                if (check == null)
                {
                    if (Specific_Post != null)
                    {
                        if (Rating == 1)
                        {
                            Specific_Post.Number_of_Upvotes++;
                            confirm = "post Upvoted";
                        }
                        else //if (Rating == 0)
                        {
                            Specific_Post.Number_Of_DownVotes++;
                            confirm = "post Downvoted";
                        }
                        context.SaveChanges();

                        UpvoteDownvote action = new UpvoteDownvote()
                        {
                            User_Id = User_Id,
                            Post_Id = Id,
                            Rating = Rating
                        };
                        context.UpvoteDownvote.Add(action);
                        context.SaveChanges();

                    }
                    else
                    {
                        confirm = "No Post found";
                    }
                }
                else
                {
                    if (check.Rating == 0)
                    {
                        Specific_Post.Number_Of_DownVotes--;
                    }
                    else { Specific_Post.Number_of_Upvotes--; }
                    context.UpvoteDownvote.Remove(check);
                    context.SaveChanges();
                    confirm = "post action undone";
                }

            }
            else if (Type == "comment")
            {
                Comment Specific_comment = context.Comments.Find(Id);
                UpvoteDownvote check = context.UpvoteDownvote.FirstOrDefault(check => check.Comment_Id == Id && check.User_Id == User_Id);
                if (check == null)
                {
                    if (Specific_comment != null)
                    {
                        if (Rating == 1)
                        {
                            Specific_comment.Upvote_Count++;
                            confirm = "comment Upvoted";
                        }
                        else //if (Rating == 0)
                        {
                            Specific_comment.Downvote_Count++;
                            confirm = "comment Downvoted";
                        }

                        context.SaveChanges();

                        UpvoteDownvote action = new UpvoteDownvote()
                        {
                            User_Id = User_Id,
                            Comment_Id = Id,
                            Rating = Rating
                        };
                        context.UpvoteDownvote.Add(action);
                        context.SaveChanges();
                    }
                    else
                    {
                        confirm = "Comment not found";
                    }
                }
                else
                {
                    if (check.Rating == 0)
                    {
                        Specific_comment.Downvote_Count--;
                    }
                    else { Specific_comment.Upvote_Count--; }
                    context.UpvoteDownvote.Remove(check);
                    context.SaveChanges();
                    confirm = "comment action undone";
                }


            }
            else { confirm = "Unknown Type"; }
            return confirm;//checkkkkk
        }


        public string check_action(string Id, int Content_Id, string Type)
        {
            string confirm;
            if (Type == "post")
            {
                UpvoteDownvote action = context.UpvoteDownvote.FirstOrDefault(act => act.Post_Id == Content_Id && act.User_Id == Id);
                if (action != null)
                {
                    if (action.Rating == 0)
                    {
                        confirm = "DownVote";
                    }
                    else if (action.Rating == 1)
                    {
                        confirm = "Upvote";
                    }
                    else { confirm = "no action"; }
                }
                else { confirm = "no action"; }
            }
            else if (Type == "comment")
            {
                UpvoteDownvote action = context.UpvoteDownvote.FirstOrDefault(act => act.Comment_Id == Content_Id && act.User_Id == Id);
                if (action != null)
                {
                    if (action.Rating == 0)
                    {
                        confirm = "DownVote";
                    }
                    else if (action.Rating == 1)
                    {
                        confirm = "Upvote";
                    }
                    else { confirm = "no action"; }
                }
                else { confirm = "no action"; }
            }
            else { confirm = "Unknown Type"; }


            return confirm;
        }
    }
}
