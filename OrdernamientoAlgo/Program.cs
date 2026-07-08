using OrdernamientoAlgo.Models;
using OrdernamientoAlgo.Services;

namespace OrdernamientoAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            EjecutarEjercicio1BubbleSort();
            PausarEntreEjercicios();

            EjecutarEjercicio2SelectionSort();
            PausarEntreEjercicios();

            EjecutarEjercicio3InsertionSort();

            Console.WriteLine("\nFin del programa. Presiona una tecla para salir...");
            Console.ReadKey();
        }

        static void EjecutarEjercicio1BubbleSort()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine(" EJERCICIO 1: BUBBLE SORT - Ordenar libros por título");
            Console.WriteLine("=====================================================\n");

            var libros = new List<Libro>
            {
                new Libro(1, "El señor de los anillos", "J.R.R. Tolkien"),
                new Libro(2, "Cien años de soledad", "Gabriel García Márquez"),
                new Libro(3, "Don Quijote de la Mancha", "Miguel de Cervantes"),
                new Libro(4, "Rayuela", "Julio Cortázar"),
                new Libro(5, "La casa de los espíritus", "Isabel Allende"),
                new Libro(6, "Ficciones", "Jorge Luis Borges"),
                new Libro(7, "Pedro Páramo", "Juan Rulfo"),
            };

            Console.WriteLine("Catálogo original:");
            foreach (var libro in libros)
            {
                Console.WriteLine("  " + libro);
            }
            Console.WriteLine();

            var servicio = new BubbleSortService();
            var resultado = servicio.OrdenarPorTitulo(libros);

            ImprimirPasos(resultado);

            Console.WriteLine("Catálogo ordenado alfabéticamente por título:");
            foreach (var libro in resultado.ArregloOrdenado)
            {
                Console.WriteLine("  " + libro);
            }

            ImprimirEstadisticas(resultado);
        }

        static void EjecutarEjercicio2SelectionSort()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine(" EJERCICIO 2: SELECTION SORT - Ordenar inventario por precio");
            Console.WriteLine("=====================================================\n");

            int[] precios = { 250, 120, 75, 300, 100, 180, 90, 220 };

            Console.WriteLine("Precios originales: " + string.Join(", ", precios));
            Console.WriteLine();

            var servicio = new SelectionSortService();
            var resultado = servicio.Ordenar(precios);

            ImprimirPasos(resultado);

            Console.WriteLine("Precios ordenados ascendentemente: " + string.Join(", ", resultado.ArregloOrdenado));

            ImprimirEstadisticas(resultado);
        }

        static void EjecutarEjercicio3InsertionSort()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine(" EJERCICIO 3: INSERTION SORT - Ordenar tiempos de llegada");
            Console.WriteLine("=====================================================\n");

            int[] tiempos = { 58, 54, 60, 52, 57, 56, 59 };

            Console.WriteLine("Orden de llegada de los corredores (tiempos en segundos): " + string.Join(", ", tiempos));
            Console.WriteLine();

            var servicio = new InsertionSortService();
            var resultado = servicio.Ordenar(tiempos);

            ImprimirPasos(resultado);

            Console.WriteLine("Lista final de tiempos ordenada de menor a mayor: " + string.Join(", ", resultado.ArregloOrdenado));

            ImprimirEstadisticas(resultado);
        }

        static void ImprimirPasos<T>(ResultadoOrdenamiento<T> resultado)
        {
            foreach (var paso in resultado.Pasos)
            {
                Console.WriteLine($"--- {paso.Descripcion} ---");
                Console.WriteLine("  " + paso.EstadoArreglo);
                Console.WriteLine();
            }
        }

        static void ImprimirEstadisticas<T>(ResultadoOrdenamiento<T> resultado)
        {
            Console.WriteLine($"\nTotal de comparaciones: {resultado.Comparaciones}");
            Console.WriteLine($"Total de {resultado.EtiquetaMovimiento.ToLower()}: {resultado.Movimientos}");
        }

        static void PausarEntreEjercicios()
        {
            Console.WriteLine("\nPresiona una tecla para continuar con el siguiente ejercicio...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}