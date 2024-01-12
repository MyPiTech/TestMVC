using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestMVC.Dtos;
using TestMVC.Models;
using TestMVC.Services;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService<UserDto> _userApiService;
        private readonly ApiService<EventDto> _eventApiService;

        public HomeController(ILogger<HomeController> logger, ApiService<UserDto> userApiService, ApiService<EventDto> eventApiService)
        {
            _logger = logger;
            _userApiService = userApiService;
            _eventApiService = eventApiService;
        }

        public async Task<IActionResult> Index(CancellationToken token)
        {
            var test = await _eventApiService.GetAll(() => new EventDto {UserId = 1}, token);
            var user = await _userApiService.GetOne(() => new UserDto {Id = 1}, token);
            var users = await _userApiService.GetAll(token);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}