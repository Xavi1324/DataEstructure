using OrdernamientoAlgo.Models;

namespace OrdernamientoAlgo.Services
{
    public class BubbleSortService
    {
        public ResultadoOrdenamiento<Libro> OrdenarPorTitulo(List<Libro> librosOriginal)
        {
            var libros = new List<Libro>(librosOriginal);

            var resultado = new ResultadoOrdenamiento<Libro>
            {
                EtiquetaMovimiento = "Intercambios"
            };

            int n = libros.Count;

            for (int pasada = 0; pasada < n - 1; pasada++)
            {
                bool huboIntercambio = false;

                for (int j = 0; j < n - pasada - 1; j++)
                {
                    resultado.Comparaciones++;

                    int cmp = string.Compare(libros[j].Titulo, libros[j + 1].Titulo, StringComparison.OrdinalIgnoreCase);
                    if (cmp > 0)
                    {
                        (libros[j], libros[j + 1]) = (libros[j + 1], libros[j]);
                        resultado.Movimientos++;
                        huboIntercambio = true;
                    }
                }

                resultado.Pasos.Add(new PasoOrdenamiento
                {
                    Numero = pasada + 1,
                    Descripcion = $"Pasada {pasada + 1}",
                    EstadoArreglo = string.Join(" | ", libros.Select(l => l.Titulo))
                });

                if (!huboIntercambio)
                {
                    break;
                }
            }

            resultado.ArregloOrdenado = libros;
            return resultado;
        }
    }
}