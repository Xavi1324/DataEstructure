using OrdernamientoAlgo.Models;

namespace OrdernamientoAlgo.Services
{
    public class SelectionSortService
    {
        public ResultadoOrdenamiento<int> Ordenar(int[] preciosOriginal)
        {
            int[] precios = (int[])preciosOriginal.Clone();

            var resultado = new ResultadoOrdenamiento<int>
            {
                EtiquetaMovimiento = "Intercambios"
            };

            int n = precios.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int indiceMinimo = i;

                for (int j = i + 1; j < n; j++)
                {
                    resultado.Comparaciones++;
                    if (precios[j] < precios[indiceMinimo])
                    {
                        indiceMinimo = j;
                    }
                }

                string descripcion;
                if (indiceMinimo != i)
                {
                    (precios[i], precios[indiceMinimo]) = (precios[indiceMinimo], precios[i]);
                    resultado.Movimientos++;
                    descripcion = $"Iteración {i + 1}: índice de selección mínima = {indiceMinimo} -> se intercambia posición {i} con {indiceMinimo}";
                }
                else
                {
                    descripcion = $"Iteración {i + 1}: índice de selección mínima = {indiceMinimo} -> ya estaba en su posición";
                }

                resultado.Pasos.Add(new PasoOrdenamiento
                {
                    Numero = i + 1,
                    Descripcion = descripcion,
                    EstadoArreglo = string.Join(", ", precios)
                });
            }

            resultado.ArregloOrdenado = precios.ToList();
            return resultado;
        }
    }
}