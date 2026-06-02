using Average.Servives;

internal class Program
{
    private static void Main(string[] args)
    {
        CalcularPromedio promedioService = new CalcularPromedio();

        promedioService.Calcular();
    }
}