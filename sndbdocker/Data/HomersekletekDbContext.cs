using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using sndbdocker.Models;

namespace sndbdocker.Data
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
                    //Ha van adatbázis, akkor töröljük
                    //if (databaseCreator.HasTables()) databaseCreator.EnsureDeleted();
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                    //if (!databaseCreator.HasTables()) databaseCreator.EnsureCreated();
                    
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }

        public DbSet<Homersekletek> Homersekletek { get; set; }
        public DbSet<Coffee> Coffee { get; set; }
    }
}
