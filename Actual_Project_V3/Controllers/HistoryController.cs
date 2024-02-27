using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actual_Project_V3.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryRepository HistoryRepository;
        private readonly ISaveRepository SaveRepository;
        private readonly Iupvotedownvote upvotedownvoteRepository;
        public HistoryController(IHistoryRepository _HistoryRepository, ISaveRepository _SaveRepository, Iupvotedownvote upvotedownvoteRepository)
        {
            HistoryRepository = _HistoryRepository;
            SaveRepository = _SaveRepository;
            this.upvotedownvoteRepository = upvotedownvoteRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPostHistory([FromBody] History history)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = HistoryRepository.PostHistory(history);
                if (confirm == "success" || confirm== "already saved")
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
        public IActionResult GetHistory(string Id)
        {
            List<string> errors = new List<string>();
            List<PostReturn> postReturns = new List<PostReturn>();
            List<Post> history = HistoryRepository.GetHistory(Id);
            if (ModelState.IsValid)
            {
                if (history != null)
                {
                    foreach(Post post in history)
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

        }

        [HttpPost]
        public IActionResult ClearHistory(string Id)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = HistoryRepository.ClearHistory(Id);
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
