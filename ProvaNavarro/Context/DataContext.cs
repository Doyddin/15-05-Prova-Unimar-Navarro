using Microsoft.EntityFrameworkCore;
using ProvaNavarro.Model;

namespace ProvaNavarro.Context
{
    public class DataContext : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blog;ConnectRetryCount=0");
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Post> Post { get; set; }
    }
}
