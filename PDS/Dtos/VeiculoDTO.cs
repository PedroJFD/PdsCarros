using System.ComponentModel.DataAnnotations;

namespace PDS.Dtos
{
    public class VeiculoDTO
    {
        [Required]
        [MinLength(4)]
        public string Marca { get; set; }
        [Required]
        [MinLength(5)]
        public string Modelo { get; set; }
        [Required]
        public int AnoFab { get; set; }
        [Required]
        public int AnoModelo { get; set; }
        [Required]
        public string Placa { get; set; }
    }
}
