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
    public class ElementosController : ControllerBase
    {
        private readonly ApiSMRv4Context _context;

        public ElementosController(ApiSMRv4Context context)
        {
            _context = context;
        }

        // GET: api/Elementos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elementos>>> GetElementos()
        {
            return await _context.Elementos.ToListAsync();
        }

        // GET: api/Elementos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elementos>> GetElementos(string id)
        {
            var elementos = await _context.Elementos.FindAsync(id);

            if (elementos == null)
            {
                return NotFound();
            }

            return elementos;
        }

        // PUT: api/Elementos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElementos(string id, Elementos elementos)
        {
            if (id != elementos.Elemento)
            {
                return BadRequest();
            }

            _context.Entry(elementos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementosExists(id))
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

        // POST: api/Elementos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Elementos>> PostElementos(Elementos elementos)
        {
            _context.Elementos.Add(elementos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ElementosExists(elementos.Elemento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetElementos", new { id = elementos.Elemento }, elementos);
        }

        // DELETE: api/Elementos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementos(string id)
        {
            var elementos = await _context.Elementos.FindAsync(id);
            if (elementos == null)
            {
                return NotFound();
            }

            _context.Elementos.Remove(elementos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElementosExists(string id)
        {
            return _context.Elementos.Any(e => e.Elemento == id);
        }
    }
}
