using CigarWorld.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CigarWorld.Test
{
    public class InMemoryDbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<CigarWorldDbContext> dbContextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<CigarWorldDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new CigarWorldDbContext(dbContextOptions);

            context.Database.EnsureCreated();
        }

        public CigarWorldDbContext CreateContext() => new CigarWorldDbContext(dbContextOptions);

        public void Dispose() => connection.Dispose();
    }
}
