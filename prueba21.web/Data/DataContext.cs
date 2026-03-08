using Microsoft.EntityFrameworkCore;
using prueba21.web.Models;

namespace prueba21.web.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<TareaEntity> Tareas { get; set; }
    
    }
}
