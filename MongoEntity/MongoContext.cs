using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MongoEntity
{
    public class MongoContext : DbContext
    {
        public MongoContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Teste> Testes { get; set; }

        public DbSet<TesteItem> TesteItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Teste>().ToCollection("Teste")
                .HasMany(x => x.Items);

            modelBuilder.Entity<TesteItem>().ToCollection("TesteItems");
                //.HasOne(x => x.Teste).WithMany(x => x.Items).HasForeignKey(x => x.TesteId);

        }
    }
}
