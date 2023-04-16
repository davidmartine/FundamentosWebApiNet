using WebApplicationAPI.Models;

namespace WebApplicationAPI.Services
{
    public interface ICategoriaServices
    {
        IEnumerable<Categoria> Mostrar();
        Task Guardar(Categoria categoria);
        Task Actualizar(Guid id, Categoria categoria);

        Task Eliminar(Guid id);
    }
    public class CategoriaService : ICategoriaServices
    {
        TareaContext tareaContext;

        public CategoriaService(TareaContext tareaContext)
        {
            this.tareaContext = tareaContext;
        }

        public IEnumerable<Categoria> Mostrar()
        {
            return (IEnumerable<Categoria>)tareaContext.Categorias;
        }

        public async Task Guardar(Categoria categoria)
        {
            tareaContext.Add(categoria);
            await tareaContext.SaveChangesAsync();
        }

        public async Task Actualizar(Guid id,Categoria categoria)
        {
            var categoriaActual = tareaContext.Categorias.Find(id);
            if(categoriaActual != null) 
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Peso = categoria.Peso;

                await tareaContext.SaveChangesAsync();
            }
        }

        public async Task Eliminar(Guid id)
        {
            var categoriaActual = tareaContext.Categorias.Find(id);

            if(categoriaActual != null )
            {
                tareaContext.Remove(categoriaActual);
                await tareaContext.SaveChangesAsync();
            }
        }
    }
}
