namespace BusquedaAlgoritmos.Services;

public class BusquedaService
{

    public void VerificarAsistencia()
    {
        string[] nombres =
        {
            "Ana",
            "Carlos",
            "María",
            "José",
            "Pedro",
            "Laura",
            "Luis",
            "Miguel"
        };

        Console.Write("Ingrese el nombre del estudiante: ");
        string? nombreBuscado = Console.ReadLine();

        int posicion = BusquedaSecuencial(
            nombres,
            nombreBuscado ?? "",
            StringComparer.OrdinalIgnoreCase);

        if (posicion >= 0)
            Console.WriteLine($"El estudiante '{nombres[posicion]}' asistió a clases.");
        else
            Console.WriteLine("El estudiante no está en la lista.");
    }

    public void BuscarProductoAgotado()
    {
        string[] agotados =
        {
            "Leche",
            "Pan",
            "Azúcar",
            "Aceite",
            "Huevos",
            "Arroz"
        };

        Console.Write("Ingrese el producto: ");
        string? producto = Console.ReadLine();

        int posicion = BusquedaSecuencial(
            agotados,
            producto ?? "",
            StringComparer.OrdinalIgnoreCase);

        if (posicion >= 0)
            Console.WriteLine($"El producto está agotado. Posición: {posicion}");
        else
            Console.WriteLine("El producto está disponible.");
    }



    public void BuscarCalificacion()
    {
        int[] notas =
        {
            50,
            55,
            60,
            65,
            70,
            75,
            80,
            85,
            90,
            95,
            100
        };

        Console.Write("Ingrese la nota: ");

        if (!int.TryParse(Console.ReadLine(), out int nota))
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }

        int posicion = BusquedaBinaria(notas, nota);

        if (posicion >= 0)
            Console.WriteLine($"La nota existe y está en la posición {posicion}.");
        else
            Console.WriteLine("La nota no fue encontrada.");
    }

    public void ValidarCodigoDescuento()
    {
        int[] codigos =
        {
            1001,
            1005,
            1010,
            1020,
            1035,
            1040,
            1050,
            1060,
            1080,
            1100
        };

        Console.Write("Ingrese el código: ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }

        int posicion = BusquedaBinaria(codigos, codigo);

        if (posicion >= 0)
            Console.WriteLine("Código de descuento válido.");
        else
            Console.WriteLine("Código inválido.");
    }


    public void BuscarCliente()
    {
        int[] cedulas = new int[1000];

        for (int i = 0; i < cedulas.Length; i++)
        {
            cedulas[i] = 100000 + i;
        }

        Console.Write("Ingrese la cédula: ");

        if (!int.TryParse(Console.ReadLine(), out int cedula))
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }

        int posicion = BusquedaSecuencial(
            cedulas,
            cedula,
            EqualityComparer<int>.Default);

        if (posicion >= 0)
            Console.WriteLine($"Cliente encontrado en el registro #{posicion}.");
        else
            Console.WriteLine("Cliente no encontrado.");
    }

    

    private int BusquedaSecuencial<T>(
        T[] arreglo,
        T valor,
        IEqualityComparer<T> comparador)
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (comparador.Equals(arreglo[i], valor))
                return i;
        }

        return -1;
    }

    private int BusquedaBinaria(int[] arreglo, int valor)
    {
        int izquierda = 0;
        int derecha = arreglo.Length - 1;

        while (izquierda <= derecha)
        {
            int medio = (izquierda + derecha) / 2;

            if (arreglo[medio] == valor)
                return medio;

            if (valor < arreglo[medio])
                derecha = medio - 1;
            else
                izquierda = medio + 1;
        }

        return -1;
    }
}