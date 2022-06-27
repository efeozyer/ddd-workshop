using DDD.Workshop.IdentityAccess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;

namespace DDD.Workshop.IdentityAccess.Infrastructure.Persistence
{
    public  class IdentityDbContext : DbContext
    {
        private readonly DbConnection _dbConnection;

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options, DbConnection dbConnection) : base(options)
        {
            _dbConnection = dbConnection;
        }

        public DbSet<IdentityUser> IdentityUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnection);
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}