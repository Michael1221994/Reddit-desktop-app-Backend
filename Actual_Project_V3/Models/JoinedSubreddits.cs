using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actual_Project_V3.Models
{
    public class JoinedSubreddits
    {
        [Key]
        public int Id { get; set; } 
        [ForeignKey("Id")]
        public string User_Id { get; set; }
        [ForeignKey("Sub_Id")]
        public int sub_id {  get; set; }

        public User? user { get; set; }
        public Subreddit? subreddit { get; set; }
    }
}
