using Microsoft.AspNetCore.Mvc;

namespace Missing_Middle_Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DevicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.Include(d => d.Staff).ToListAsync();
        }

        // GET: api/devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Devices.Include(d => d.Staff)
                                               .FirstOrDefaultAsync(d => d.DeviceId == id);

            if (device == null)
                return NotFound();

            return device;
        }

        // POST: api/devices
        [HttpPost]
        public async Task<ActionResult<Device>> CreateDevice(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDevice), new { id = device.DeviceId }, device);
        }

        // PUT: api/devices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, Device updatedDevice)
        {
            if (id != updatedDevice.DeviceId)
                return BadRequest();

            _context.Entry(updatedDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Devices.Any(d => d.DeviceId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
                return NotFound();

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
