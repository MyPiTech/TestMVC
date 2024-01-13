using Microsoft.AspNetCore.Mvc;
using TestMVC.Dtos;
using TestMVC.Models;
using TestMVC.Services;

namespace TestMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ApiService<UserDto> _userApiService;

        public UsersController(ILogger<UsersController> logger, ApiService<UserDto> userApiService)
        {
            _logger = logger;
            _userApiService = userApiService;
        }
        public async Task<IActionResult> IndexAsync(CancellationToken token)
        {
            var users = await _userApiService.GetAll(token);
            return View(new DataModel<UserDto> { Data = users });
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(UserModel user, CancellationToken token)
        {
            var users = await _userApiService.GetAll(token);
            return View(new DataModel<UserDto> { Data = users });
        }
    }
}
