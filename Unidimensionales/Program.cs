using Unidimensionales.Servives;

internal class Program
{
    private static void Main(string[] args)
    {
        int opcion;
        VentasService ventasService = new VentasService();
        TemperaturaService temperaturaService = new TemperaturaService();
        InversionArregloService inversionArregloService = new InversionArregloService();

        do
        {
            Console.Clear();

            Console.WriteLine("===== MENÚ =====");
            Console.WriteLine("1. Ventas Diarias");
            Console.WriteLine("2. Temperaturas");
            Console.WriteLine("3. Inversión de Arreglo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ventasService.RegistrarVentas();
                    break;

                case 2:
                    temperaturaService.RegistrarTemperaturas();
                    break;

                case 3:
                    inversionArregloService.InvertirArreglo();
                    break;

                case 0:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 0);
    }
}