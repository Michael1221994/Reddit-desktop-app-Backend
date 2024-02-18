using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.Design;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actual_Project_V3.Controllers
{
    public class CommentController : Controller
    {
        private readonly IFeedRepository feedRepository;
        private readonly ICommentRepository commentRepository;
        private readonly Iupvotedownvote upvotedownvoteRepository;

        public CommentController(Iupvotedownvote _upvotedownvoteRepository, IFeedRepository _feedRepository, ICommentRepository _commentRepository)
        {
            feedRepository = _feedRepository;
            commentRepository = _commentRepository;
            upvotedownvoteRepository = _upvotedownvoteRepository;
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
        public IActionResult GetComment(string Id,int postId)
        {
            List<Comment> comments = commentRepository.GetComment(postId);
            List<CommentReturn> returnedcomments = new List<CommentReturn>();
            if (comments != null)
            {
                
                    foreach (Comment comment in comments)
                    {
                        bool upvote;
                        bool downvote;
                        string confirm = upvotedownvoteRepository.check_action(Id, comment.Comment_Id,"comment");
                        if (confirm == "DownVote") { downvote = true; upvote = false; }
                        else if(confirm== "Upvote") { downvote = false; upvote = true; }
                        else { downvote = false; upvote = false; }
                        CommentReturn commentreturn = new CommentReturn()
                        {
                            Comment_Id= comment.Comment_Id,
                            User_Id=comment.User_Id,
                            Post_Id=comment.Post_Id,
                            Sub_Id=comment.Sub_Id,
                            Comments = comment.Comments,
                            Reply_To = comment.Reply_To,
                            Commented_When = comment.Commented_When,
                            Downvote_Count= comment.Downvote_Count,
                            Upvote_Count = comment.Upvote_Count,
                            upvote_flag= upvote,
                            downvote_flag=downvote
                        };
                        returnedcomments.Add(commentreturn);
                    }

                return new JsonResult(returnedcomments)
                {
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }
            return NotFound("Post not found");
        }

        [HttpGet]
        public IActionResult GetUserComment(string Id)
        {
            List<Comment> comments = commentRepository.GetUserComment(Id);
            List<CommentReturn> returnedcomments= new List<CommentReturn>();
            if (comments != null)
            {
                foreach (Comment comment in comments)
                {
                    bool upvote;
                    bool downvote;
                    string confirm = upvotedownvoteRepository.check_action(Id, comment.Comment_Id, "comment");
                    if (confirm == "DownVote") { downvote = true; upvote = false; }
                    else if (confirm == "Upvote") { downvote = false; upvote = true; }
                    else { downvote = false; upvote = false; }
                    CommentReturn commentreturn = new CommentReturn()
                    {
                        Comment_Id = comment.Comment_Id,
                        User_Id = comment.User_Id,
                        Post_Id = comment.Post_Id,
                        Sub_Id = comment.Sub_Id,
                        Comments = comment.Comments,
                        Reply_To = comment.Reply_To,
                        Commented_When = comment.Commented_When,
                        Downvote_Count = comment.Downvote_Count,
                        Upvote_Count = comment.Upvote_Count,
                        upvote_flag = upvote,
                        downvote_flag = downvote
                    };
                    returnedcomments.Add(commentreturn);
                }
                return new JsonResult(returnedcomments)
                {
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }
            return NotFound("no comments found");

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
