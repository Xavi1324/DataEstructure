using Unidimensionales.Models;

namespace Unidimensionales.Servives
{
    public class TemperaturaService : GenericServices
    {
        public void RegistrarTemperaturas()
        {
            double[] temperaturas = new double[10];

            for (int i = 0; i < temperaturas.Length; i++)
            {
                Console.Write($"Digite la temperatura del día {i + 1}: ");
                temperaturas[i] = Convert.ToDouble(Console.ReadLine());
            }

            double suma = 0;
            double temperaturaMaxima = temperaturas[0];
            double temperaturaMinima = temperaturas[0];
            int diasMayor30 = 0;

            for (int i = 0; i < temperaturas.Length; i++)
            {
                suma += temperaturas[i];

                if (temperaturas[i] > temperaturaMaxima)
                {
                    temperaturaMaxima = temperaturas[i];
                }

                if (temperaturas[i] < temperaturaMinima)
                {
                    temperaturaMinima = temperaturas[i];
                }

                if (temperaturas[i] > 30)
                {
                    diasMayor30++;
                }
            }

            Temperatura resultado = new Temperatura
            {
                TemperaturaMaxima = temperaturaMaxima,
                TemperaturaMinima = temperaturaMinima,
                PromedioTemperaturas = suma / temperaturas.Length,
                DiasMayor30 = diasMayor30
            };

            Console.WriteLine("\n===== RESULTADOS =====");
            Console.WriteLine($"Temperatura Máxima: {resultado.TemperaturaMaxima}°C");
            Console.WriteLine($"Temperatura Mínima: {resultado.TemperaturaMinima}°C");
            Console.WriteLine($"Promedio: {resultado.PromedioTemperaturas:F2}°C");
            Console.WriteLine($"Días por encima de 30°C: {resultado.DiasMayor30}");
        }
    }
}