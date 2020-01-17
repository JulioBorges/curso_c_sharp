using MySql.Data.Entity;
using ProjetoFinal.Dominio;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
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
            this.Configuration.LazyLoadingEnabled = true;
            // this.Configuration.UseDatabaseNullSemantics = true;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<PrioridadesUsuario> Prioridades { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }
        public DbSet<AuditoriaLogin> AuditoriaLogin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configuração manual
            //modelBuilder.Entity<Usuario>()
            //    .Property(o => o.Nome)
            //    .HasMaxLength(200);

            // Configuração manual via classe externa
            //modelBuilder.Configurations.Add(new UsuarioConfig());
        }
    }

    //public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    //{
    //    public UsuarioConfig()
    //    {
    //        Property(o => o.Nome)
    //            .HasMaxLength(200);
    //    }
    //}
}