namespace ProjetoFinal.Infraestrutura.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Versao400 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("PrioridadesUsuario", "Proprietario_Id", "Usuario");
            DropIndex("PrioridadesUsuario", "Proprietario_Id", new[] { "Proprietario_Id" });
            AddColumn("PrioridadesUsuario", "IdTarefa", c => c.Guid(nullable: false));
            AlterColumn("PrioridadesUsuario", "Proprietario_Id", c => c.Guid(nullable: false));
            CreateIndex("PrioridadesUsuario", "Proprietario_Id");
            CreateIndex("PrioridadesUsuario", "IdTarefa");
            AddForeignKey("PrioridadesUsuario", "IdTarefa", "Tarefa", "Id", cascadeDelete: true);
            AddForeignKey("PrioridadesUsuario", "Proprietario_Id", "Usuario", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("PrioridadesUsuario", "Proprietario_Id", "Usuario");
            DropForeignKey("PrioridadesUsuario", "IdTarefa", "Tarefa");
            DropIndex("PrioridadesUsuario", new[] { "IdTarefa" });
            DropIndex("PrioridadesUsuario", new[] { "Proprietario_Id" });
            AlterColumn("PrioridadesUsuario", "Proprietario_Id", c => c.Guid());
            DropColumn("PrioridadesUsuario", "IdTarefa");
            CreateIndex("PrioridadesUsuario", "Proprietario_Id");
            AddForeignKey("PrioridadesUsuario", "Proprietario_Id", "Usuario", "Id");
        }
    }
}