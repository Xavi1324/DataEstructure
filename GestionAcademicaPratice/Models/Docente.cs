namespace GestionAcademicaPratice.Models
{
    public class Docente
    {
        public required string Nombre { get; set; }
        public List<Asignatura> Asignaturas { get; set; } = new();
    }
}
