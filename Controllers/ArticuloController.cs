using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ARTICULOS_API.DBContext;
using ARTICULOS_API.Entities;

namespace ARTICULOS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        public readonly ArticulosDBContext Contexto;

        public ArticuloController(ArticulosDBContext _dbContext) { Contexto = _dbContext; }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            List<Articulo> lista = new List<Articulo>();

            try
            {
                lista = Contexto.Articulos.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = lista });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("Find/{ArticuloId:int}")]
        public IActionResult Buscar(int ArticuloId)
        {
            if (Contexto.Articulos.Find(ArticuloId) == null)
            {
                return BadRequest("Articulo no encontrado");
            }
            Articulo? articulo = new Articulo();
            try
            {
                articulo = Contexto.Articulos.FirstOrDefault(A => A.ArticuloId == ArticuloId);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = articulo });
            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message, response = articulo });
            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody] Articulo articulo)
        {
            try
            {
                Contexto.Add(articulo);
                Contexto.SaveChanges();
                Contexto.Entry(articulo).State = EntityState.Detached;
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message});
            }
        }

        [HttpPut]
        [Route("Modify")]
        public IActionResult Modify([FromBody] Articulo articulo)
        {
            if (Contexto.Articulos.Find(articulo.ArticuloId) == null)
            {
                return BadRequest("Articulo no encontrado");
            }
            
            try
            {
                Contexto.Entry(articulo).State = EntityState.Modified;
                Contexto.SaveChanges();
                Contexto.Entry(articulo).State = EntityState.Detached;
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message});
            }
        }

        [HttpDelete]
        [Route("Delete/{ArticuloId:int}")]
        public IActionResult Delete(int ArticuloId)
        {
            if (Contexto.Articulos.Find(ArticuloId) == null)
            {
                return BadRequest("Articulo no encontrado");
            }

            try
            {
                var articulo = Contexto.Articulos.Find(ArticuloId);
                Contexto.Articulos.Remove(articulo) ;
                Contexto.SaveChanges();
                Contexto.Entry(articulo).State = EntityState.Detached;
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "El producto ha sido eliminado" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message });
            }
        }
    }
}
