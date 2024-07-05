using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura la relació un a molts
        modelBuilder.Entity<TodoList>()
            .HasMany(a => a.TodoItem)
            .WithOne(b => b.TodoList)
            .HasForeignKey(b => b.ListId);
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    public DbSet<TodoList> TodoList {get; set;} = null!;

    

}