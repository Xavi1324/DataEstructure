namespace OrdernamientoAlgo.Models
{
    public class ResultadoOrdenamiento<T>
    {
        public List<T> ArregloOrdenado { get; set; } = new List<T>();
        public List<PasoOrdenamiento> Pasos { get; set; } = new List<PasoOrdenamiento>();
        public int Comparaciones { get; set; }
        public int Movimientos { get; set; }
        public string EtiquetaMovimiento { get; set; } = "Movimientos";
    }
}