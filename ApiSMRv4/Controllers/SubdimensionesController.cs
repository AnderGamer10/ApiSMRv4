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
    public class SubdimensionesController : ControllerBase
    {
        private readonly ApiSMRv4Context _context;

        public SubdimensionesController(ApiSMRv4Context context)
        {
            _context = context;
        }

        // GET: api/Subdimensiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subdimensiones>>> GetSubdimensiones()
        {
            return await _context.Subdimensiones.ToListAsync();
        }

        // GET: api/Subdimensiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subdimensiones>> GetSubdimensiones(string id)
        {
            var subdimensiones = await _context.Subdimensiones.FindAsync(id);

            if (subdimensiones == null)
            {
                return NotFound();
            }

            return subdimensiones;
        }

        // PUT: api/Subdimensiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubdimensiones(string id, Subdimensiones subdimensiones)
        {
            if (id != subdimensiones.Subdimension)
            {
                return BadRequest();
            }

            _context.Entry(subdimensiones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubdimensionesExists(id))
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

        // POST: api/Subdimensiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subdimensiones>> PostSubdimensiones(Subdimensiones subdimensiones)
        {
            _context.Subdimensiones.Add(subdimensiones);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubdimensionesExists(subdimensiones.Subdimension))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubdimensiones", new { id = subdimensiones.Subdimension }, subdimensiones);
        }

        // DELETE: api/Subdimensiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubdimensiones(string id)
        {
            var subdimensiones = await _context.Subdimensiones.FindAsync(id);
            if (subdimensiones == null)
            {
                return NotFound();
            }

            _context.Subdimensiones.Remove(subdimensiones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubdimensionesExists(string id)
        {
            return _context.Subdimensiones.Any(e => e.Subdimension == id);
        }
    }
}
