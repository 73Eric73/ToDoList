namespace TodoApi.Models;
using System.ComponentModel.DataAnnotations;

public class TodoList
{
    [Key] public int Id { get; set; }
    public string? Name { get; set; }
    public List<TodoItem> TodoItem { get; set;} = new List<TodoItem>();

}