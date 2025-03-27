using eBookShop.DTOs;
using eBookShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace eBookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _sigInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly GenerateToken _tokenGenerate;

        public UserController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, GenerateToken TokenGenerate)
        {
            _userManager = userManager;
            _sigInManager = signInManager;
            _roleManager = roleManager;
            _tokenGenerate = TokenGenerate;
        }
        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(data);
            }
            var user = new IdentityUser()
            {
                Email = data.Email,
                EmailConfirmed = true,
                UserName = data.Email
            };
            var RoleExist = await _roleManager.RoleExistsAsync(data.Role);
            if (!RoleExist)
            {
                return BadRequest(new { message = "Invalid Role." });
            }
            var result = await _userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, data.Role);
                if (!roleResult.Succeeded)
                {
                    return BadRequest(new { message = "Failed to assign role" });
                }
                return Ok(new { message = "User registered  successfully" });
            }
            return BadRequest();
        }
        [HttpPost("loginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(data);
            }

            var user = await _userManager.FindByEmailAsync(data.Email);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userRole = roles.FirstOrDefault(); 

            if (userRole == null || !roles.Contains(data.Role))
            {
                ModelState.AddModelError("Role", "Invalid Role. The role does not match the logged-in user.");
                return BadRequest(ModelState);
            }
            var result = await _sigInManager.PasswordSignInAsync(user.UserName, data.Password, false, false);
            if (result.Succeeded)
            {
                var token = _tokenGenerate.GenerateJSONWebToken(user.Id, user.Email, userRole);

                return Ok(new
                {
                    JwtToken = token,
                    UserDetails = new
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        Role = userRole
                    }
                });
            }

            return Unauthorized(new { message = "Invalid login attempt" });
        }


        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole([FromBody] RoleModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(data);
            }
            var roleList = new IdentityRole()
            {
                Name = data.RoleName,
            };
            var role = await _roleManager.CreateAsync(roleList);
            if (role.Succeeded)
            {
                return Ok(new { message = "Role created successfully." });
            }
            return BadRequest();
        }
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _sigInManager.SignOutAsync();
            return Ok(new { message = "Logged out successfully" });
        }

    }
}
