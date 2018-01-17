using ASPNETCOREWebAPIAppHarbor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREWebAPIAppHarbor.Controllers
{
    [Produces("application/json")]
    [Route("api/Modelo")]
    public class ModeloController : Controller
    {
        private readonly Context _context;

        public ModeloController(Context context)
        {
            _context = context;
        }

        // GET: api/Modelo
        [HttpGet]
        public IEnumerable<Modelo> GetModelo()
        {
            return _context.Modelo;
        }

        // GET: api/Modelo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modelo = await _context.Modelo.SingleOrDefaultAsync(m => m.Codigo == id);

            if (modelo == null)
            {
                return NotFound();
            }

            return Ok(modelo);
        }

        // PUT: api/Modelo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelo([FromRoute] int id, [FromBody] Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelo.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(modelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modelo
        [HttpPost]
        public async Task<IActionResult> PostModelo([FromBody] Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Modelo.Add(modelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelo", new { id = modelo.Codigo }, modelo);
        }

        // DELETE: api/Modelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modelo = await _context.Modelo.SingleOrDefaultAsync(m => m.Codigo == id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelo.Remove(modelo);
            await _context.SaveChangesAsync();

            return Ok(modelo);
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelo.Any(e => e.Codigo == id);
        }
    }
}