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
    public class PreguntasTablasController : ControllerBase
    {
        private readonly ApiSMRv4Context _context;

        public PreguntasTablasController(ApiSMRv4Context context)
        {
            _context = context;
        }

        // GET: api/PreguntasTablas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreguntasTabla>>> GetPreguntasTabla()
        {
            return await _context.PreguntasTabla.ToListAsync();
        }

        // GET: api/PreguntasTablas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreguntasTabla>> GetPreguntasTabla(string id)
        {
            var preguntasTabla = await _context.PreguntasTabla.FindAsync(id);

            if (preguntasTabla == null)
            {
                return NotFound();
            }

            return preguntasTabla;
        }

        // PUT: api/PreguntasTablas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreguntasTabla(string id, PreguntasTabla preguntasTabla)
        {
            if (id != preguntasTabla.ElementoPregunta)
            {
                return BadRequest();
            }

            _context.Entry(preguntasTabla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntasTablaExists(id))
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

        // POST: api/PreguntasTablas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PreguntasTabla>> PostPreguntasTabla(PreguntasTabla preguntasTabla)
        {
            _context.PreguntasTabla.Add(preguntasTabla);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PreguntasTablaExists(preguntasTabla.ElementoPregunta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPreguntasTabla", new { id = preguntasTabla.ElementoPregunta }, preguntasTabla);
        }

        // DELETE: api/PreguntasTablas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreguntasTabla(string id)
        {
            var preguntasTabla = await _context.PreguntasTabla.FindAsync(id);
            if (preguntasTabla == null)
            {
                return NotFound();
            }

            _context.PreguntasTabla.Remove(preguntasTabla);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreguntasTablaExists(string id)
        {
            return _context.PreguntasTabla.Any(e => e.ElementoPregunta == id);
        }
    }
}
