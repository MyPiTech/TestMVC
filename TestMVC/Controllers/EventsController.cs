using Microsoft.AspNetCore.Mvc;
using TestMVC.Dtos;
using TestMVC.Models;
using TestMVC.Services;

namespace TestMVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly ILogger<EventsController> _logger;
        private readonly ApiService<EventDto> _eventApiService;

        public EventsController(ILogger<EventsController> logger, ApiService<EventDto> eventApiService)
        {
            _logger = logger;
            _eventApiService = eventApiService;
        }
        public async Task<IActionResult> IndexAsync(int userId, CancellationToken token)
        {
            var events = await _eventApiService.GetAllAsync(()=> new EventDto { UserId = userId },token);
            return View(new DataModel<EventDto> { Data = events });
        }

    }
}
