using Microsoft.EntityFrameworkCore;
using testEf.Models;

namespace testEf
{
    public class TasksContext : DbContext
    {
        public DbSet<Category> Categorias { get; set; } // Represents the relevant table/entity's dataset 
        public DbSet<Models.Task> Tareas { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
    }
}
