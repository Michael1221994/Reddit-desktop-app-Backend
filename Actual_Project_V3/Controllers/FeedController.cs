using Actual_Project_V3.ExtensionMethods;
using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actual_Project_V3.Controllers
{
    public class FeedController : Controller
    {
        private readonly IFeedRepository feedRepository;

        public FeedController(IFeedRepository _feedRepository)
        {
            feedRepository = _feedRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetHomeFeed(string Id)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                List<Post> todayOrderedPosts = feedRepository.GetHomeFeed(Id);
                if (todayOrderedPosts != null)
                {
                    return new JsonResult(todayOrderedPosts)
                    {
                        ContentType = "application/json",
                        StatusCode = 200
                    };
                }
                else
                {
                    return NotFound("nothing");
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
        public IActionResult GetPopularFeed(string Id)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                List<Post> popularFeedOrdered = feedRepository.GetPopularFeed(Id);
                if (popularFeedOrdered != null)
                {
                    return new JsonResult(popularFeedOrdered)
                    {
                        ContentType = "application/json",
                        StatusCode = 200
                    };
                }else { return NotFound("nothing"); }               
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
        public IActionResult GetAllFeed()
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                List<Post> allFeedOrdered = feedRepository.GetAllFeed();
                if (allFeedOrdered != null)
                {
                    return new JsonResult(allFeedOrdered)
                    {
                        ContentType = "application/json",
                        StatusCode = 200
                    };
                }
                else { return NotFound("nothing"); }
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
        public IActionResult PostRate(int Rating, int Id, string Type)//what about for comment. how do we upvote it ?
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = feedRepository.PostRate(Rating, Id, Type);
                if (confirm == "success")
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

    }
}
