namespace Unidimensionales.Servives
{
    public class InversionArregloService : GenericServices
    {
        public void InvertirArreglo()
        {
            int[] numeros = new int[6];

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write($"Digite el número {i + 1}: ");
                numeros[i] = GetInputs();
            }

            Console.WriteLine("\n===== ARREGLO EN ORDEN INVERSO =====");

            for (int i = numeros.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(numeros[i]);
            }
        }
    }
}