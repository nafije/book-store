using e_Book.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace e_Book.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Data Source=NAFIJE-PC\\SQLEXPRESS;Initial Catalog=movie-ticket;Integrated Security=True;Pooling=False; trustServerCertificate=true");
        }
   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // object value=modelBuilder.UseSqlServer("connection string goes here");
          
            modelBuilder.Entity<Author_Book>().HasKey(am => new
            {
                am.AuthorID,
                am.BookId
            });
            modelBuilder.Entity<Author_Book>().HasOne(m => m.Books).WithMany(
            am => am.Author_Book).HasForeignKey(m => m.BookId);

            modelBuilder.Entity<Author_Book>().HasOne(m => m.Authors).WithMany(
            am => am.Actors_Movies).HasForeignKey(m => m.AuthorID);

            base.OnModelCreating(modelBuilder);
        }

       

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Author_Book> Author_Book { get; set; }
        public DbSet<Publishing_house> Publishing_house { get; set; }
        public DbSet<Coments> Coments { get; set; }

        //orders related table
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShopinCartItem> ShopinCartItems { get; set; }


    }

}