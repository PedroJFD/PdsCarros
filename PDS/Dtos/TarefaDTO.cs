using System.ComponentModel.DataAnnotations;

namespace PDS.Dtos
{
    public class TarefaDTO
    {
        [Required]
        [MinLength(4)]
        public string Descricao { get; set; }
        public bool Feito { get; set; } = false;
    }
}
