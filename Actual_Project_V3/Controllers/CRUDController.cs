using Actual_Project_V3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Claims;
using Actual_Project_V3.Repositories;

namespace Actual_Project_V3.Controllers
{
    public class CRUDController : Controller
    {
        private readonly ICRUDRepository repository;

        public CRUDController(ICRUDRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MediaSave(IFormFile media, string type)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm= repository.MediaSave(media, type);
                return Ok(confirm);
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
        public IActionResult CreatePost([FromBody] Post post)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                repository.CreatePost(post);
                return Ok("success");
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
        public IActionResult UpdatePost([FromBody] Post post)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = repository.UpdatePost(post);
                if (confirm == "success")
                {
                    return Ok("success");
                }
                else
                {
                    return NotFound("Post not found");
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
        public IActionResult DeletePost(int Post_Id)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = repository.DeletePost(Post_Id);
                if (confirm == "success")
                {
                    return Ok("Deleted");
                }
                else
                {
                    return NotFound("Post not found");
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

        //[HttpGet]
        //public IActionResult GetMedia(int Post_Id)
        //{
        //    string path = repository.GetMedia(Post_Id);
        //    if (System.IO.File.Exists(path))
        //    {
        //        string[] parts=path.Split('.');
        //        string extension = parts[1];                
        //        return PhysicalFile(path, "."+extension);
        //    }
        //    else if (path == "No Post found")
        //    {
        //        return BadRequest("No Post exists by that Id");
        //    }
        //    else
        //    {
        //        return NotFound("No media found for the Post");
        //    }
        //}
    }
}
