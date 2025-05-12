using MicroservicioCursos.Data;
using MicroservicioCursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroservicioCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController:ControllerBase
    {

        private readonly CursosDBContext _dbContext;


        public CursoController(CursosDBContext context)
        {
                _dbContext= context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _dbContext.Cursos.ToListAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCursoById(int id)

        {
            var curso = await _dbContext.Cursos.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(curso);

        }
    }
}
