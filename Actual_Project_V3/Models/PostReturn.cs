using System.ComponentModel.DataAnnotations.Schema;

namespace Actual_Project_V3.Models
{
    public class PostReturn
    {
        public int Post_Id { get; set; }
        public string Post_Type { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string? Image_Name { get; set; }
        public string? Video_Name { get; set; }
        public string? Link { get; set; }
        //public int User_Id { get; set;}
        public DateTime Posted_When { get; set; }
        public int Sub_Id { get; set; }
        public string User_Id { get; set; }
        public int Number_Of_Comments { get; set; }
        public int Number_of_Upvotes { get; set; }
        public int Number_Of_DownVotes { get; set; }
        public bool upvote_flag {  get; set; }
        public bool downvote_flag { get; set; }
        public bool saved_flag { get; set; }
        public List<string> Flair { get; set; }
    }
}
