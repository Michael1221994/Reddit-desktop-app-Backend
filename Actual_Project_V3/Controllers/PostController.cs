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
        private readonly IPostRepository postRepository;

        public PostController(IPostRepository _postRepository)
        {
            postRepository = _postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetHotPost()
        {
            List<Post> todayHotOrderedPosts = postRepository.GetHotPosts();
            if(todayHotOrderedPosts != null)
            {
                return new JsonResult(todayHotOrderedPosts)
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
        public IActionResult GetNewPost()
        {
            List<Post> todayNewOrderedPosts = postRepository.GetNewPosts();
            if(todayNewOrderedPosts != null)
            {
                return new JsonResult(todayNewOrderedPosts)
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
        public IActionResult GetTopPost(string when)
        {
            List<Post> orderedPosts = postRepository.GetTopPosts(when);
            if(orderedPosts != null)
            {
                return new JsonResult(orderedPosts)
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
        public IActionResult GetControversialPost(string when)
        {
            List<Post> orderedPosts = postRepository.GetControversialPosts(when);
            if(orderedPosts != null)
            {
                return new JsonResult(orderedPosts)
                {
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }
            else { return NotFound("None"); }
        }

        [HttpGet]
        public IActionResult GetSubPosts(int Sub_Id, string filter, string filterwithdate)
        {
            List<Post> filteredPosts = postRepository.GetSubPosts(Sub_Id, filter, filterwithdate);
            if (filteredPosts != null)
            {
                return new JsonResult(filteredPosts)
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


    }
}
