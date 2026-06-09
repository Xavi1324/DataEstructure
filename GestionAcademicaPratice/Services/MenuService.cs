using GestionAcademicaPratice.Models;

namespace GestionAcademicaPratice.Services
{
    public class MenuService
    {
        private readonly DocenteService _docenteService;

        public MenuService()
        {
            Console.Write("Ingrese el nombre del docente: ");
            string nombre = Console.ReadLine() ?? "Docente";

            Docente docente = new Docente { Nombre = nombre };
            _docenteService = new DocenteService(docente);
        }

        public void Iniciar()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n========== MENÚ PRINCIPAL ==========");
                Console.WriteLine("1. Agregar asignatura");
                Console.WriteLine("2. Agregar grupo a asignatura");
                Console.WriteLine("3. Agregar estudiante a grupo");
                Console.WriteLine("4. Registrar calificación");
                Console.WriteLine("5. Ver calificaciones de un grupo");
                Console.WriteLine("6. Ver porcentaje de aprobados");
                Console.WriteLine("7. Salir");
                Console.Write("Opción: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1": AgregarAsignatura(); break;
                    case "2": AgregarGrupo(); break;
                    case "3": AgregarEstudiante(); break;
                    case "4": RegistrarCalificacion(); break;
                    case "5": MostrarCalificaciones(); break;
                    case "6": VerPorcentajeAprobados(); break;
                    case "7": salir = true; break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            }
        }

        private void AgregarAsignatura()
        {
            Console.Write("Nombre de la asignatura: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Código de la asignatura: ");
            string codigo = Console.ReadLine() ?? "";

            OperationResult result = _docenteService.AgregarAsignatura(nombre, codigo);
            Console.WriteLine(result.Message);
        }

        private void AgregarGrupo()
        {
            Console.Write("Código de la asignatura: ");
            string codigoAsignatura = Console.ReadLine() ?? "";

            Console.Write("Código del grupo: ");
            string codigoGrupo = Console.ReadLine() ?? "";

            OperationResult result = _docenteService.AgregarGrupo(codigoAsignatura, codigoGrupo);
            Console.WriteLine(result.Message);
        }

        private void AgregarEstudiante()
        {
            Console.Write("Código de la asignatura: ");
            string codigoAsignatura = Console.ReadLine() ?? "";

            Console.Write("Código del grupo: ");
            string codigoGrupo = Console.ReadLine() ?? "";

            Console.Write("Tipo de estudiante (1. Presencial / 2. Distancia): ");
            string tipo = Console.ReadLine() ?? "";

            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine() ?? "";

            Estudiante estudiante;

            if (tipo == "1")
            {
                Console.Write("Salón: ");
                string salon = Console.ReadLine() ?? "";
                estudiante = new EstudiantePresencial { Nombre = nombre, Matricula = matricula, Salon = salon };
            }
            else
            {
                Console.Write("Plataforma virtual: ");
                string plataforma = Console.ReadLine() ?? "";
                estudiante = new EstudianteADistancia { Nombre = nombre, Matricula = matricula, PlataformaVirtual = plataforma };
            }

            OperationResult result = _docenteService.AgregarEstudiante(codigoAsignatura, codigoGrupo, estudiante);
            Console.WriteLine(result.Message);
        }

        private void RegistrarCalificacion()
        {
            Console.Write("Código de la asignatura: ");
            string codigoAsignatura = Console.ReadLine() ?? "";

            Console.Write("Código del grupo: ");
            string codigoGrupo = Console.ReadLine() ?? "";

            Console.Write("Matrícula del estudiante: ");
            string matricula = Console.ReadLine() ?? "";

            Console.Write("Nota (0-100): ");
            bool esValida = double.TryParse(Console.ReadLine(), out double nota);

            if (!esValida)
            {
                Console.WriteLine("Nota inválida.");
                return;
            }

            OperationResult result = _docenteService.RegistrarCalificacion(codigoAsignatura, codigoGrupo, matricula, nota);
            Console.WriteLine(result.Message);
        }

        private void MostrarCalificaciones()
        {
            Console.Write("Código de la asignatura: ");
            string codigoAsignatura = Console.ReadLine() ?? "";

            Console.Write("Código del grupo: ");
            string codigoGrupo = Console.ReadLine() ?? "";

            OperationResult result = _docenteService.MostrarCalificaciones(codigoAsignatura, codigoGrupo);
            Console.WriteLine(result.Message);
        }

        private void VerPorcentajeAprobados()
        {
            Console.Write("Código de la asignatura: ");
            string codigoAsignatura = Console.ReadLine() ?? "";

            Console.Write("Código del grupo: ");
            string codigoGrupo = Console.ReadLine() ?? "";

            OperationResult result = _docenteService.PorcentajeAprobados(codigoAsignatura, codigoGrupo);
            Console.WriteLine(result.Message);
        }
    }
}
