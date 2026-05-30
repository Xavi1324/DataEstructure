

using Unidimensionales.Interfaces;

namespace Unidimensionales.Servives
{
    public class GenericServices : IGenericInfaces
    {
        public int GetInputs()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
