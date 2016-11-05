using Onsoft.Data;

namespace Futebol.DAL.Repositories
{
    public class JogadorRepository : OnDbAction<Jogador>
    {
        public JogadorRepository()
        {
            Context = new DataContext();
        }
    }
}
