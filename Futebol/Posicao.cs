using System.Collections.Generic;

namespace Futebol
{
    public class Posicao
    {
        public int PosicaoId { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public virtual IList<Jogador> Jogadores { get; set; }
    }
}
