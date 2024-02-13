using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Actual_Project_V3.Models
{
    public class Post
    {
        [Key]
        public int Post_Id { get; set; }
        public string Post_Type { get; set;}
        public string Title { get; set;}
        public string Text { get; set;}
        public string? Image_Name { get; set;}
        public string? Video_Name { get; set;}
        public string? Link { get; set;}
        //public int User_Id { get; set;}
        public DateTime Posted_When { get; set;}
        [ForeignKey("Sub_Id")]
        public int Sub_Id { get; set;}

        [ForeignKey("Id")]
        public string User_Id { get; set; }
        public int Number_Of_Comments { get; set;}
        public int Number_of_Upvotes { get; set;}
        public int Number_Of_DownVotes { get; set;}
        public List<string> Flair {  get; set;}

        //Navigation
        public User? User { get; set; }

        [JsonIgnore]
        public Subreddit? Subreddit { get; set; }
        public List<UpvoteDownvote>? UpvoteDownvotes { get; set;}
        public List<Comment>? Comments { get; set;}
        public List<History>? History { get; set; }
        public List<Save>? saves { get; set; }

    }
}
