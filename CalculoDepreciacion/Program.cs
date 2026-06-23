using CalculoDepreciacion.Models;
using CalculoDepreciacion.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var service = new DepreciacionService();

        Console.WriteLine("=== CÁLCULO DE DEPRECIACIÓN POR SALDO DECRECIENTE ===\n");

        Console.Write("Valor inicial del activo ($): ");
        double valor = double.Parse(Console.ReadLine()!);

        Console.Write("Tasa de depreciación anual (%): ");
        double tasa = double.Parse(Console.ReadLine()!);

        Console.Write("Años transcurridos: ");
        int anios = int.Parse(Console.ReadLine()!);

        
        if (!service.ValidarEntradas(valor, tasa, anios, out string mensaje))
        {
            Console.WriteLine($"\nError: {mensaje}");
            return;
        }

        
        var activo = new ActivoFijo
        {
            ValorInicial = valor,
            TasaDepreciacion = tasa,
            AniosTranscurridos = anios
        };

        
        double resultado = service.CalcularValorResidual(activo.ValorInicial, activo.TasaDepreciacion, activo.AniosTranscurridos);

        Console.WriteLine($"\nValor residual después de {activo.AniosTranscurridos} año(s): ${resultado:F2}");
    }
}