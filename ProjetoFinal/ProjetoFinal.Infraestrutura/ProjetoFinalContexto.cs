using MySql.Data.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoFinal.Infraestrutura
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ProjetoFinalContexto : DbContext
    {
        public ProjetoFinalContexto()
            : base("ProjetoFinal")
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}