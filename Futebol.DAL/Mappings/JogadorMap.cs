using System.Data.Entity.ModelConfiguration;

namespace Futebol.DAL.Mappings
{
    public class JogadorMap : EntityTypeConfiguration<Jogador>
    {
        public JogadorMap()
        {
            ToTable("Jogadores");
            Property(x => x.Nome).IsRequired();
            Property(x => x.PosicaoId).IsRequired();
            Property(x => x.TimeId).IsRequired();
        }
    }
}
