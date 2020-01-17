namespace ProjetoFinal.Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao300 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Nome", c => c.String(maxLength: 200, storeType: "nvarchar"));
            AlterColumn("dbo.Tarefa", "Descricao", c => c.String(maxLength: 200, storeType: "nvarchar"));
            AlterColumn("dbo.Tarefa", "Observacao", c => c.String(maxLength: 1000, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tarefa", "Observacao", c => c.String(unicode: false));
            AlterColumn("dbo.Tarefa", "Descricao", c => c.String(unicode: false));
            AlterColumn("dbo.Usuario", "Nome", c => c.String(unicode: false));
        }
    }
}
