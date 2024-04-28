using Microsoft.EntityFrameworkCore;
using SLinkUser.Domain.Entity;

namespace SLinkUser.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
       : base(options)
        {
            if (Database is not null)
                Database.EnsureCreated();
        }

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Address>? Addresses { get; set; }
        public virtual DbSet<Company>? Conpanies { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
        }
    }
}
