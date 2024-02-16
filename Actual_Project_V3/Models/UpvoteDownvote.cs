using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actual_Project_V3.Models
{
    public class UpvoteDownvote
    {
        [Key]
        public int Rate_Id { get; set; }
        [ForeignKey("Id")]
        public string User_Id {get; set; }
        [ForeignKey("Post_Id")]
        public int? Post_Id { get; set; }
        [ForeignKey("Comment_Id")]
        public int? Comment_Id { get; set; }
        public int Rating { get; set; } // if rating=1 it means upvote if rating=0 it means downvote
        
        //Navigation
        public Post Post { get; set; }
        public User User { get; set; }
        public Comment Comments { get; set; }
    }
}
