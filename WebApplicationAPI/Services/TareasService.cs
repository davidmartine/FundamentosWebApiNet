using WebApplicationAPI.Models;

namespace WebApplicationAPI.Services
{
    public interface ITareasService
    {
        IEnumerable<Tarea> Mostrar();
        Task Guardar(Tarea tarea);

        Task Actualizar(Guid id, Tarea tarea);

        Task Eliminar(Guid id);

    }
    public class TareasService : ITareasService
    {
        TareaContext tareaContext;

        public TareasService(TareaContext tareaContext)
        {
            this.tareaContext = tareaContext;
        }

        public IEnumerable<Tarea> Mostrar()
        {
            return tareaContext.Tareas;
        }

        public async Task Guardar(Tarea tarea)
        {
            tareaContext.Tareas.Add(tarea);
            await tareaContext.SaveChangesAsync();
        }

        public async Task Actualizar(Guid id,Tarea tarea)
        {
            var TareaActual = tareaContext.Tareas.Find(id);
            if (TareaActual != null)
            {
                TareaActual.Titulo = tarea.Titulo;
                TareaActual.Descripcion= tarea.Descripcion;
                TareaActual.Prioridad= tarea.Prioridad;
                TareaActual.FechaCreacion = tarea.FechaCreacion;
                TareaActual.Resumen = tarea.Resumen;

                await tareaContext.SaveChangesAsync();
            }
        }

        public async Task Eliminar(Guid id)
        {
            var TareaActual = tareaContext.Tareas.Find(id);
            if (TareaActual != null)
            {
                tareaContext.Remove(TareaActual);
                await tareaContext.SaveChangesAsync();
            }
        }
    }
}
