using CapitalizacionRecursiva.Models;
using CapitalizacionRecursiva.Services;
using System.Runtime.ConstrainedExecution;

internal class Program
{
    private static void Main(string[] args)
    {
        var service = new CapitalizacionService();

        Console.WriteLine("=== MÓDULO DE CAPITALIZACIÓN RECURSIVA (INTERÉS COMPUESTO) ===\n");

        Console.Write("Capital inicial ($): ");
        double capital = double.Parse(Console.ReadLine()!);

        Console.Write("Tasa de interés anual (%): ");
        double tasa = double.Parse(Console.ReadLine()!);

        Console.Write("Años de inversión: ");
        int anios = int.Parse(Console.ReadLine()!);

        if (!service.ValidarEntradas(capital, tasa, anios, out string mensaje))
        {
            Console.WriteLine($"\nError: {mensaje}");
            return;
        }

        var inversion = new Inversion
        {
            CapitalInicial = capital,
            TasaInteres = tasa,
            Anios = anios
        };

        double resultado = service.CalcularMonto(inversion.CapitalInicial, inversion.TasaInteres, inversion.Anios);

        Console.WriteLine($"\nMonto acumulado después de {inversion.Anios} año(s): ${resultado:F2}");
    }
}