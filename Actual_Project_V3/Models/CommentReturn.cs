using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Actual_Project_V3.Models
{
    public class CommentReturn
    {
        public int Comment_Id { get; set; }        
        public string User_Id { get; set; }        
        public int Post_Id { get; set; }        
        public int Sub_Id { get; set; }
        public string Comments { get; set; }
        public int? Reply_To { get; set; }
        //public List<int>? Thread_Order { get; set; }
        public DateTime Commented_When { get; set; }
        public int Downvote_Count { get; set; }
        public int Upvote_Count { get; set; }
        public bool upvote_flag { get; set; }
        public bool downvote_flag { get; set; }
    }
}
