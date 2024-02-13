using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Actual_Project_V3.Controllers
{
    public class SaveController : Controller
    {
        private readonly ISaveRepository SaveRepository;
        public SaveController(ISaveRepository _SaveRepository)
        {
            SaveRepository = _SaveRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSave([FromBody] Save save)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = SaveRepository.AddSave(save);
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
        public ActionResult<List<int>> GetSaves(string Id)
        {
            List<string> errors = new List<string>();
            List<int> saves = SaveRepository.GetSaves(Id);
            if (ModelState.IsValid)
            {
                if (saves != null)
                {
                    return new JsonResult(saves)
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
        public IActionResult UnSave([FromBody] Save save)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                string confirm = SaveRepository.UnSave(save);
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
