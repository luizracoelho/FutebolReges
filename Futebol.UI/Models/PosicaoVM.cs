using System.ComponentModel.DataAnnotations;

namespace Futebol.UI.Models
{
    public class PosicaoVM
    {
        public int PosicaoId { get; set; }
        [Required, Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required, RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "A Sigla só pode conter letras."), MaxLength(2)]
        public string Sigla { get; set; }
    }
}