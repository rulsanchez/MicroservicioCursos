namespace MicroservicioCursos.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public int DuracionDias { get; set; }
        public int PlazasDisponibles { get; set; }
    }
}
