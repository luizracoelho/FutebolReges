using System.Collections.Generic;

namespace Futebol
{
    public class Time
    {
        public int TimeId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string ImagemUrl { get; set; }
        public virtual IList<Jogador> Jogadores { get; set; }
    }
}
