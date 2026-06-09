namespace GestionAcademicaPratice.Models
{
    public class EstudiantePresencial : Estudiante
    {
        public required string Salon { get; set; }

        public override void MostrarInfo()
        {
            Console.WriteLine($"[Presencial] Nombre: {Nombre} | Matrícula: {Matricula} | Salón: {Salon} | Promedio: {CalcularPromedio():F2}");
        }
    }
}
