using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public  interface ICommentRepository
    {
        string CreateComment(Comment comment);
        List<Comment> GetComment(int postId);
        List<Comment> GetUserComment(string Id);
        string UpdateComment(Comment comment);
        string DeleteComment(int commentId);
    }
}
