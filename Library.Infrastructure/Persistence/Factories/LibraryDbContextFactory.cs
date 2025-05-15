using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Library.Infrastructure.Persistence; // ajuste se necessário

namespace Library.Infrastructure.Factories // ajuste conforme o padrão do seu projeto
{
    public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();

            // 🔁 Altere a connection string conforme seu ambiente local
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Biblioteca;Trusted_Connection=True;");

            return new LibraryDbContext(optionsBuilder.Options);
        }
    }
}
