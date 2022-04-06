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
    public class PreguntasController : ControllerBase
    {
        private readonly ApiSMRv4Context _context;

        public PreguntasController(ApiSMRv4Context context)
        {
            _context = context;
        }

        // GET: api/Preguntas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preguntas>>> GetPreguntas()
        {
            return await _context.Preguntas.ToListAsync();
        }

        // GET: api/Preguntas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Preguntas>> GetPreguntas(string id)
        {
            var preguntas = await _context.Preguntas.FindAsync(id);

            if (preguntas == null)
            {
                return NotFound();
            }

            return preguntas;
        }

        // PUT: api/Preguntas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreguntas(string id, Preguntas preguntas)
        {
            if (id != preguntas.PreguntaId)
            {
                return BadRequest();
            }

            _context.Entry(preguntas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntasExists(id))
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

        // POST: api/Preguntas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Preguntas>> PostPreguntas(Preguntas preguntas)
        {
            _context.Preguntas.Add(preguntas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PreguntasExists(preguntas.PreguntaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPreguntas", new { id = preguntas.PreguntaId }, preguntas);
        }

        // DELETE: api/Preguntas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreguntas(string id)
        {
            var preguntas = await _context.Preguntas.FindAsync(id);
            if (preguntas == null)
            {
                return NotFound();
            }

            _context.Preguntas.Remove(preguntas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreguntasExists(string id)
        {
            return _context.Preguntas.Any(e => e.PreguntaId == id);
        }
    }
}
