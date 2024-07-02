using Microsoft.EntityFrameworkCore;
using SpendWise_Server.Models;
using SpendWise_Server.Models.Models;


namespace SpendWise_Server.Repos.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<Economies> Economies { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Income> Income_Categories { get; set; }
        public DbSet<Incomes> Incomes { get; set; }
        public DbSet<Expense_Categories> Expense_Categories {get; set;}
        public DbSet<Expenses> Expenses {get; set;}
        public DbSet<User_Categories> User_Categories {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasKey(k => k.Id);

            modelBuilder.Entity<Exchange>().HasKey(cd => new { cd.FirstCurrencyId, cd.SecondCurrencyId });

            modelBuilder.Entity<Incomes>()
                .HasOne(i => i.User)
                .WithMany(u => u.Incomes)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Incomes>()
                .HasOne(i => i.Income_Category)
                .WithMany(ic => ic.Incomes)
                .HasForeignKey(i => i.Income_CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User_Categories>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.User_Categories)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<User_Categories>()
                .HasOne(uc => uc.Expense_Category)
                .WithMany(ec => ec.User_Categories)
                .HasForeignKey(uc => uc.Expense_CategoryId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Exchange>()
                .HasOne(e => e.FirstCurrency)
                .WithMany(c => c.FirstExchanges)
                .HasForeignKey(e => e.FirstCurrencyId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Exchange>()
                .HasOne(e => e.SecondCurrency)
                .WithMany(c => c.SecondExchanges)
                .HasForeignKey(e => e.SecondCurrencyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Expenses>()
                .HasOne(c => c.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
