using Microsoft.EntityFrameworkCore;
using Emigrante.App.Dominio;


namespace 
Emigrante.App.Persistencia
{
    public class Contexto: DbContext{
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Migrante> Migrantes { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Grupo> Grupos  { get; set; }
        public DbSet<UsuarioGerencia> UsuariosGerencia { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = GrupoDevelopersTeamX");
            }
        }
    }
}
