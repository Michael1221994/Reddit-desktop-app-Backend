using Actual_Project_V3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actual_Project_V3.Repositories
{
    public class CRUDRepository : ICRUDRepository
    {
        private readonly Context context;

        public CRUDRepository(Context _context)
        {
            context = _context;
        }

        public string MediaSave(IFormFile media, string type)
        {
            if (type == "Image")
            {
                string uniqueimagename;
                string uploadfolderimage = "C:\\Users\\micha\\source\\repos\\Actual_Project_V3\\Actual_Project_V3\\wwwroot\\Images\\";
                if (media != null)
                {
                    string Imagefilename = Guid.NewGuid().ToString() + "_" + media.FileName;
                    uniqueimagename = Path.Combine(uploadfolderimage, Imagefilename);
                    media.CopyTo(new FileStream(uniqueimagename, FileMode.Create));
                    return Imagefilename;
                }
                else
                {
                    return "no media submitted";
                }
            }
            else if (type == "Video")
            {
                string uniquevideoname ;
                string uploadfoldervideo = "C:\\Users\\micha\\source\\repos\\Actual_Project_V3\\Actual_Project_V3\\wwwroot\\Videos\\";
                if (media != null)
                {
                    string Videofilename = Guid.NewGuid().ToString() + "_" + media.FileName;
                    uniquevideoname = Path.Combine(uploadfoldervideo, Videofilename);
                    media.CopyTo(new FileStream(uniquevideoname, FileMode.Create));
                    return Videofilename;
                }
                else
                {
                    return "no media submitted";
                }
            }
            else
            {
                return "no media submitted";
            }
        }

        public void CreatePost(Post post)
        {

            context.Posts.Add(post);
            context.SaveChanges();
        }

        public string UpdatePost(Post post)
        {
            Post Postbefore = context.Posts.Find(post.Post_Id);
            string confirm = "";
            if (Postbefore != null)
            {
                Postbefore.Post_Type = post.Post_Type;
                Postbefore.Title = post.Title;
                Postbefore.Text = post.Text;
                Postbefore.Image_Name = post.Image_Name;
                Postbefore.Video_Name = post.Video_Name;
                Postbefore.Link = post.Link;
                Postbefore.User_Id = post.User_Id;
                Postbefore.Posted_When = post.Posted_When;
                Postbefore.Sub_Id = post.Sub_Id;
                Postbefore.Number_Of_Comments = post.Number_Of_Comments;
                Postbefore.Number_Of_DownVotes = post.Number_Of_DownVotes;
                Postbefore.Number_of_Upvotes = post.Number_of_Upvotes;
                Postbefore.Flair = post.Flair;
                context.SaveChanges();
                confirm = "success";
                return confirm;
            }
            else
            {
                confirm = "fail";
                return confirm;
            }
        }

        public string DeletePost(int Post_Id)
        {
            Post post = context.Posts.Find(Post_Id);
            string confirm = "";
            if (post != null)
            {
                Comment comments = context.Comments.FirstOrDefault(s => s.Post_Id == post.Post_Id);
                if(comments != null)
                {
                    context.Comments.Remove(comments);
                    context.SaveChanges();
                    context.Posts.Remove(post);
                    context.SaveChanges();
                    confirm = "success";
                    return confirm;
                }
                else
                {
                    context.Posts.Remove(post);
                    context.SaveChanges();
                    confirm = "success";
                    return confirm;
                }
                
            }
            else
            {
                confirm = "fail";
                return confirm;
            }
        }

        //public string GetMedia(int Id)
        //{
        //    string mediapath;
        //    Post post = context.Posts.Find(Id);
        //    if(post != null)
        //    {
        //        //if (!string.IsNullOrEmpty(post.Image_Name))
        //        //{
        //        //    mediapath = Path.Combine ("C:\\Users\\micha\\source\\repos\\Actual_Project_V3\\Actual_Project_V3\\wwwroot\\Images\\", post.Image_Name);
        //        //}
        //         if (!string.IsNullOrEmpty(post.Video_Name))
        //        {
        //            mediapath = Path.Combine("C:\\Users\\micha\\source\\repos\\Actual_Project_V3\\Actual_Project_V3\\wwwroot\\Videos\\", post.Video_Name);
        //        }
        //        else
        //        {
        //            mediapath = "contains no media ";
        //        }
        //        return mediapath;
        //    }
        //    else { return "No Post found"; }
        //}
    }
}
