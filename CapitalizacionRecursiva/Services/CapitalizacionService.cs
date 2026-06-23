namespace CapitalizacionRecursiva.Services
{
    public class CapitalizacionService
    {
        public double CalcularMonto(double capital, double tasa, int n)
        {
            if (n == 0)
                return capital;

            double i = tasa / 100;
            return CalcularMonto(capital, tasa, n - 1) * (1 + i);
        }

        public bool ValidarEntradas(double capital, double tasa, int n, out string mensaje)
        {
            if (capital <= 0) { mensaje = "El capital debe ser mayor a 0."; return false; }
            if (tasa <= 0 || tasa >= 100) { mensaje = "La tasa debe estar entre 0 y 100."; return false; }
            if (n < 0) { mensaje = "Los años no pueden ser negativos."; return false; }
            mensaje = string.Empty;
            return true;
        }
    }
}