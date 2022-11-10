using CigarWorld.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Data
{
    public class CigarWorldDbContext : IdentityDbContext<User>
    {
        public CigarWorldDbContext(DbContextOptions<CigarWorldDbContext> options)
            : base(options)
        {

        }

        public DbSet<Cigar> Cigars { get; set; }
        public DbSet<Ashtray> Ashtrays { get; set; }
        public DbSet<Cigarillo> Cigarillos { get; set; }
        public DbSet<Cutter> Cutters { get; set; }
        public DbSet<Humidor> Humidors { get; set; }
        public DbSet<CigarPocketCase> CigarPocketCases { get; set; }
        public DbSet<Lighter> Lighters { get; set; }

        
    }
}