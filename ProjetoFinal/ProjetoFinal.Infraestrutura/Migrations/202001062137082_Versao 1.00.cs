namespace ProjetoFinal.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auditoria",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Concluido = c.Boolean(nullable: false),
                    Data = c.DateTime(nullable: false, precision: 0),
                    Proprietario_Id = c.Guid(),
                    TarefaAuditada_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Proprietario_Id)
                .ForeignKey("dbo.Tarefa", t => t.TarefaAuditada_Id);

            Sql("CREATE index `Proprietario_Id` on `Auditoria` (`Proprietario_Id` DESC)");
            Sql("CREATE index `TarefaAuditada_Id` on `Auditoria` (`TarefaAuditada_Id` DESC)");

            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarefa",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(unicode: false),
                        Concluido = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        Criticidade = c.Int(nullable: false),
                        Observacao = c.String(unicode: false),
                        Proprietario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Proprietario_Id);

            Sql("CREATE index `Proprietario_Id` on `Tarefa` (`Proprietario_Id` DESC)");

            CreateTable(
                "dbo.AuditoriaLogin",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Logou = c.Boolean(nullable: false),
                        UsuarioLogado_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioLogado_Id);

            Sql("CREATE index `UsuarioLogado_Id` on `AuditoriaLogin` (`UsuarioLogado_Id` DESC)");

            CreateTable(
                "dbo.PrioridadesUsuario",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Proprietario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Proprietario_Id);

            Sql("CREATE index `Proprietario_Id` on `PrioridadesUsuario` (`Proprietario_Id` DESC)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrioridadesUsuario", "Proprietario_Id", "dbo.Usuario");
            DropForeignKey("dbo.AuditoriaLogin", "UsuarioLogado_Id", "dbo.Usuario");
            DropForeignKey("dbo.Auditoria", "TarefaAuditada_Id", "dbo.Tarefa");
            DropForeignKey("dbo.Tarefa", "Proprietario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Auditoria", "Proprietario_Id", "dbo.Usuario");
            DropIndex("dbo.PrioridadesUsuario", new[] { "Proprietario_Id" });
            DropIndex("dbo.AuditoriaLogin", new[] { "UsuarioLogado_Id" });
            DropIndex("dbo.Tarefa", new[] { "Proprietario_Id" });
            DropIndex("dbo.Auditoria", new[] { "TarefaAuditada_Id" });
            DropIndex("dbo.Auditoria", new[] { "Proprietario_Id" });
            DropTable("dbo.PrioridadesUsuario");
            DropTable("dbo.AuditoriaLogin");
            DropTable("dbo.Tarefa");
            DropTable("dbo.Usuario");
            DropTable("dbo.Auditoria");
        }
    }
}
