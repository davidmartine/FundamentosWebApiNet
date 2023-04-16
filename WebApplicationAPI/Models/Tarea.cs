namespace WebApplicationAPI.Models
{
    public class Tarea
    {
        public Guid TareaId { get; set; }

        public Guid CategoriaId { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        public Prioridad Prioridad { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string? Resumen { get; set; }


        public virtual Categoria Categoria { get; set; }

    }
}
