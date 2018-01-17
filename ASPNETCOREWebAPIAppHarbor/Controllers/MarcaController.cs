using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNETCOREWebAPIAppHarbor.Models;

namespace ASPNETCOREWebAPIAppHarbor.Controllers
{
    [Produces("application/json")]
    [Route("api/Marca")]
    public class MarcaController : Controller
    {
        private readonly Context _context;

        public MarcaController(Context context)
        {
            _context = context;
        }

        // GET: api/Marca
        [HttpGet]
        public IEnumerable<Marca> GetMarca()
        {
            return _context.Marca;
        }

        // GET: api/Marca/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarca([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marca = await _context.Marca.SingleOrDefaultAsync(m => m.Codigo == id);

            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        // PUT: api/Marca/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca([FromRoute] int id, [FromBody] Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marca.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marca
        [HttpPost]
        public async Task<IActionResult> PostMarca([FromBody] Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Marca.Add(marca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarca", new { id = marca.Codigo }, marca);
        }

        // DELETE: api/Marca/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marca = await _context.Marca.SingleOrDefaultAsync(m => m.Codigo == id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marca.Remove(marca);
            await _context.SaveChangesAsync();

            return Ok(marca);
        }

        private bool MarcaExists(int id)
        {
            return _context.Marca.Any(e => e.Codigo == id);
        }
    }
}