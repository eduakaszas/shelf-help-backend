using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Count).IsRequired();
            entity.Property(e => e.ExpirationDate).IsRequired(false);
            entity.Property(e => e.ConsumptionRate).IsRequired();
            entity.Property(e => e.Category).IsRequired(false);
        });
    }
}