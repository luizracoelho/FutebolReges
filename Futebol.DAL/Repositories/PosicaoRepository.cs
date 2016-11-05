using Onsoft.Data;

namespace Futebol.DAL.Repositories
{
    public class PosicaoRepository : OnDbAction<Posicao>
    {
        public PosicaoRepository()
        {
            Context = new DataContext();
        }
    }
}
