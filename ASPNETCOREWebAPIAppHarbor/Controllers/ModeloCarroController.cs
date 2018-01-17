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
    [Route("api/ModeloCarro")]
    public class ModeloCarroController : Controller
    {
        private readonly Context _context;

        public ModeloCarroController(Context context)
        {
            _context = context;
        }

        // GET: api/ModeloCarro
        [HttpGet]
        public IEnumerable<ModeloCarro> GetModeloCarro()
        {
            return _context.ModeloCarro;
        }

        // GET: api/ModeloCarro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModeloCarro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modeloCarro = await _context.ModeloCarro.SingleOrDefaultAsync(m => m.Codigo == id);

            if (modeloCarro == null)
            {
                return NotFound();
            }

            return Ok(modeloCarro);
        }

        // PUT: api/ModeloCarro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModeloCarro([FromRoute] int id, [FromBody] ModeloCarro modeloCarro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modeloCarro.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(modeloCarro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloCarroExists(id))
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

        // POST: api/ModeloCarro
        [HttpPost]
        public async Task<IActionResult> PostModeloCarro([FromBody] ModeloCarro modeloCarro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ModeloCarro.Add(modeloCarro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModeloCarro", new { id = modeloCarro.Codigo }, modeloCarro);
        }

        // DELETE: api/ModeloCarro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModeloCarro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modeloCarro = await _context.ModeloCarro.SingleOrDefaultAsync(m => m.Codigo == id);
            if (modeloCarro == null)
            {
                return NotFound();
            }

            _context.ModeloCarro.Remove(modeloCarro);
            await _context.SaveChangesAsync();

            return Ok(modeloCarro);
        }

        private bool ModeloCarroExists(int id)
        {
            return _context.ModeloCarro.Any(e => e.Codigo == id);
        }
    }
}