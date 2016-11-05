using System.Data.Entity.ModelConfiguration;

namespace Futebol.DAL.Mappings
{
    public class TimeMap : EntityTypeConfiguration<Time>
    {
        public TimeMap()
        {
            ToTable("Times");
            Property(x => x.Nome).IsRequired();
            Property(x => x.Sigla).IsRequired();
        }
    }
}
