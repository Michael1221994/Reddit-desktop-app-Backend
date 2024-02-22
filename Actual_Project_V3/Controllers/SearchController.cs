using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actual_Project_V3.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchRepository SearchRepository;
        public SearchController(ISearchRepository _SearchRepository)
        {
            SearchRepository = _SearchRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string searchterm)
        {
            List<string> errors = new List<string>();
            SearchResults searchList = SearchRepository.Search(searchterm,3);
            if (ModelState.IsValid)
            {
                return Ok(searchList);
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
