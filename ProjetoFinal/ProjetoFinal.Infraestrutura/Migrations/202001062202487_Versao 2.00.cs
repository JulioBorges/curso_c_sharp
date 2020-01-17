namespace ProjetoFinal.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao200 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Conectado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Conectado");
        }
    }
}
