using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class HomersekletekDbContext : DbContext
    {
        public HomersekletekDbContext(DbContextOptions<HomersekletekDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreator != null)
                {
                   if (!databaseCreator.CanConnect()) databaseCreator.Create();
                   if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }

        public DbSet<Homersekletek> Homersekletek { get; set; }
    }
}
