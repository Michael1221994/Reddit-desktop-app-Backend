using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Actual_Project_V3.Controllers
{
    public class UpvoteDownvoteController : Controller
    {
        private readonly Iupvotedownvote upvotedownvoteRepository;

        public UpvoteDownvoteController(Iupvotedownvote _upvotedownvoteRepository)
        {
            upvotedownvoteRepository = _upvotedownvoteRepository;
            
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
                return Ok(ratedposts);
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
