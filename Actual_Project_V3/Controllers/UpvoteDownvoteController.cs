using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Actual_Project_V3.Controllers
{
    public class UpvoteDownvoteController : Controller
    {
        private readonly Iupvotedownvote upvotedownvoteRepository;
        private readonly ISaveRepository SaveRepository;

        public UpvoteDownvoteController(Iupvotedownvote _upvotedownvoteRepository, ISaveRepository saveRepository)
        {
            upvotedownvoteRepository = _upvotedownvoteRepository;
            SaveRepository = saveRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostRate(string User_Id, int Id, int Rating, string Type)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = upvotedownvoteRepository.PostRate(User_Id, Id, Rating, Type);
                if (confirm != "No Post found" && confirm != "Comment not found" && confirm != "Unknown Type")
                {
                    return Ok(confirm);
                }
                else
                {
                    return NotFound(confirm);
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
        public IActionResult GetUpvotedDownvoted(string Id, string type)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                List<Post> ratedposts=upvotedownvoteRepository.GetUpvotedDownvoted(Id, type);
                List<PostReturn> returnposts = new List<PostReturn>();
                if(ratedposts != null)
                {
                    foreach (Post post in ratedposts)
                    {
                        if (post != null)
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
                            returnposts.Add(postReturn);

                        }
                        else
                        {
                            continue;
                        }
                    }
                    return Ok(returnposts);

                }
                else
                {
                    return NotFound("no posts");
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
