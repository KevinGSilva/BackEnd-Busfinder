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
    public class ItinerariosController : ControllerBase
    {
        private readonly BusFinderContext _context;

        public ItinerariosController(BusFinderContext context)
        {
            _context = context;
        }

        // GET: api/Itinerarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itinerario>>> GetItinerarios()
        {
            return await _context.Itinerarios.ToListAsync();
        }

        // GET: api/Itinerarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itinerario>> GetItinerario(int id)
        {
            var itinerario = await _context.Itinerarios.FindAsync(id);

            if (itinerario == null)
            {
                return NotFound();
            }

            return itinerario;
        }

        // PUT: api/Itinerarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerario(int id, Itinerario itinerario)
        {
            if (id != itinerario.Id)
            {
                return BadRequest();
            }

            _context.Entry(itinerario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarioExists(id))
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

        // POST: api/Itinerarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itinerario>> PostItinerario(Itinerario itinerario)
        {
            _context.Itinerarios.Add(itinerario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItinerario", new { id = itinerario.Id }, itinerario);
        }

        // DELETE: api/Itinerarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItinerario(int id)
        {
            var itinerario = await _context.Itinerarios.FindAsync(id);
            if (itinerario == null)
            {
                return NotFound();
            }

            _context.Itinerarios.Remove(itinerario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItinerarioExists(int id)
        {
            return _context.Itinerarios.Any(e => e.Id == id);
        }
    }
}
