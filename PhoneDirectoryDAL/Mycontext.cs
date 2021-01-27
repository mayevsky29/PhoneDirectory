using Microsoft.EntityFrameworkCore;

namespace PhoneDirectoryDAL
{
   public class Mycontext : DbContext
    {
        // Підключення бази даних до проекта
        public DbSet<PhoneDir> phoneDirs { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=95.214.10.36;Port=5432;Database=mayevskydb;Username=maey;Password=$544$B77w**G)K$t!Ube22}mav");
        }
    }
}
