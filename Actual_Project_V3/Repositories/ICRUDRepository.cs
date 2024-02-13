using Actual_Project_V3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actual_Project_V3.Repositories
{
    public interface ICRUDRepository
    {
        string MediaSave(IFormFile media, string type);
        void CreatePost(Post post);
        string UpdatePost(Post post);
        string DeletePost(int Post_Id);
        //string GetMedia(int Id);
    }
}
