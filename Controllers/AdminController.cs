using eBookShop.DTOs;
using eBookShop.Model;
using eBookShop.Repositories.BALRepository;
using eBookShop.Services.BALServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookShop.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
    }
}
