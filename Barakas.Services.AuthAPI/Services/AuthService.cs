using Barakas.Services.AuthAPI.Data;
using Barakas.Services.AuthAPI.Models;
using Barakas.Services.AuthAPI.Models.DTO;
using Barakas.Services.AuthAPI.Services.IService;
using Microsoft.AspNetCore.Identity;

namespace Barakas.Services.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AddDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AddDbContext db,UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u=>u.Email.ToLower() == email.ToLower());
            if(user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user,roleName);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u=>u.UserName.ToLower() == loginRequest.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDTO() { User = null, Token = "" };
            }

            var roles = await _userManager.GetRolesAsync(user);
         
            var token = _jwtTokenGenerator.GenerateToken(user,roles);


            UserDTO userDTO = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                User=userDTO,
                Token=token
            };
            return loginResponseDTO; 
        }

        public async Task<string> Register(RegistrationRequestDTO registration)
        {
            ApplicationUser user = new()
            {
                UserName = registration.Email,
                Email = registration.Email,
                NormalizedEmail = registration.Email.ToUpper(),
                Name = registration.Name,
                PhoneNumber = registration.PhoneNumber
            };
            try
            {
                var result = await _userManager.CreateAsync(user, registration.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registration.Email);

                    UserDTO userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };
                    return "";
                }
                else {
                    return result.Errors.FirstOrDefault().Description;
                }   
            }
            catch (Exception)
            {

                
            }
            return "Error Encountered";
        }
    }
}
