using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Futebol.UI.Models
{
    public class JogadorVM
    {
        public int JogadorId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Display(Name = "Posição")]
        public PosicaoVM Posicao { get; set; }
        [Display(Name = "Posição")]
        public int PosicaoId { get; set; }
        public SelectList ListaPosicoes { get; set; }
        public TimeVM Time { get; set; }
        [Display(Name = "Time")]
        public int TimeId { get; set; }
        public SelectList ListaTimes { get; set; }
        [Display(Name = "Url da Imagem"), DataType(DataType.Url)]
        public string ImagemUrl { get; set; }
    }
}