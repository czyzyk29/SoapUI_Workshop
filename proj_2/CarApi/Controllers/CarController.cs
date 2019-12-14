using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarApi.Models;

namespace CarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly CarContext _context;

        public CarController(CarContext context)
        {
            _context = context;

            if (_context.CarItems.Count() == 0)
            {
                _context.CarItems.Add(new CarItem { Name = "Porsche" });
                _context.SaveChanges();
            }
        }

        //GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarItem>>> GetCarItems()
        {
            return await _context.CarItems.ToListAsync();
        }

        //GET: api/Car/3
        [HttpGet("{id}")]
        public async Task<ActionResult<CarItem>> GetCarItem(long id)
        {
            var carItem = await _context.CarItems.FindAsync(id);
            if (carItem== null)
            {
                return NotFound();
            }

            return carItem;
        }

        //POST: api/Car
        [HttpPost]
        public async Task<ActionResult<CarItem>> PostCarItem(CarItem item)
        {
            _context.CarItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarItem), new { id = item.Id }, item);
        }

        //PUT: api/Car/3
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarItem(long id, CarItem item)
        {
            if (id!=item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/Car/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarItem(long id)
        {
            var carItem = await _context.CarItems.FindAsync(id);
            if (carItem == null)
            {
                return NotFound();
            }

            _context.CarItems.Remove(carItem);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
