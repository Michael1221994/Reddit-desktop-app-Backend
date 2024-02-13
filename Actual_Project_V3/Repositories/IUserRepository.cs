using Actual_Project_V3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Actual_Project_V3.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityResult> SignUp(User user);
        Task<bool> checkusernameexists(string Username);

        Task<bool> checkemailexists(string Email);
        Task<string> Update(User user);
        Task<string> Delete(string Id);
        Task<bool> checkpasswordexists(string Password);
        //Task<User> FindByIdAsync(string userId);
        //Task<User> FindByEmailAsync(string email);
        //Task<User> FindByNameAsync(string userName);
        //Task<IdentityResult> CreateAsync(User user, string password);
        //Task<IdentityResult> UpdateAsync(User user);
        //Task<IdentityResult> DeleteAsync(User user);
    }
}
