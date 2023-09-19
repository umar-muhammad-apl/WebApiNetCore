using AspNetCorePluralSight.Entities;
using Microsoft.EntityFrameworkCore;


namespace WebApiAspNet7Patrick.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<User>()
        //         .HasMany(e => e.Posts)
        //         .WithOne(e => e.User)
        //         .HasForeignKey(e => e.UserId)
        //         .IsRequired();
        // }
    }
}
