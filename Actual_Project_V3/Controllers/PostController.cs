using Microsoft.AspNetCore.Mvc;
using Actual_Project_V3.Models;
using Actual_Project_V3.ExtensionMethods;
using Microsoft.Extensions.Hosting;
using Actual_Project_V3.Repositories;
using Microsoft.Extensions.Options;
namespace Actual_Project_V3.Controllers
{
    public class PostController : Controller
    {
        private readonly IFeedRepository feedRepository;
        private readonly IPostRepository postRepository;
        private readonly ISaveRepository SaveRepository;
        private readonly Iupvotedownvote upvotedownvoteRepository;

        public PostController(IPostRepository _postRepository, IFeedRepository _feedRepository, ISaveRepository _SaveRepository, Iupvotedownvote _upvotedownvoteRepository)
        {
            postRepository = _postRepository;
            feedRepository = _feedRepository;
            SaveRepository = _SaveRepository;
            upvotedownvoteRepository = _upvotedownvoteRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetHotPost(string Id)
        {
            List<Post> todayHotOrderedPosts = postRepository.GetHotPosts();
            List<PostReturn> posts = new List<PostReturn>();
            if (todayHotOrderedPosts != null)
            {
                foreach (Post post in todayHotOrderedPosts)
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
            else
            {
                return NotFound("None");
            }
            
        }

        [HttpGet]
        public IActionResult GetNewPost(string Id)
        {
            List<Post> todayNewOrderedPosts = postRepository.GetNewPosts();
            List<PostReturn> posts = new List<PostReturn>();
            if (todayNewOrderedPosts != null)
            {
                foreach (Post post in todayNewOrderedPosts)
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
            else
            {
                return NotFound("None");
            }
            
        }

        [HttpGet]
        public IActionResult GetTopPost(string when, string Id)
        {
            List<Post> orderedPosts = postRepository.GetTopPosts(when);
            List<PostReturn> posts = new List<PostReturn>();
            if (orderedPosts != null) 
            { 
                foreach (Post post in orderedPosts)
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
            else
            {
                return NotFound("None");
            }
            
        }

        [HttpGet]
        public IActionResult GetControversialPost(string when, string Id)
        {
            List<Post> orderedPosts = postRepository.GetControversialPosts(when);
            List<PostReturn> posts = new List<PostReturn>();
            if (orderedPosts != null)
            {
                foreach (Post post in orderedPosts)
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
            else { return NotFound("None"); }
        }

        [HttpGet]
        public IActionResult GetSubPosts(int Sub_Id, string filter, string filterwithdate, string Id)
        {
            List<Post> filteredPosts = postRepository.GetSubPosts(Sub_Id, filter, filterwithdate);
            List<PostReturn> posts = new List<PostReturn>();
            if (filteredPosts != null)
            {
                foreach (Post post in filteredPosts)
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
            else
            {
                return NotFound("None");//what it returns might be a problem in that case remove builder.Services.AddControllers().AddJsonOptions(options =>
                                            //{
                                            //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                                            //});  from Program.cs and use [JsonIgnore] on either subreddit consult chatgpt answer might be already written
            }
            
        }

        [HttpGet]
        public IActionResult GetUserPosts(string Id)
        {
            List<Post> UserPosts = postRepository.GetUserPosts(Id);
            List<PostReturn> posts = new List<PostReturn>();
            if (UserPosts != null)
            {
                foreach (Post post in UserPosts)
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
            else return NotFound("Nothing posted by this user");

        }

        [HttpGet]
        public IActionResult GetPost(string Id, int Post_Id)
        {
            Post post = postRepository.GetPost(Post_Id);            
            if(post != null)
            {
                bool upvote=false;
                bool downvote=false;
                string confirm = upvotedownvoteRepository.check_action(Id, post.Post_Id, "post");
                if (confirm == "DownVote") { downvote = true; upvote = false; }
                else if (confirm == "Upvote") { downvote = false; upvote = true; }
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
                return new JsonResult(postReturn)
                {
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }
            else
            {
                return NotFound("No post");
            }

        }


    }
}
