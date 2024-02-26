using Actual_Project_V3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actual_Project_V3.Repositories
{
    public interface ISaveRepository
    {
        string AddSave( Save save);
        List<Post> GetSaves(string Id);
        string UnSave(Save save);
        bool saved(string Id, int Post_Id);
    }
}
