namespace GestionAcademicaPratice.Models
{
    public class Asignatura
    {
        public required string Nombre { get; set; }
        public required string Codigo { get; set; }
        public List<Grupo> Grupos { get; set; } = new();
    }
}
