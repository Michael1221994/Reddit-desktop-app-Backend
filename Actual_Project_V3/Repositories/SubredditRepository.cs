using Actual_Project_V3.Models;
using Microsoft.AspNetCore.Identity;

namespace Actual_Project_V3.Repositories
{
    public class SubredditRepository : ISubredditRepository
    {
        private readonly Context context;
        private UserManager<User> UsrMgr;
        public SubredditRepository(UserManager<User> userManager,Context _context)
        {
            UsrMgr = userManager;
            context = _context;
        }

        public async Task<string> CreateSubreddit(Subreddit subreddit)
        {
            string confirm="members";
            User appuser = await UsrMgr.FindByIdAsync(subreddit.User_Id);
            Subreddit sub = context.Subreddits.FirstOrDefault(s => s.Subreddit_Name == subreddit.Subreddit_Name);
            //foreach (string members in subreddit.Members)
            //{
            //    User user= await UsrMgr.FindByIdAsync(members);
            //    if(user == null)
            //    {
            //        confirm = "no members";
            //        break;
            //    }
                
               
            //}
            if (sub != null)
            {
                return "subreddit name already exist";
            }
            else if( sub==null)//confirm != "no members" &&
            {
                Subreddit newSubreddit = new Subreddit()
                {
                    Subreddit_Genre = subreddit.Subreddit_Genre,
                    User_Id = subreddit.User_Id,
                    Subreddit_Name = subreddit.Subreddit_Name,
                    Subreddit_Alt_Name = subreddit.Subreddit_Alt_Name,
                    Subreddit_Description = subreddit.Subreddit_Description,
                    Sub_IconImg_Name = subreddit.Sub_IconImg_Name,
                    Sub_BackgroundImg_Name = subreddit.Sub_BackgroundImg_Name,
                    Number_Of_Members = 1,
                    //Members = subreddit.Members,
                    Allowed_Flairs = subreddit.Allowed_Flairs,
                    OwnerUser = appuser
                };
                context.Subreddits.Add(newSubreddit);
                context.SaveChanges();
                return "saved";
            }
            else
            {
                return "not saved";
            }
            

            
        }

        public string UpdateSubreddit(Subreddit subreddit)
        {
            var UpdatedSubreddit = context.Subreddits.Find(subreddit.Sub_Id);
            Subreddit sub = context.Subreddits.FirstOrDefault(s => s.Subreddit_Name == subreddit.Subreddit_Name);
            string confirm = "";
            if (sub!=null)
            {
                confirm = "subreddit with that name already exists";
            }
            else if (UpdatedSubreddit != null && sub==null)
            {
                UpdatedSubreddit.Subreddit_Genre = subreddit.Subreddit_Genre;
                UpdatedSubreddit.Subreddit_Name = subreddit.Subreddit_Name;
                UpdatedSubreddit.Subreddit_Alt_Name = subreddit.Subreddit_Alt_Name;
                UpdatedSubreddit.Subreddit_Description = subreddit.Subreddit_Description;
                UpdatedSubreddit.Sub_IconImg_Name = subreddit.Sub_IconImg_Name;
                UpdatedSubreddit.Sub_BackgroundImg_Name = subreddit.Sub_BackgroundImg_Name;
                UpdatedSubreddit.Allowed_Flairs = subreddit.Allowed_Flairs;
                //UpdatedSubreddit.Members= subreddit.Members;
                UpdatedSubreddit.Number_Of_Members = subreddit.Number_Of_Members;
                context.SaveChanges();
                confirm = "success";

            }
            else
            { confirm = "fail"; }
            return confirm;

        }

        public string DeleteSubreddit(int subredditId)
        {
            var subreddit = context.Subreddits.Find(subredditId);
            string confirm = "";
            if (subreddit != null)
            {
                Post post = context.Posts.FirstOrDefault(s => s.Sub_Id == subreddit.Sub_Id);
                context.Posts.Remove(post);
                context.SaveChanges();
                context.Subreddits.Remove(subreddit);
                context.SaveChanges();
                confirm = "success";
            }
            else
            { confirm = "fail"; }
            return confirm;
        }

        public Subreddit GetSubreddit(int subredditId)
        {
            var subreddit= context.Subreddits.Find(subredditId);
            if(subreddit != null)
            {
                return subreddit;
            }
            else
            {
                return null;
            }
        }

        public string JoinSubreddit(int Sub_Id, string User_Id)
        {
            string confirm;
            if(Sub_Id !=null && !string.IsNullOrEmpty(User_Id))
            {
                JoinedSubreddits join=new JoinedSubreddits()
                {
                    User_Id=User_Id,
                    sub_id=Sub_Id
                };
                context.JoinedSubreddits.Add(join);
                context.SaveChanges();
                confirm = "success";

            }
            else { confirm= "fail"; }
            return confirm;
        }

        public string LeaveSubreddit(int sub_id, string User_Id)
        {
            string confirm;
            if (sub_id != null && !string.IsNullOrEmpty(User_Id))
            {
                JoinedSubreddits leave= context.JoinedSubreddits.FirstOrDefault(j => j.sub_id == sub_id && j.User_Id == User_Id);
                context.JoinedSubreddits.Remove(leave);
                context.SaveChanges();
                confirm = "success";

            }
            else { confirm = "fail"; }
            return confirm;
        }
    }
}
