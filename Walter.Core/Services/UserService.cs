using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.User;
using Walter.Core.Entities.User;

namespace Walter.Core.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
        }

        public async Task<ServiceResponse> LoginUserAsync(LoginUserDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "User or password incorrect."
                };
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure:true);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, model.RememberMe);
                return new ServiceResponse
                {
                    Success = true,
                    Message = "User signed in successfully."
                };
            }

            if (result.IsNotAllowed)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "Confirm your password please."
                };
            }

            if (result.IsLockedOut)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "User is locked out. Connect with site administrator."
                };
            }

            return new ServiceResponse
            {
                Success = false,
                Message = "User or password incorrect."
            };
        }
    }
}
