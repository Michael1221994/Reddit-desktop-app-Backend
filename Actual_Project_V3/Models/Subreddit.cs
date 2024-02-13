using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Actual_Project_V3.Models
{
    public class Subreddit
    {
        [Key]
        public int Sub_Id { get; set; }
        public string Subreddit_Genre { get; set; }

        [ForeignKey("Id")]
        public string User_Id { get; set; }
        public string Subreddit_Name { get; set;}
        public string Subreddit_Alt_Name { get; set; }
        public string Subreddit_Description { get; set; }
        public string Sub_IconImg_Name { get; set; }
        public string Sub_BackgroundImg_Name { get; set; }

        [JsonIgnore]
        public int? Number_Of_Members { get; set; }
        //public List<string>? Members { get; set; }
        public List<JoinedSubreddits>? JoinedSubreddits { get; set; }
        //public List<string> Moderators { get; set; }
        public DateTime Created_When { get; set; }
        public List<string> Allowed_Flairs { get; set; }

        //Navigation
        public User? OwnerUser { get; set; }
        [JsonIgnore]
        public List<Post>? Posts { get; set; }
        [JsonIgnore]
        public List<Comment>? Comments {  get; set; } 

    }
}
