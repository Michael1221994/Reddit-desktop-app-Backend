using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actual_Project_V3.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryRepository HistoryRepository;
        public HistoryController(IHistoryRepository _HistoryRepository)
        {
            HistoryRepository = _HistoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPostHistory([FromBody] History history)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = HistoryRepository.PostHistory(history);
                if (confirm == "success")
                {
                    return Ok(confirm);
                }
                else
                {
                    return BadRequest(confirm);
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
        public ActionResult<List<int>> GetHistory(string Id)
        {
            List<string> errors = new List<string>();
            List<int> history = HistoryRepository.GetHistory(Id);
            if (ModelState.IsValid)
            {
                if (history != null)
                {
                    return new JsonResult(history)
                    {
                        ContentType = "application/json",
                        StatusCode = 200
                    };
                }
                return NotFound("Post not found");
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
        public IActionResult ClearHistory(string Id)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = HistoryRepository.ClearHistory(Id);
                if (confirm == "success")
                {
                    return Ok(confirm);
                }
                else
                {
                    return BadRequest(confirm);
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
