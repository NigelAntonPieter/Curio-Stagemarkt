using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProtoType_Stagemarkt.Models
{
    public class Appdbcontext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        // Constructor voor dependency injection
        public Appdbcontext(DbContextOptions<Appdbcontext> options)
            : base(options)
        {
        }

        // Constructor zonder parameters voor OnConfiguring
        public Appdbcontext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "port=3306;" +
                "user=root;" +
                "password=KutLuna;" +
                "database=CurioStagemarkt;",
            ServerVersion.Parse("5.7.33-winx64")
            );
        }
    }
}
