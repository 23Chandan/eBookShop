using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eBookShop.DTOs
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [Compare("Password",ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }
    }
    public class UserDetails
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
    public class RoleModel
    {
        public string RoleName { get; set; }
    }
}

