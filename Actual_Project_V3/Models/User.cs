using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Actual_Project_V3.Models
{
    public class User : IdentityUser
    {
        //[Key]
        //public int User_Id { get; set; }
        //[Required]
        //public string User_Name { get; set; }
        //[Required]

        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]

        //public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Description { get; set; }


        //public override Guid Id { get; set; }

        //public User()
        //{
        //    Id = Guid.NewGuid(); // Generate a new Guid for each user
        //}
        //NAVIGATION
        [JsonIgnore]
        public List<JoinedSubreddits>? JoinedSubreddits { get; set; }
        [JsonIgnore]
        public List<Subreddit>? Subreddits { get; set; }
        [JsonIgnore]
        public List<Post>? Posts { get; set; }
        [JsonIgnore]
        public List<Comment>? Comments { get; set; }       
        [JsonIgnore]
        public List<UpvoteDownvote>? UpvoteDownvotes { get; set; }

        public List<History>? History { get; set; }
        public List<Save>? saves { get; set; }

        //public Subreddit Subreddit { get; set; }
        //public List<Subreddit> OwnedSubreddits { get; set; }
        //public <Posts> UserPosts { get; set; }
    }
}
