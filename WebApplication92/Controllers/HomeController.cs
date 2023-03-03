using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApplication92.Models;

namespace WebApplication92.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [Route("api/[controller]")]
        [ApiController]
        public class DeviceController : ControllerBase
        {
            private readonly DeviceContext _context;

            public DeviceController(DeviceContext context)
            {
                _context = context;
            }

            //GET: api/Events
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
            {
                return await _context.Events.ToListAsync();
            }


            // POST: api/AddDevice
            [HttpPost]
            public async Task<ActionResult<Device>> PostDevice(Device device)
            {
                _context.Devices.Add(device);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDevice", new { id = device.Id }, device);
            }


            // POST: api/AddEvent
            [HttpPost]
            public async Task<ActionResult<Event>> PostEvent(Event @event)
            {
                _context.Events.Add(@event);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAnimal", new { id = @event.Id }, @event);
            }

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}