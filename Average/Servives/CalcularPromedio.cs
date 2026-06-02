namespace Average.Servives
{
    public class CalcularPromedio
    {
        public void Calcular()
        {
            int suma = 0;
            int cantidad = 0;
            int input;

            do
            {
                Console.Write("Digite un número (0 para terminar): ");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 0)
                {
                    suma += input;
                    cantidad++;
                }

            } while (input != 0);

            double promedio = (double)suma / cantidad;

            Console.WriteLine($"Promedio: {promedio:F2}");
        }
    }
}