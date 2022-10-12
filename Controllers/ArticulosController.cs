using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARTICULOS_API.DBContext;
using ARTICULOS_API.Entities;

namespace ARTICULOS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticulosDBContext contexto;

        public ArticulosController(ArticulosDBContext context)
        {
            contexto = context;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulos>>> GetArticulos()
        {
            return await contexto.Articulos.ToListAsync();
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulos>> GetArticulos(int id)
        {
            var articulo = await contexto.Articulos.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulos(int id, Articulos articulos)
        {
            if (id != articulos.ArticuloId)
            {
                return BadRequest();
            }

            contexto.Entry(articulos).State = EntityState.Modified;

            try
            {
                await contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticulosExists(id))
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

        // POST: api/Articulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articulos>> PostArticulos(Articulos articulos)
        {
            contexto.Articulos.Add(articulos);
            await contexto.SaveChangesAsync();

            return CreatedAtAction("GetArticulos", new { id = articulos.ArticuloId }, articulos);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulos(int id)
        {
            var articulos = await contexto.Articulos.FindAsync(id);
            if (articulos == null)
            {
                return NotFound();
            }

            contexto.Articulos.Remove(articulos);
            await contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticulosExists(int id)
        {
            return contexto.Articulos.Any(e => e.ArticuloId == id);
        }
    }
}
