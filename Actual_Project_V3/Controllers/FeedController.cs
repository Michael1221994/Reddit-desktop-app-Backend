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
        private readonly ISaveRepository SaveRepository;
        private readonly Iupvotedownvote upvotedownvoteRepository;

        public FeedController(IFeedRepository _feedRepository, ISaveRepository _SaveRepository, Iupvotedownvote _upvotedownvoteRepository)
        {
            feedRepository = _feedRepository;
            SaveRepository = _SaveRepository;
            upvotedownvoteRepository = _upvotedownvoteRepository;
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
                List<PostReturn> posts = new List<PostReturn>();
                if (todayOrderedPosts != null)
                {
                    foreach (Post post in todayOrderedPosts)
                    {
                        bool upvote;
                        bool downvote;
                        string confirm = upvotedownvoteRepository.check_action(Id, post.Post_Id,"post");
                        if (confirm == "DownVote") { downvote = true; upvote = false; }
                        else if(confirm== "Upvote") { downvote = false; upvote = true; }
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
                    }
                    return new JsonResult(posts)
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
                List<PostReturn> posts = new List<PostReturn>();
                if (popularFeedOrdered != null)
                {
                    foreach (Post post in popularFeedOrdered)
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
                        posts.Add(postReturn);
                    }
                    return new JsonResult(posts)
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
        public IActionResult GetAllFeed(string Id)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                List<Post> allFeedOrdered = feedRepository.GetAllFeed();
                List<PostReturn> posts = new List<PostReturn>();
                if (allFeedOrdered != null)
                {
                    foreach (Post post in allFeedOrdered)
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
                        posts.Add(postReturn);
                    }
                        return new JsonResult(posts)
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

        //[HttpPost]
        //public IActionResult PostRate(string User_Id, int Id, int Rating, string Type)
        //{
        //    List<string> errors = new List<string>();
        //    if (ModelState.IsValid)
        //    {
        //        string confirm = feedRepository.PostRate(User_Id,Id,Rating, Type);
        //        if (confirm != "No Post found" && confirm!= "Comment not found" && confirm!= "Unknown Type")
        //        {
        //            return Ok(confirm);
        //        }
        //        else
        //        {
        //            return NotFound(confirm);
        //        }
        //    }
        //    else
        //    {
        //        foreach (var modelStateEntry in ModelState.Values)
        //        {
        //            foreach (var error in modelStateEntry.Errors)
        //            {
        //                errors.Add(error.ErrorMessage);
        //            }
        //        }
        //    }
        //    return BadRequest(errors);

        //}

    }
}
