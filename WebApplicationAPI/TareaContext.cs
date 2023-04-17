using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;
using WebApplicationAPI.Services;

namespace WebApplicationAPI
{
    public class TareaContext :DbContext
    {
        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public TareaContext(DbContextOptions<TareaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoria_inicio = new List<Categoria>();
            categoria_inicio.Add( new Categoria
            {
                CategoriaId = Guid.Parse("95568360-3582-47c7-998c-352edf956431"),
                Nombre = "Actividad Pendiente por Realizar",
                Peso = 10
            });
            categoria_inicio.Add(new Categoria
            { 
                CategoriaId = Guid.Parse("5d72a908-0b32-48d3-be69-6ce63484ea00"),
                Nombre = "Actividad Pendiente por Realizar",
                Peso = 50
            });   


            //MANEJO DE FLUENT API CREACION DE TABLA
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(cat => cat.CategoriaId);
                categoria.Property(cat => cat.Nombre).IsRequired().HasMaxLength(200);
                categoria.Property(cat => cat.Descripcion).IsRequired(false);
                categoria.Property(cat => cat.Peso);


                categoria.HasData(categoria_inicio);
            });
            
            List<Tarea> tareas_inicio = new List<Tarea>();
            tareas_inicio.Add(new Tarea
            {
                TareaId = Guid.Parse("c2d2ee03-abce-4fff-8462-7938d893cc23"),
                CategoriaId = Guid.Parse("95568360-3582-47c7-998c-352edf956431"),
                Prioridad = Prioridad.Media,
                Titulo = "Consulta Reporte",
                FechaCreacion = DateTime.Now

            });
            tareas_inicio.Add(new Tarea
            {
                TareaId = Guid.Parse("2d825c0f-ab98-4c69-950f-1d6ece42ece2"),
                CategoriaId = Guid.Parse("5d72a908-0b32-48d3-be69-6ce63484ea00"),
                Prioridad = Prioridad.Alta,
                Titulo = "Entregas",
                FechaCreacion = DateTime.Now

            });
            //MANEJO DE FLUENT API CREACION DE TABLA
            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(t => t.TareaId);
                tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);
                tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(t => t.Descripcion).IsRequired(false);
                tarea.Property(t => t.Prioridad);
                tarea.Property(t => t.FechaCreacion);
                tarea.Ignore(t => t.Resumen);

                tarea.HasData(tareas_inicio);
            });


        }

    }
}
