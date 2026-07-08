using OrdernamientoAlgo.Models;

namespace OrdernamientoAlgo.Services
{
    public class InsertionSortService
    {
        public ResultadoOrdenamiento<int> Ordenar(int[] tiemposOriginal)
        {
            int[] tiempos = (int[])tiemposOriginal.Clone();

            var resultado = new ResultadoOrdenamiento<int>
            {
                EtiquetaMovimiento = "Desplazamientos"
            };

            int n = tiempos.Length;

            for (int i = 1; i < n; i++)
            {
                int actual = tiempos[i];
                int j = i - 1;

                while (j >= 0)
                {
                    resultado.Comparaciones++;
                    if (tiempos[j] > actual)
                    {
                        tiempos[j + 1] = tiempos[j];
                        resultado.Movimientos++;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }

                tiempos[j + 1] = actual;

                resultado.Pasos.Add(new PasoOrdenamiento
                {
                    Numero = i,
                    Descripcion = $"Corredor #{i + 1} llega con tiempo {actual}s",
                    EstadoArreglo = string.Join(", ", tiempos)
                });
            }

            resultado.ArregloOrdenado = tiempos.ToList();
            return resultado;
        }
    }
}