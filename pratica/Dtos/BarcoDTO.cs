using pratica.Models;

namespace pratica.Dtos
{
    public class BarcoDTO
    {
        public int Id { get; set; }
        public int NumMatricula { get; set; }
        public string Nombre { get; set; } = null!;
        public int NumAmarre { get; set; }
        public double Cuota { get; set; }
        public SocioDTO Socio { get; set; } = null!;
    }
}
