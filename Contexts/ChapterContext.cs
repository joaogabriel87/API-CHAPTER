using Chapter_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Chapter_API.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
            
        }
        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;DataBase=Chapter;Integrated Security=SSPI;TrustServerCertificate=True");
            }
        }
        public DbSet<Livro> Livros{get; set;}
    }
}