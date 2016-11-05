namespace Futebol.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogadores",
                c => new
                    {
                        JogadorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        PosicaoId = c.Int(nullable: false),
                        TimeId = c.Int(nullable: false),
                        ImagemUrl = c.String(),
                    })
                .PrimaryKey(t => t.JogadorId)
                .ForeignKey("dbo.Posicoes", t => t.PosicaoId, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.PosicaoId)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.Posicoes",
                c => new
                    {
                        PosicaoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Sigla = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PosicaoId);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        TimeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sigla = c.String(nullable: false),
                        ImagemUrl = c.String(),
                    })
                .PrimaryKey(t => t.TimeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogadores", "TimeId", "dbo.Times");
            DropForeignKey("dbo.Jogadores", "PosicaoId", "dbo.Posicoes");
            DropIndex("dbo.Jogadores", new[] { "TimeId" });
            DropIndex("dbo.Jogadores", new[] { "PosicaoId" });
            DropTable("dbo.Times");
            DropTable("dbo.Posicoes");
            DropTable("dbo.Jogadores");
        }
    }
}
