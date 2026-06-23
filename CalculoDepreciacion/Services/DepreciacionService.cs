namespace CalculoDepreciacion.Services
{
    public class DepreciacionService
    {
        public double CalcularValorResidual(double valorInicial, double tasa, int t)
        {
            if (t == 0)
                return valorInicial;

            return CalcularValorResidual(valorInicial, tasa, t - 1) * (1 - tasa / 100);
        }
        
        public bool ValidarEntradas(double valor, double tasa, int t, out string mensaje)
        {
            if (valor <= 0) { mensaje = "El valor inicial debe ser mayor a 0."; return false; }
            if (tasa <= 0 || tasa >= 100) { mensaje = "La tasa debe estar entre 0 y 100."; return false; }
            if (t < 0) { mensaje = "Los años no pueden ser negativos."; return false; }
            mensaje = string.Empty;

            return true;
        }
    }
}