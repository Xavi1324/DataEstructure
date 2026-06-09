namespace GestionAcademicaPratice.Models
{
    public class Estudiante
    {
        public required string Nombre { get; set; }
        public required string Matricula { get; set; }
        public List<double> Calificaciones { get; set; } = new();

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Nombre: {Nombre} | Matrícula: {Matricula} | Promedio: {CalcularPromedio():F2}");
        }
        public double CalcularPromedio()
        {
            if (Calificaciones.Count == 0) return 0;
            return Calificaciones.Average();
        }
    }
}
