using GestionAcademicaPratice.Models;

namespace GestionAcademicaPratice.Services
{
    public class DocenteService
    {
        private readonly Docente _docente;

        public DocenteService(Docente docente)
        {
            _docente = docente;
        }

        public OperationResult AgregarAsignatura(string nombre, string codigo)
        {
            bool existe = _docente.Asignaturas.Any(a => a.Codigo == codigo);
            if (existe)
                return new OperationResult { Success = false, Message = $"Ya existe una asignatura con el código {codigo}." };

            _docente.Asignaturas.Add(new Asignatura { Nombre = nombre, Codigo = codigo });
            return new OperationResult { Success = true, Message = "Asignatura agregada correctamente." };
        }

        public OperationResult AgregarGrupo(string codigoAsignatura, string codigoGrupo)
        {
            Asignatura? asignatura = _docente.Asignaturas.FirstOrDefault(a => a.Codigo == codigoAsignatura);
            if (asignatura == null)
                return new OperationResult { Success = false, Message = "Asignatura no encontrada." };

            bool existe = asignatura.Grupos.Any(g => g.CodigoGrupo == codigoGrupo);
            if (existe)
                return new OperationResult { Success = false, Message = $"Ya existe un grupo con el código {codigoGrupo}." };

            asignatura.Grupos.Add(new Grupo { CodigoGrupo = codigoGrupo });
            return new OperationResult { Success = true, Message = "Grupo agregado correctamente." };
        }

        public OperationResult AgregarEstudiante(string codigoAsignatura, string codigoGrupo, Estudiante estudiante)
        {
            Asignatura? asignatura = _docente.Asignaturas.FirstOrDefault(a => a.Codigo == codigoAsignatura);
            if (asignatura == null)
                return new OperationResult { Success = false, Message = "Asignatura no encontrada." };

            Grupo? grupo = asignatura.Grupos.FirstOrDefault(g => g.CodigoGrupo == codigoGrupo);
            if (grupo == null)
                return new OperationResult { Success = false, Message = "Grupo no encontrado." };

            bool existe = grupo.Estudiantes.Any(e => e.Matricula == estudiante.Matricula);
            if (existe)
                return new OperationResult { Success = false, Message = $"Ya existe un estudiante con la matrícula {estudiante.Matricula}." };

            grupo.Estudiantes.Add(estudiante);
            return new OperationResult { Success = true, Message = "Estudiante agregado correctamente." };
        }

        public OperationResult RegistrarCalificacion(string codigoAsignatura, string codigoGrupo, string matricula, double nota)
        {
            Asignatura? asignatura = _docente.Asignaturas.FirstOrDefault(a => a.Codigo == codigoAsignatura);
            if (asignatura == null)
                return new OperationResult { Success = false, Message = "Asignatura no encontrada." };

            Grupo? grupo = asignatura.Grupos.FirstOrDefault(g => g.CodigoGrupo == codigoGrupo);
            if (grupo == null)
                return new OperationResult { Success = false, Message = "Grupo no encontrado." };

            Estudiante? estudiante = grupo.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
                return new OperationResult { Success = false, Message = "Estudiante no encontrado." };

            if (nota < 0 || nota > 100)
                return new OperationResult { Success = false, Message = "La nota debe estar entre 0 y 100." };

            estudiante.Calificaciones.Add(nota);
            return new OperationResult { Success = true, Message = "Calificación registrada correctamente." };
        }

        public OperationResult MostrarCalificaciones(string codigoAsignatura, string codigoGrupo)
        {
            Asignatura? asignatura = _docente.Asignaturas.FirstOrDefault(a => a.Codigo == codigoAsignatura);
            if (asignatura == null)
                return new OperationResult { Success = false, Message = "Asignatura no encontrada." };

            Grupo? grupo = asignatura.Grupos.FirstOrDefault(g => g.CodigoGrupo == codigoGrupo);
            if (grupo == null)
                return new OperationResult { Success = false, Message = "Grupo no encontrado." };

            if (grupo.Estudiantes.Count == 0)
                return new OperationResult { Success = false, Message = "El grupo no tiene estudiantes." };

            Console.WriteLine($"\n--- Calificaciones del grupo {codigoGrupo} ---");
            foreach (Estudiante e in grupo.Estudiantes)
                e.MostrarInfo();

            return new OperationResult { Success = true, Message = "Listado generado." };
        }

        public OperationResult PorcentajeAprobados(string codigoAsignatura, string codigoGrupo)
        {
            Asignatura? asignatura = _docente.Asignaturas.FirstOrDefault(a => a.Codigo == codigoAsignatura);
            if (asignatura == null)
                return new OperationResult { Success = false, Message = "Asignatura no encontrada." };

            Grupo? grupo = asignatura.Grupos.FirstOrDefault(g => g.CodigoGrupo == codigoGrupo);
            if (grupo == null)
                return new OperationResult { Success = false, Message = "Grupo no encontrado." };

            if (grupo.Estudiantes.Count == 0)
                return new OperationResult { Success = false, Message = "El grupo no tiene estudiantes." };

            int aprobados = grupo.Estudiantes.Count(e => e.CalcularPromedio() >= 70);
            double porcentaje = (double)aprobados / grupo.Estudiantes.Count * 100;

            return new OperationResult
            {
                Success = true,
                Message = $"Aprobados: {aprobados}/{grupo.Estudiantes.Count} ({porcentaje:F1}%)",
                Data = porcentaje
            };
        }
    }
}
