using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    public DbSet<TodoList> TodoList {get; set;} = null!;

}