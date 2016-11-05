namespace Futebol
{
    public class Jogador
    {
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public Posicao Posicao { get; set; }
        public int PosicaoId { get; set; }
        public Time Time { get; set; }
        public int TimeId { get; set; }
        public string ImagemUrl { get; set; }
    }
}
