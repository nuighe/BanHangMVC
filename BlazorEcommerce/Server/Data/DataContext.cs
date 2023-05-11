namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });

            modelBuilder.Entity<ProductVariant>()
                .HasKey(p => new { p.ProductId, p.ProductTypeId });

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });

            modelBuilder.Entity<ProductType>().HasData(
                    new ProductType { Id = 1, Name = "64GB" },
                    new ProductType { Id = 2, Name = "128GB" },
                    new ProductType { Id = 3, Name = "256GB" },
                    new ProductType { Id = 4, Name = "512GB" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "iPhone",
                    Url = "iphone"
                },
                new Category
                {
                    Id = 2,
                    Name = "iPad",
                    Url = "ipad"
                },
                new Category
                {
                    Id = 3,
                    Name = "Mac",
                    Url = "mac"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "iPhone 14 Pro",
                        Description = "Sang trọng, quý phái",
                        System = "iOS16",
                        Screen = "6.1 inch - Tần số quét 120Hz",
                        ScreenTechnology = "OLED",
                        Battery = "3200 mAh",
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/251192/s16/iphone-14-pro-max-128gb-black-thumb-650x650.png",
                        CategoryId = 1,
                        Featured = true
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "iPhone 14 Pro Max",
                        Description = "Sang trọng, quý phái",
                        System = "iOS16",
                        Screen = "6.7 inch - Tần số quét 120Hz",
                        ScreenTechnology = "OLED",
                        Battery = "4323 mAh",
                        ImageUrl = "https://cdn.tgdd.vn/Products/Images/42/251192/s16/iphone-14-pro-max-128gb-black-thumb-650x650.png",
                        CategoryId = 1
                    }
                    );

            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 2,
                    Price = 24790000,
                    OriginalPrice = 27990000
                },
                new ProductVariant
                {
                    ProductId = 2,
                    ProductTypeId = 2,
                    Price = 26480000,
                    OriginalPrice = 29480000
                }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
