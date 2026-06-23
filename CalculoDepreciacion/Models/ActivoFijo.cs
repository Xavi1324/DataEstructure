namespace CalculoDepreciacion.Models
{
    public class ActivoFijo
    {
        public double ValorInicial { get; set; }
        public double TasaDepreciacion { get; set; }  // en %
        public int AniosTranscurridos { get; set; }
    }
}