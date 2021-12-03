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
    public class ItinerarioVeiculosController : ControllerBase
    {
        private readonly BusFinderContext _context;

        public ItinerarioVeiculosController(BusFinderContext context)
        {
            _context = context;
        }

        // GET: api/ItinerarioVeiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItinerarioVeiculo>>> GetItinerarioVeiculo()
        {
            return await _context.ItinerarioVeiculo.ToListAsync();
        }

        // GET: api/ItinerarioVeiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItinerarioVeiculo>> GetItinerarioVeiculo(int id)
        {
            var itinerarioVeiculo = await _context.ItinerarioVeiculo.FindAsync(id);

            if (itinerarioVeiculo == null)
            {
                return NotFound();
            }

            return itinerarioVeiculo;
        }

        // PUT: api/ItinerarioVeiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerarioVeiculo(int id, ItinerarioVeiculo itinerarioVeiculo)
        {
            if (id != itinerarioVeiculo.VeiculoId)
            {
                return BadRequest();
            }

            _context.Entry(itinerarioVeiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarioVeiculoExists(id))
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

        // POST: api/ItinerarioVeiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItinerarioVeiculo>> PostItinerarioVeiculo(ItinerarioVeiculo itinerarioVeiculo)
        {
            _context.ItinerarioVeiculo.Add(itinerarioVeiculo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItinerarioVeiculoExists(itinerarioVeiculo.VeiculoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItinerarioVeiculo", new { id = itinerarioVeiculo.VeiculoId }, itinerarioVeiculo);
        }

        // DELETE: api/ItinerarioVeiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItinerarioVeiculo(int id)
        {
            var itinerarioVeiculo = await _context.ItinerarioVeiculo.FindAsync(id);
            if (itinerarioVeiculo == null)
            {
                return NotFound();
            }

            _context.ItinerarioVeiculo.Remove(itinerarioVeiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItinerarioVeiculoExists(int id)
        {
            return _context.ItinerarioVeiculo.Any(e => e.VeiculoId == id);
        }
    }
}
