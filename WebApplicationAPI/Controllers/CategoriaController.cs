using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models;
using WebApplicationAPI.Services;

namespace WebApplicationAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        protected readonly ICategoriaServices Categoria;

        public CategoriaController(ICategoriaServices categorias)
        {
            this.Categoria = categorias;
        }

        [HttpGet]
        public IActionResult Get()
        {
           return Ok(Categoria.Mostrar());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            Categoria.Guardar(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            Categoria.Actualizar(id, categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Categoria.Eliminar(id);
            return Ok();
        }

    }
}
