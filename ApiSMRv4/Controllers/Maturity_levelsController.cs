using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiSMRv4.Data;
using ApiSMRv4.Models;

namespace ApiSMRv4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Maturity_levelsController : ControllerBase
    {
        private readonly ApiSMRv4Context _context;

        public Maturity_levelsController(ApiSMRv4Context context)
        {
            _context = context;
        }

        // GET: api/Maturity_levels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maturity_levels>>> GetMaturity_levels()
        {
            return await _context.Maturity_levels.ToListAsync();
        }

        // GET: api/Maturity_levels/L1

        [HttpGet("{subdimension}/{ciudad}")]
        public ActionResult<List<Maturity_levels>> GetMaturity_levels(string subdimension, string ciudad)
        {
            var sub = _context.Maturity_levels.Where(u => u.Subdimension.Equals(subdimension) && u.ciudad.Equals(ciudad)).ToList();

            if (sub == null)
            {
                return NotFound();
            }
            return sub;
        }

        // PUT: api/Maturity_levels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaturity_levels(string id, Maturity_levels maturity_levels)
        {
            if (id != maturity_levels.NombreLevel)
            {
                return BadRequest();
            }

            _context.Entry(maturity_levels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Maturity_levelsExists(id))
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

        // POST: api/Maturity_levels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maturity_levels>> PostMaturity_levels(Maturity_levels maturity_levels)
        {
            _context.Maturity_levels.Add(maturity_levels);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Maturity_levelsExists(maturity_levels.NombreLevel))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaturity_levels", new { id = maturity_levels.NombreLevel }, maturity_levels);
        }

        // DELETE: api/Maturity_levels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaturity_levels(string id)
        {
            var maturity_levels = await _context.Maturity_levels.FindAsync(id);
            if (maturity_levels == null)
            {
                return NotFound();
            }

            _context.Maturity_levels.Remove(maturity_levels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Maturity_levelsExists(string id)
        {
            return _context.Maturity_levels.Any(e => e.NombreLevel == id);
        }
    }
}
