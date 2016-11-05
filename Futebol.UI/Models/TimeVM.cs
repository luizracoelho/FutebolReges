using System.ComponentModel.DataAnnotations;

namespace Futebol.UI.Models
{
    public class TimeVM
    {
        public int TimeId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required, RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "A Sigla só pode conter letras."), MaxLength(3)]
        public string Sigla { get; set; }
        [Display(Name = "Url da Imagem"), DataType(DataType.Url)]
        public string ImagemUrl { get; set; }
    }
}