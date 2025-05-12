using Microsoft.EntityFrameworkCore;

namespace MicroservicioCursos.Data
{
    public class CursosDBContext: DbContext
    {
        public CursosDBContext(DbContextOptions<CursosDBContext> options) : base(options)
        {
        }
        public DbSet<Models.Curso> Cursos { get; set; }
        
    
    }
}
