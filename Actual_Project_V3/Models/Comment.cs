using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Actual_Project_V3.Models
{
    public class Comment
    {
        [Key]
        public int Comment_Id { get; set; }

        [ForeignKey("Id")]
        public string User_Id { get; set; }
        [ForeignKey("Post_Id")]
        public int Post_Id { get; set; }
        [ForeignKey("Sub_Id")]
        public int Sub_Id { get; set; }
        public string Comments {  get; set; }
        [ForeignKey("Id")]
        public string Reply_To{get; set;}
        //public List<int>? Thread_Order { get; set; }
        public DateTime Commented_When { get; set; }
        public int Downvote_Count { get; set; }
        public int Upvote_Count { get; set; }

        //Navigation
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public Post? Post { get; set; }
        [JsonIgnore]
        public Subreddit? Subreddit { get; set; }
        
        public List<UpvoteDownvote>? UpvoteDownvotes { get; set; }
        


    }
}
