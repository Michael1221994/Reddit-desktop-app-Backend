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
                            context.SaveChanges();
                        }
                        else //if (Rating == 0)
                        {
                            Specific_Post.Number_Of_DownVotes++;
                            confirm = "post Downvoted";
                            context.SaveChanges();
                        }
                       

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
                        context.UpvoteDownvote.Remove(check);
                        context.SaveChanges();
                        Specific_Post.Number_Of_DownVotes--;
                        context.SaveChanges();
                        if(Rating== 1)
                        {
                            Specific_Post.Number_of_Upvotes++;
                            context.SaveChanges();
                            confirm = "upvote";
                        }
                        else
                        {
                            Specific_Post.Number_Of_DownVotes++;
                            context.SaveChanges();
                            confirm = "downvote";
                        }
                        UpvoteDownvote actions = new UpvoteDownvote()
                        {
                            User_Id = User_Id,
                            Post_Id = Id,
                            Rating = Rating
                        };
                        context.UpvoteDownvote.Add(actions);
                        context.SaveChanges();

                    }
                    else if(check.Rating==1) {
                        context.UpvoteDownvote.Remove(check);
                        context.SaveChanges();
                        Specific_Post.Number_of_Upvotes--;
                        context.SaveChanges();
                        if (Rating == 1)
                        {
                            Specific_Post.Number_of_Upvotes++;
                            context.SaveChanges();
                            confirm = "upvote";
                        }
                        else
                        {
                            Specific_Post.Number_Of_DownVotes++;
                            context.SaveChanges();
                            confirm = "downvote";
                        }
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
                        confirm = "post action undone";
                    }
                    
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
                            context.SaveChanges();
                        }
                        else //if (Rating == 0)
                        {
                            Specific_comment.Downvote_Count++;
                            confirm = "comment Downvoted";
                            context.SaveChanges();
                        }
                                                
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
                        context.UpvoteDownvote.Remove(check);
                        context.SaveChanges();
                        Specific_comment.Downvote_Count--;                        
                        if (Rating == 1)
                        {
                            
                            Specific_comment.Upvote_Count++;
                            context.SaveChanges();
                        }
                        else
                        {
                            Specific_comment.Downvote_Count++;
                            context.SaveChanges();
                        }
                        UpvoteDownvote action = new UpvoteDownvote()
                        {
                            User_Id = User_Id,
                            Comment_Id = Id,
                            Rating = Rating
                        };
                        context.UpvoteDownvote.Add(action);
                        context.SaveChanges();


                    }
                    else if(check.Rating==1) {                         
                        context.UpvoteDownvote.Remove(check);
                        context.SaveChanges();
                        Specific_comment.Upvote_Count--;
                        if (Rating == 1)
                        {
                            Specific_comment.Upvote_Count++;
                            context.SaveChanges();
                            confirm = "C upvote";
                        }
                        else
                        {
                            Specific_comment.Downvote_Count++;
                            context.SaveChanges();
                            confirm = "c downvote";
                        }
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
                        confirm = "comment action undone";
                    }
                    
                    //context.UpvoteDownvote.Remove(check);
                    //context.SaveChanges();
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

        public List<Post> GetUpvotedDownvoted(string Id, string type)
        {
            if(!string.IsNullOrEmpty(Id) || !string.IsNullOrEmpty(type))
            {
                List<Post> ratedposts = new List<Post>();
                List<UpvoteDownvote> upvotedownvote = new List<UpvoteDownvote>();
                if (type == "Upvotes")
                {
                    upvotedownvote=context.UpvoteDownvote.Where(ud=>ud.User_Id==Id && ud.Rating==1).ToList();
                    if (upvotedownvote != null)
                    {
                        foreach (UpvoteDownvote postid in upvotedownvote)
                        {
                            Post ratedpost = context.Posts.FirstOrDefault(p => p.Post_Id == postid.Post_Id);
                            ratedposts.Add(ratedpost);
                        }
                        return ratedposts;
                    }
                    else
                    {
                        return null;
                    }
                    
                }
                else if(type == "Downvotes")
                {
                    upvotedownvote = context.UpvoteDownvote.Where(ud => ud.User_Id == Id && ud.Rating == 0).ToList();
                    if(upvotedownvote != null)
                    {
                        foreach (UpvoteDownvote postid in upvotedownvote)
                        {
                            Post ratedpost = context.Posts.FirstOrDefault(p => p.Post_Id == postid.Post_Id);
                            ratedposts.Add(ratedpost);
                        }
                        return ratedposts;
                    }
                    else { return null; }

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
