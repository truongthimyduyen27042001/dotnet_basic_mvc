using Microsoft.EntityFrameworkCore;
 
namespace ProjectManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
 
            base.OnModelCreating(modelBuilder);
        }
    }
}
