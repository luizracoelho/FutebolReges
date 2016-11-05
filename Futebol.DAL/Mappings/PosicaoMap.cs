using System.Data.Entity.ModelConfiguration;

namespace Futebol.DAL.Mappings
{
    public class PosicaoMap : EntityTypeConfiguration<Posicao>
    {
        public PosicaoMap()
        {
            ToTable("Posicoes");
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Sigla).IsRequired();
        }
    }
}
