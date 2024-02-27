using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Actual_Project_V3.Controllers
{
    public class SaveController : Controller
    {
        private readonly ISaveRepository SaveRepository;
        private readonly Iupvotedownvote upvotedownvoteRepository;
        public SaveController(ISaveRepository _SaveRepository, Iupvotedownvote upvotedownvoteRepository)
        {
            SaveRepository = _SaveRepository;
            this.upvotedownvoteRepository = upvotedownvoteRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSave([FromBody] Save save)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = SaveRepository.AddSave(save);
                if (confirm == "success")
                {
                    return Ok(confirm);
                }
                else
                {
                    return BadRequest(confirm);
                }
            }
            else
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
            }
            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult GetSaves(string Id)
        {
            List<string> errors = new List<string>();            
            if (ModelState.IsValid)
            {
                List<PostReturn> postReturns = new List<PostReturn>();
                List<Post> saves = SaveRepository.GetSaves(Id);
                if (saves != null)
                {
                    foreach(Post post in saves)
                    {
                        bool upvote;
                        bool downvote;
                        string confirm = upvotedownvoteRepository.check_action(Id, post.Post_Id, "post");
                        if (confirm == "DownVote") { downvote = true; upvote = false; }
                        else if (confirm == "Upvote") { downvote = false; upvote = true; }
                        else { downvote = false; upvote = false; }
                        PostReturn postReturn = new PostReturn()
                        {
                            Post_Id = post.Post_Id,
                            Post_Type = post.Post_Type,
                            Title = post.Title,
                            Text = post.Text,
                            Image_Name = post.Image_Name,
                            Video_Name = post.Video_Name,
                            Link = post.Link,
                            Posted_When = post.Posted_When,
                            Sub_Id = post.Sub_Id,
                            User_Id = post.User_Id,
                            Number_Of_Comments = post.Number_Of_Comments,
                            Number_of_Upvotes = post.Number_of_Upvotes,
                            Number_Of_DownVotes = post.Number_Of_DownVotes,
                            Flair = post.Flair,
                            upvote_flag = upvote,
                            downvote_flag = downvote,
                            saved_flag = SaveRepository.saved(Id, post.Post_Id)
                        };
                        postReturns.Add(postReturn);
                    }
                    return new JsonResult(postReturns)
                    {
                        ContentType = "application/json",
                        StatusCode = 200
                    };
                }
                return NotFound("Post not found");
            }
            else
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
            }
            return BadRequest(errors);

            /*
             * bool upvote;
                     bool downvote;
                     string confirm = upvotedownvoteRepository.check_action(Id, post.Post_Id, "post");
                     if (confirm == "DownVote") { downvote = true; upvote = false; }
                     else if (confirm == "Upvote") { downvote = false; upvote = true; }
                     else { downvote = false; upvote = false; }
                     PostReturn postReturn = new PostReturn()
                     {
                         Post_Id = post.Post_Id,
                         Post_Type = post.Post_Type,
                         Title = post.Title,
                         Text = post.Text,
                         Image_Name = post.Image_Name,
                         Video_Name = post.Video_Name,
                         Link = post.Link,
                         Posted_When = post.Posted_When,
                         Sub_Id = post.Sub_Id,
                         User_Id = post.User_Id,
                         Number_Of_Comments = post.Number_Of_Comments,
                         Number_of_Upvotes = post.Number_of_Upvotes,
                         Number_Of_DownVotes = post.Number_Of_DownVotes,
                         Flair = post.Flair,
                         upvote_flag = upvote,
                         downvote_flag = downvote,
                         saved_flag = SaveRepository.saved(Id, post.Post_Id)
                     };
                     posts.Add(postReturn);
             */

        }


        [HttpPost]
        public IActionResult UnSave([FromBody] Save save)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = SaveRepository.UnSave(save);
                if (confirm == "success")
                {
                    return Ok(confirm);
                }
                else
                {
                    return BadRequest(confirm);
                }
            }
            else
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
            }
            return BadRequest(errors);
        }
    }
}
