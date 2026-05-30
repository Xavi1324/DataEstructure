using Unidimensionales.Models;

namespace Unidimensionales.Servives
{
    public class VentasService : GenericServices
    {
        public void RegistrarVentas()
        {
            int[] ventas = new int[7];

            for (int i = 0; i < ventas.Length; i++)
            {
                Console.Write($"Digite la venta del día {i + 1}: ");
                ventas[i] = GetInputs();
            }

            int total = 0;
            int mayorVenta = ventas[0];
            int diaMayorVenta = 1;

            for (int i = 0; i < ventas.Length; i++)
            {
                total += ventas[i];

                if (ventas[i] > mayorVenta)
                {
                    mayorVenta = ventas[i];
                    diaMayorVenta = i + 1;
                }
            }

            Ventas resultado = new Ventas
            {
                VentasTotales = total,
                PromedioVentas = (double)total / ventas.Length,
                DiaMayorVenta = diaMayorVenta
            };

            Console.WriteLine("\n===== RESULTADOS =====");
            Console.WriteLine($"Ventas Totales: {resultado.VentasTotales}");
            Console.WriteLine($"Promedio de Ventas: {resultado.PromedioVentas:F2}");
            Console.WriteLine($"Día con Mayor Venta: {resultado.DiaMayorVenta}");
        }
    }
}