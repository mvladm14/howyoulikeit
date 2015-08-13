using howyoulikeit.Models.myevent;
using howyoulikeit.Models.user;
using System.Data.Entity;

namespace howyoulikeit.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().Property(h => h.Title).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Blog>().Property(h => h.Name).HasMaxLength(200).IsRequired();
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MyEvent> MyEvents { get; set; }
        public DbSet<Emoji> MyEmojis { get; set; }
    }
}
