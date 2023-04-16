using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models;
using WebApplicationAPI.Services;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
       protected readonly ITareasService Tareas;

        public TareaController(ITareasService tareas)
        {
            this.Tareas = tareas;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Tareas.Mostrar());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea) 
        {
            Tareas.Guardar(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tarea)
        {
            Tareas.Actualizar(id, tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Tareas.Eliminar(id);
            return Ok();
        }

    }
}
