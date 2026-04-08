using Microsoft.EntityFrameworkCore;
using EF_Core_MVC_1_Account.Entities;

namespace EF_Core_MVC_1_Account.Database
{
    public class AppDbContext : DbContext
    {
        // Define connection string with your Data Source
        private readonly string _connectionString = "Data Source=DESKTOP-VDQELDT\\SQLEXPRESS;Initial Catalog=EF_Core_MVC_1_Account_DB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().ToTable("Accounts");
        }
    }
}