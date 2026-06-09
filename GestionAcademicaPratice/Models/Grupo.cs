namespace GestionAcademicaPratice.Models
{
    public class Grupo
    {
        public required string CodigoGrupo { get; set; }
        public List<Estudiante> Estudiantes { get; set; } = new();
    }
}
