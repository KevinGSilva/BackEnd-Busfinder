using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusFinder_2.Dados;
using BusFinder_2.Models;

namespace BusFinder_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArduinosController : ControllerBase
    {
        private readonly BusFinderContext _context;

        public ArduinosController(BusFinderContext context)
        {
            _context = context;
        }

        // GET: api/Arduinos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arduino>>> GetArduinos()
        {
            return await _context.Arduinos.ToListAsync();
        }

        // GET: api/Arduinos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arduino>> GetArduino(int id)
        {
            var arduino = await _context.Arduinos.FindAsync(id);

            if (arduino == null)
            {
                return NotFound();
            }

            return arduino;
        }

        // PUT: api/Arduinos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArduino(int id, Arduino arduino)
        {
            if (id != arduino.Id)
            {
                return BadRequest();
            }

            _context.Entry(arduino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArduinoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Arduinos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Arduino>> PostArduino(Arduino arduino)
        {
            _context.Arduinos.Add(arduino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArduino", new { id = arduino.Id }, arduino);
        }

        // DELETE: api/Arduinos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArduino(int id)
        {
            var arduino = await _context.Arduinos.FindAsync(id);
            if (arduino == null)
            {
                return NotFound();
            }

            _context.Arduinos.Remove(arduino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArduinoExists(int id)
        {
            return _context.Arduinos.Any(e => e.Id == id);
        }
    }
}
