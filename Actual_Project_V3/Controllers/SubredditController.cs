using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actual_Project_V3.Controllers
{
    public class SubredditController : Controller
    {
        private readonly ISubredditRepository _subredditRepository;

        public SubredditController(ISubredditRepository subredditRepository)
        {
            _subredditRepository = subredditRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult JoinSubreddit([FromBody] JoinedSubreddits JS)
        {
            string confirm;
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                confirm= _subredditRepository.JoinSubreddit(JS.sub_id, JS.User_Id);
                if (confirm == "success")
                {
                    return Ok("Joined!");
                }
                else if(confirm == "fail")
                {
                    return NotFound("could not find subreddit");
                }
                else
                {
                    return BadRequest("couldn't join");
                }
            }
            else {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                };
                return BadRequest(errors);
            }
        }

        [HttpPost]
        public IActionResult LeaveSubreddit([FromBody] JoinedSubreddits JS)
        {
            string confirm;
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                confirm = _subredditRepository.LeaveSubreddit(JS.sub_id ,JS.User_Id);
                if (confirm == "success")
                {
                    return Ok("left subreddit!");
                }
                else if (confirm == "fail")
                {
                    return NotFound("could not find subreddit");
                }
                else
                {
                    return BadRequest("couldn't leave");
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
                };
                return BadRequest(errors);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubreddit([FromBody] Subreddit subreddit)
        {
            string confirm;
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                confirm=await _subredditRepository.CreateSubreddit(subreddit);
                if (confirm == "saved")
                {
                    return Ok("It workss");
                }
                else if (confirm == "subreddit name already exist")
                {
                    return BadRequest("subreddit name already exist");
                }
                else
                {
                    return BadRequest("not saved");
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
                return BadRequest(errors);
            }
           
        }

        [HttpPost]
        public IActionResult UpdateSubreddit([FromBody] Subreddit subreddit)
        {
            //if (ModelState.IsValid)
            //{
                string confirm=_subredditRepository.UpdateSubreddit(subreddit);
                if (confirm == "success")
                {
                    return Ok("successful");
                }
                else if(confirm =="fail")
                {
                    return NotFound("subreddit not found");
                }
                else { return BadRequest(); }
                 
            //}
            //return BadRequest(ModelState); 
        }

        [HttpPost]
        public IActionResult DeleteSubreddit( int sub)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = _subredditRepository.DeleteSubreddit(sub);
                if (confirm == "success")
                {
                    return Ok("Deleted");
                }
                else
                {
                    
                    return NotFound("subreddit not found");
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
        public IActionResult GetSubInfo( int subredditId)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                Subreddit subreddit = _subredditRepository.GetSubreddit(subredditId);
                if (subreddit == null)
                {
                    return NotFound("couldn't find");
                }
                else
                {
                    return Ok(subreddit);
                    
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
        //[HttpPost]
        //public async Task<IActionResult> SignUp( [FromBody] User user)
        //{
        //    string confirm = "";
        //    if(string.IsNullOrEmpty(user.UserName))
        //    {
        //        confirm = "wagwan";
        //    }
        //    if (user==null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
        //    {
        //        confirm = "parameters cannot be null";
        //    }
        //    else
        //    {
        //        User appuser = new User()
        //        {

        //            UserName = user.UserName,
        //            Email = user.Email,
        //        };
        //        IdentityResult result = await UsrMgr.CreateAsync(appuser, user.Password);
        //        if (result.Succeeded)
        //        {
        //            confirm = "success";
        //        }
        //        else { confirm = "fail"; }
        //    }


        //    return new JsonResult(confirm)
        //    {
        //        ContentType = "application/json",
        //        StatusCode = 200
        //    };
        //}
    }
}
