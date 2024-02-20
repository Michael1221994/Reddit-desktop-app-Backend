using Actual_Project_V3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Actual_Project_V3.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserManager<User> UsrMgr;
        private readonly Context context;
        private readonly IPasswordHasher<User> passwordHasher;
        public UserRepository( UserManager<User> userManager, IPasswordHasher<User> passwordHasher, Context _context)
        {
            UsrMgr = userManager;
            this.passwordHasher = passwordHasher;
            this.context = _context;

        }
        //public bool checkemailexists(string Email)
        //{
        //    bool email_exists = false;
        //    User existingEmailUser = context.Users.Find(Email);
        //    if(existingEmailUser == null)
        //    {
        //        email_exists= true;
        //    }
        //    else
        //    {
        //        email_exists = false;
        //    }
        //    return email_exists;
        //}
        public async Task<bool> checkemailexists(string Email)
        {
            bool email_exists = true;
            if (Email == null) { email_exists = false; } else
            {
                User existingEmailUser = await UsrMgr.FindByEmailAsync(Email);
                if (existingEmailUser == null)
                {
                    email_exists = false;
                }
                else
                {
                    email_exists = true;
                }
            }
           
            return email_exists;
        }

        public async Task<bool> checkpasswordexists(string Password)
        {
            bool password_exists = true;
            if (Password == null) { password_exists = false; }
            else { password_exists=true; }
            return password_exists;

        }
            //public bool checkusernameexists(string Username)
            //{
            //    bool username_exists = false;
            //    User existingusernameUser = context.Users.Find(Username);
            //    if (existingusernameUser == null)
            //    {
            //        username_exists = false;

            //    }
            //    else
            //    {
            //        username_exists = true;
            //    }
            //    return username_exists;
            //}

            public async Task<bool> checkusernameexists(string UserName)
        {
            bool username_exists = true;
            //if (Username==null) { username_exists = false; } else
            //{
                User existingusernameUser = await UsrMgr.FindByNameAsync(UserName);
                if (existingusernameUser == null)
                {
                    username_exists = false;

                }
                else
                {
                    username_exists = true;
                }
            //}
           
            return username_exists;
        }

        public async Task<(IdentityResult,string)> SignUp(User user)
        {
            string user_Id=null;
            User appuser = new User()
            {
                Email = user.Email,
                UserName = user.UserName,
                Description = user.Description//new                
            };
            
            IdentityResult result=await UsrMgr.CreateAsync(appuser,user.Password);
            if(result.Succeeded)
            {
                user_Id=appuser.Id;
            }
            return (result, user_Id);
        }

        public async Task<(bool,string)> Login(string UserName, string Password)
        {            
            User user = await UsrMgr.FindByNameAsync(UserName);
            string user_Id=user.Id;
            bool found = false;
            if (user != null)
            {
                found= await UsrMgr.CheckPasswordAsync(user, Password);
                return (found,user_Id);
            }
            else { return (found,null); }
        }
        //public  void SignUp( User users )
        //{
        //    User newuser = new User()
        //    {
        //        User_Name = users.User_Name,
        //        Email=users.Email,
        //        Password=users.Password,

        //    };
        //    context.Users.Add(newuser);
        //    context.SaveChanges();
            
        //    //var user = new User();
        //    //if (!string.IsNullOrEmpty(users.Email)&& !string.IsNullOrEmpty(users.User_Name))
        //    //{


        //    //    user.Email = users.Email;
        //    //    user.User_Name = users.User_Name;
                
        //    //}
        //    //var result = await UsrMgr.CreateAsync(user, users.Password);

        //    //return result;

           
        //    //Dictionary<string, object> KeyValue = new Dictionary<string, object>();
        //    //User existingUsernameUser= await UsrMgr.FindByNameAsync(user.UserName);
        //    //User existingEmailUser= await UsrMgr.FindByEmailAsync(user.Email);
        //    //string confirm = "";
        //    //if (existingEmailUser != null)
        //    //{
        //    //   confirm="email exists";
        //    //}
        //    //else
        //    //{
        //    //    confirm = "email is new"; 
        //    //}
        //    //if (existingUsernameUser != null)
        //    //{
        //    //    confirm = "username exists";
        //    //}
        //    //else
        //    //{
        //    //    confirm = "username is new";
        //    //}
        //    //User newuser = new User();
        //    //newuser.Email = user.Email;
        //    //newuser.UserName = user.UserName;
        //    //IdentityResult result = await UsrMgr.CreateAsync(user, user.PasswordHash);
        //    //if (result.Succeeded)
        //    //{
        //    //    confirm = "user is added";
        //    //}
        //    //else
        //    //{
        //    //    confirm = "user couldnt be added";
        //    //}
        //    //return confirm;
        //}
         
            //Dictionary<string, object> KeyValue = new Dictionary<string, object>();
            //User existingEmailUser = null;
            //User existingUsernameUser = null;
            //IdentityResult result = null;


            //if (!string.IsNullOrEmpty(user.Email) )
            //{
            //     existingEmailUser = await UsrMgr.FindByEmailAsync(user.Email);
            //}
            //if (!string.IsNullOrEmpty(user.UserName))
            //{
            //     existingUsernameUser = await UsrMgr.FindByNameAsync(user.UserName);
            //}


            //if (existingEmailUser != null)
            //{
            //    KeyValue["EmailExists"] = "true";
            //}
            //else
            //{
            //    KeyValue["EmailExists"] = "false";
            //}

            //if (existingUsernameUser != null)
            //{
            //    KeyValue["UsernameExists"] = "true";
            //}
            //else
            //{
            //    KeyValue["UsernameExists"] = "false";
            //}

            ////if (existingEmailUser != null || existingUsernameUser != null)
            ////{
            ////    // Email or username already exists
            ////    return new JsonResult(KeyValue)
            ////    {
            ////        ContentType = "application/json",
            ////        StatusCode = 200
            ////    };
            ////}

            //// Both email and username are unique
            //User newUser = new User()
            //{

            //    UserName = user.UserName,
            //    Email = user.Email,

            //};
            //if (string.IsNullOrEmpty(user.PasswordHash))
            //{
            //    KeyValue["Error"] = "Password cannot be null or empty.";

            //}
            //result = await UsrMgr.CreateAsync(newUser,user.PasswordHash);

            //if (result != null && result.Succeeded)
            //{
            //    KeyValue["success"] = "true";
            //}
            //else
            //{
            //    KeyValue["success"] = "false";

            //}

            //return KeyValue;
        //}

        //public  string Update( User user)
        //{
        //    User userfound = context.Users.Find(user.User_Id);
        //    string confirm = "";      
        //        //if(!string.IsNullOrEmpty(userfound.Password))
        //        //{
        //        //    userfound.Password = passwordHasher.HashPassword(userfound, user.Password);
        //        //}
                
                   
                    
          
        //            //IdentityResult result = await UsrMgr.UpdateAsync(userfound);
        //            if (userfound!=null)
        //            {
        //                userfound.User_Name = user.User_Name;
        //                userfound.Password = user.Password;
        //                userfound.Email=user.Email;
        //                context.SaveChanges();
        //                confirm = "success";

        //            }
        //            else
        //            {
        //                 confirm = "fail"; 
        //            }
        

        //    return confirm;
        //}

        public async Task<string> Update(User user)
        {
            
            string confirm = "";
            if (user != null)
            {
                User appuser = await UsrMgr.FindByIdAsync(user.Id);
                if (appuser != null)
                {
                    if (!string.IsNullOrEmpty(user.Email))
                    {
                        appuser.Email = user.Email;

                    }
                    else confirm = "email cant be empty";
                    if (!string.IsNullOrEmpty(user.UserName))
                    {
                        appuser.UserName = user.UserName;

                    }
                    else confirm = "username cant be empty";
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        //string password= user.Password;
                        //appuser.PasswordHash = passwordHasher.HashPassword(appuser, user.Password);
                        appuser.PasswordHash = passwordHasher.HashPassword(user,user.Password);
                    }
                    else confirm = "password can not be empty";
                    if (!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
                    {
                        appuser.Description = user.Description;//new
                        IdentityResult result = await UsrMgr.UpdateAsync(appuser);
                        if (result.Succeeded)
                        {
                            confirm = "updated";
                        }
                        else { confirm = "couldn't update"; }
                    }
                }
                else { confirm = "no user found"; }
            }
            else confirm = "User Object is null";
            
            return confirm;
        }

        public async Task<string> Delete(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return "Id is null or empty";
            }

            User appuser = await UsrMgr.FindByIdAsync(Id);
            if (appuser == null)
            {
                return "no user found";
            }

            IdentityResult result = await UsrMgr.DeleteAsync(appuser);
            if (result.Succeeded)
            {
                return "deleted";
            }
            else
            {
                return "fail";
            }
            //string confirm;
            //if(!string.IsNullOrEmpty(Id))
            //{
            //    User appuser = await UsrMgr.FindByIdAsync(Id);
            //    if (appuser != null)
            //    {
            //        IdentityResult result = await UsrMgr.DeleteAsync(appuser);
            //        if (result.Succeeded)
            //        {
            //            confirm = "deleted";
            //        }
            //        else { confirm = "fail"; }

            //    }
            //    else
            //    { confirm = "no user found"; }
            //}else { confirm = "Id is null"; }

            //return confirm;
        }

        public async Task<User> GetUserInfo(string Id)
        {
            User user= await UsrMgr.FindByIdAsync(Id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        } 

        //public  string Delete(int Id)
        //{
        //    //int ID = int.Parse(Id);
        //    User userfound = context.Users.Find(Id);
        //    string confirm = "";
        //    if (userfound != null)
        //    {
        //        //IdentityResult result = await UsrMgr.DeleteAsync(userfound);
        //        context.Users.Remove(userfound);
        //        context.SaveChanges();
        //        confirm="success";

        //    }
        //    else { confirm = "fail"; }
        //    return confirm;
        //}


    }
}

