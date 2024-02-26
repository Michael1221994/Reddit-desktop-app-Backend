using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public class SaveRepository : ISaveRepository
    {
        private readonly Context context;

        public SaveRepository(Context _context)
        {
            context = _context;
        }

        public string AddSave(Save save)
        {
            User user = context.Users.Find(save.User_Id);
            Post post = context.Posts.Find(save.Post_Id);
            if (post != null && user != null)
            {
                Save addsave = new Save()
                {
                    User_Id = save.User_Id,
                    Post_Id = save.Post_Id,

                };
                context.Saves.Add(addsave);
                context.SaveChanges();
                return "success";
            }
            else if (user != null && post == null)
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

        public List<Post> GetSaves(string Id)
        {
            User user = context.Users.Find(Id);
            if (user != null)
            {
                List<Post> saved= new List<Post>();
                List<int> ids = context.Saves.Where(s => s.User_Id == Id).Select(P => P.Post_Id).ToList();
                foreach(int id in ids)
                {
                    Post savedposts=context.Posts.FirstOrDefault(p=>p.Post_Id == id);
                    saved.Add(savedposts);
                }
                return saved;
            }
            else
                return null;
        }

        public string UnSave(Save save)
        {
            User user = context.Users.Find(save.User_Id);
            Post post = context.Posts.Find(save.Post_Id);
            if (post != null && user != null)
            {
                Save removesave = context.Saves.FirstOrDefault(s => s.Post_Id == save.Post_Id);
                context.Saves.Remove(removesave);
                context.SaveChanges();
                return "success";
            }
            else if (user != null && post == null)
            {
                return "no post found by that post Id";
            }
            else if (user == null && post != null)
            {
                return "no user found by that user Id";
            }
            else
            {
                return "no user and no post found by those Ids";
            }
        }

        public bool saved(string Id, int Post_Id)
        {          
               Save saved = context.Saves.FirstOrDefault(s => s.Post_Id == Post_Id && s.User_Id==Id);
               if(saved != null)
                {
                    return true;
                }
               else { return false; }            
        }
    }


}
