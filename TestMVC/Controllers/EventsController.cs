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
            var events = await _eventApiService.GetAllAsync(() => new EventDto { UserId = userId },token);
            return View(new EventsModel { UserId = userId, Data = events });
        }

        [HttpGet]
        public async Task<IActionResult> EventAsync(int userId, int id, CancellationToken token)
        {

            if (id != 0) {
                var item = await _eventApiService.GetOneAsync(() => new EventDto { UserId = userId, Id = id }, token);
                return View(item?.ToModel() ?? default);
            }
            return View(new EventModel { UserId = userId, Start = default, Duration = default });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int userId, int id, CancellationToken token)
        {
            await _eventApiService.DeleteAsync(() => new EventDto { UserId = userId, Id = id }, token);
            return RedirectToAction("Index", new { userId });
        }

        [HttpPost]
        public async Task<IActionResult> EventAsync(EventModel model, CancellationToken token)
        {
            if (model.Id == 0)
            {
                await _eventApiService.AddAsync(model.ToDto(), token);
            }
            else
            {
                await _eventApiService.EditAsync(model.ToDto(), token);
            }
            return RedirectToAction("Index", new { userId = model.UserId });
        }

    }
}
