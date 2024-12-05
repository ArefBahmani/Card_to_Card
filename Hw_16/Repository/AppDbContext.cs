using CardBankTransaction_HW_15.ConfDb;
using CardBankTransaction_HW_15.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardBankTransaction_HW_15.Repository
{
    public class AppDbContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-J6I42F2\SQLEXPRESS;Initial Catalog=HW_17;User ID=SA;Password=123456;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardConfig());
            modelBuilder.ApplyConfiguration(new transactionConfig());
            modelBuilder.ApplyConfiguration(new UserConfigs()); 
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transactionn> Transactionns { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
