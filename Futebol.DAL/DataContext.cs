namespace Futebol.DAL
{
    using Mappings;
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new TimeMap());
            modelBuilder.Configurations.Add(new PosicaoMap());
            modelBuilder.Configurations.Add(new JogadorMap());
        }

        public DbSet<Time> Times { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
    }
}