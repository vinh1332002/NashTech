using Microsoft.EntityFrameworkCore;
using assignment2.Models;

namespace assignment2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                            .ToTable("Category")
                            .HasKey(cat => cat.Id);
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.Id)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .UseIdentityColumn()
                            .IsRequired();
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryName)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar(100)")
                            .IsRequired();

            modelBuilder.Entity<Product>()
                            .ToTable("Product")
                            .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                            .HasOne<Category>(cat => cat.Category)
                            .WithMany(cat => cat.Products)
                            .HasForeignKey(cat => cat.CategoryId);
            modelBuilder.Entity<Product>()
                            .Property(cat => cat.Id)
                            .HasColumnName("ProductId")
                            .HasColumnType("int")
                            .UseIdentityColumn()
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(cat => cat.ProductName)
                            .HasColumnName("ProductName")
                            .HasColumnType("nvarchar(100)")
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(cat => cat.Manufacture)
                            .HasColumnName("ProductManufacture")
                            .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Product>()
                            .Property(cat => cat.CategoryId)
                            .HasColumnName("ProductCategoryId")
                            .HasColumnType("int")
                            .IsRequired();

            modelBuilder.Entity<Category>()
                            .HasData(new Category
                            {
                                Id = 1,
                                CategoryName = "Computer"
                            });
            modelBuilder.Entity<Product>()
                            .HasData(new Product
                            {
                                Id = 1,
                                ProductName = "Casio",
                                CategoryId = 1,
                                Manufacture = "ok"
                            });

        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}