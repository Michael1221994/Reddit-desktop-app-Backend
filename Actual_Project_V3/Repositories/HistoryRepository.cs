using Actual_Project_V3.Models;
using Microsoft.Extensions.Hosting;

namespace Actual_Project_V3.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly Context context;

        public HistoryRepository(Context _context)
        {
            context = _context;
        }
        public string PostHistory(History history)
        {
            User user = context.Users.Find(history.User_Id);
            Post post = context.Posts.Find(history.Post_Id);
            if (post != null && user != null)
            {
                History addhistory = new History()
                {
                    User_Id = history.User_Id,
                    Post_Id = history.Post_Id,
                    
                };
                context.History.Add(addhistory);
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

        public List<Post> GetHistory(string Id)
        {
            User user = context.Users.Find(Id);
            if (user != null)
            {
                List<int> ids = context.History.Where(s => s.User_Id == Id).Select(P => P.Post_Id).ToList();
                List<Post> Histories = new List<Post>();
                foreach(int id in ids)
                {
                    Post history= context.Posts.FirstOrDefault(p=>p.Post_Id== id);
                    Histories.Add(history);
                }
                return Histories;
            }
            else
                return null;
        }

        public string ClearHistory(string Id)
        {
            User user = context.Users.Find(Id);
            if(user != null)
            {
                List<History> ids = context.History.Where(s => s.User_Id == Id).ToList();
                context.History.RemoveRange(ids);
                context.SaveChanges();
                return "success";
            }
            else { return "User with this User_Id doesn't exist"; }
        }
    }
}
