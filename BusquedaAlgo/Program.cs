using BusquedaAlgoritmos.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        BusquedaService busquedaService = new();

        bool salir = false;

        while (!salir)
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("      SISTEMA DE ALGORITMOS DE BÚSQUEDA");
            Console.WriteLine("==============================================");

            Console.WriteLine();
            Console.WriteLine(" PARTE I - BÚSQUEDA SECUENCIAL ");
            Console.WriteLine("1. Verificar asistencia en lista");
            Console.WriteLine("2. Revisar si un producto está agotado");

            Console.WriteLine();
            Console.WriteLine(" PARTE II - BÚSQUEDA BINARIA ");
            Console.WriteLine("3. Buscar calificación específica");
            Console.WriteLine("4. Validar código de descuento");

            Console.WriteLine();
            Console.WriteLine(" PARTE III - BÚSQUEDA EXTERNA ");
            Console.WriteLine("5. Verificar existencia de un cliente");

            Console.WriteLine();
            Console.WriteLine("0. Salir");

            Console.WriteLine("==============================================");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            Console.Clear();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("=== Verificar asistencia ===");
                    busquedaService.VerificarAsistencia();
                    break;

                case "2":
                    Console.WriteLine("=== Buscar producto agotado ===");
                    busquedaService.BuscarProductoAgotado();
                    break;

                case "3":
                    Console.WriteLine("=== Buscar calificación ===");
                    busquedaService.BuscarCalificacion();
                    break;

                case "4":
                    Console.WriteLine("=== Validar código de descuento ===");
                    busquedaService.ValidarCodigoDescuento();
                    break;

                case "5":
                    Console.WriteLine("=== Buscar cliente ===");
                    busquedaService.BuscarCliente();
                    break;

                case "0":
                    salir = true;
                    Console.WriteLine("Gracias por utilizar el sistema.");
                    continue;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}