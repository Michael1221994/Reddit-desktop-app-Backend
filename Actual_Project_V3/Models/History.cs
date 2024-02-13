using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actual_Project_V3.Models
{
    public class History
    {
        [ForeignKey("Id")]
        public string User_Id { get; set; }
        [ForeignKey("Post_Id")]
        public int Post_Id { get; set; }

        //Navigation
        public User? User { get; set; }
        public Post? Posts { get; set; }
    }
}
