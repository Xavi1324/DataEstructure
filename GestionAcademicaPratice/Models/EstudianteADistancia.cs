using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionAcademicaPratice.Models
{
    public class EstudianteADistancia : Estudiante
    {
        public required string PlataformaVirtual { get; set; }

        public override void MostrarInfo()
        {
            Console.WriteLine($"[Distancia] Nombre: {Nombre} | Matrícula: {Matricula} | Plataforma: {PlataformaVirtual} | Promedio: {CalcularPromedio():F2}");
        }
    }
}
