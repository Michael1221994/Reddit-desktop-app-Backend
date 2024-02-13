using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actual_Project_V3.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository commentRepository;

        public CommentController(ICommentRepository _commentRepository)
        {
            commentRepository = _commentRepository;
        }
            public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody]Comment comment)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = commentRepository.CreateComment(comment);
                //if (confirm == "success")
                //{
                    return Ok(confirm);
                //}
                //else
                //{
                //    return BadRequest(confirm);
                //}
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
        public ActionResult<List<Comment>> GetComment(int postId)
        {
            List<Comment> comments = commentRepository.GetComment(postId);
            if (comments != null)
            {
                return comments;
            }
            return NotFound("Post not found");
        }

        [HttpGet]
        public ActionResult<List<Comment>> GetUserComment(string User_Id)
        {
            List<Comment> comments = commentRepository.GetUserComment(User_Id);
            if (comments != null)
            {
                return comments;
            }
            return NotFound("User not found");

        }

        [HttpPost]
        public IActionResult UpdateComment([FromBody] Comment comment)
        {
            string confirm=commentRepository.UpdateComment(comment);
            if(confirm== "success")
            {
                return Ok(confirm);
            }
            else
            {
                return NotFound(confirm);
            }

        }


        [HttpPost]
        public  IActionResult DeleteComment(int Comment_Id)
        {
            string confirm=commentRepository.DeleteComment(Comment_Id);

            if (confirm == "success")
            {
                return Ok(confirm);
            }
            else
            {
                return NotFound(confirm);
            }
        }
    }
}
