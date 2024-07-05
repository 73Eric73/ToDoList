namespace TodoApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class TodoItem
{
    [Key] public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    [ForeignKey("ListId")] public int ListId { get; set; }
    public TodoList? TodoList {get; set;}   
}