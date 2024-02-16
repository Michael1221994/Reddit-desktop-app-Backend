using Actual_Project_V3.Models;
using Actual_Project_V3.Repositories;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actual_Project_V3.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;
        private SignInManager<User> signInManager;
        public UserController(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, SignInManager<User> signInManager)        
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            Dictionary<string, object> KeyValue = new Dictionary<string, object>();
            string confirm;
            bool emailexists =  await userRepository.checkemailexists(user.Email);//kinda not working
            bool usernameexists= await userRepository.checkusernameexists(user.UserName);
            bool passwordexists = await userRepository.checkpasswordexists(user.Password);
            //if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.UserName))
            //{
            
            if (!ModelState.IsValid) {

                KeyValue["modelstatefail"] = "true";
            }
            else
            {
                KeyValue["modelstatefail"] = "false";
                if (emailexists == false && usernameexists == false && passwordexists == true)
                {
                    var (result, user_Id) = await userRepository.SignUp(user);
                    if (result.Succeeded)
                    {
                        KeyValue["success"] = "true";
                        KeyValue["UserId"] = user_Id;
                    }
                    else
                    {
                        //foreach (IdentityError error in result.Errors)
                        //    ModelState.AddModelError("", error.Description);
                        KeyValue["success"] = "false";//couldn't save
                    } //confirm = "error";

                }
                else if (usernameexists == true )
                {
                    KeyValue["UsernameExists"] = "true";
                }
                else if (emailexists == true )
                {
                    KeyValue["EmailExists"] = "true";
                }
                else
                {
                    KeyValue["UsernameExists"] = "true";
                    KeyValue["EmailExists"] = "true";
                }
            }
           
            //    if (ModelState.IsValid)
            //    {
            //        User user1 = new User { User_Name = users.Email, Email = users.Email };
            //        //IdentityResult result = await userRepository.SignUp(users);
            //        if (!result.Succeeded)
            //        {
            //            foreach (var error in result.Errors)
            //            {
            //                ModelState.AddModelError(string.Empty, error.Description);
            //            }
            //            confirm = "couldnt add";
            //        }
            //        else
            //        {
            //            confirm = "success";
            //        }
            //        ModelState.Clear();
            //    }
            //}
            //else if (emailexists == "true")
            //{
            //    confirm = "email already exists";
            //}
            //else if (usernameexists == "true")
            //{
            //    confirm = "username already exists";
            //}
            //else confirm = "both email and username already exist";

            return new JsonResult(KeyValue)
            {
                    ContentType = "application/json",
                    StatusCode = 200
            };

            ////Dictionary<string, object> ReceivedKey = await userRepository.SignUp(user);
            //string confirm = await userRepository.SignUp(user);
            ////the key "success" shows if the user has been created "true" or has failed "false"
            //return new JsonResult(confirm)
            //    {
            //        ContentType = "application/json",
            //        StatusCode = 200
            //    };
        }

        [HttpPost]
        public  async Task<IActionResult> Update([FromBody] User user)
        {
            string confirm = "";
            if (user != null && !string.IsNullOrEmpty(user.Password))
            {
                confirm = await userRepository.Update(user);
                if (confirm == "success")
                {
                    return Ok();
                }
                else if (confirm == "no user found")
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();//couldn't be updated
                }
            }
            return BadRequest("sth is wrongg");
            
           
        }

        [HttpPost]
        public  async Task<ActionResult> Delete(string model)//it accepts string or else use UserIdModel
        {
            if (string.IsNullOrEmpty(model))
            {
                return BadRequest("Id is null or empty");
            }
            string confirm =  await userRepository.Delete(model);
            if (confirm == "deleted")
            {
                return Ok("it works");
            }
            else if (confirm == "no user found")
            {
                return NotFound("not found");
            }
            else
            {
                return BadRequest("Failed to delete user");//couldn't be deleted
            }
           
        }

        [HttpGet]
        public async Task<ActionResult> Login(string UserName, string Password)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                var(login,user_Id)= await userRepository.Login(UserName, Password);
                if (login==true)
                {
                    var response = new { Message = "Login successful", UserId = user_Id };
                    return Ok(response);
                }
                else { return NotFound("Password or Username not found"); }
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


