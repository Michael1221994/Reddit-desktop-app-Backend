using Actual_Project_V3.Models;
namespace Actual_Project_V3.Repositories
{
    public interface Iupvotedownvote
    {
        string PostRate(string User_Id, int Id, int Rating, string Type);
        string check_action(string Id, int Post_Id, string Type);
    }
}
