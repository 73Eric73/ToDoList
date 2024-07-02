
namespace ToDoList.DTO;
public class TodoLlista

{
    public long Id { get; set; }
    public string? Name { get; set; }
    public List<TodoTask> Items { get; set; }

}
