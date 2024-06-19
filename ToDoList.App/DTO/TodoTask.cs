namespace ToDoList.App.DTO {
    public class TodoTask {
        public string? Text {get; init;}
        public bool Done {get; set;} = false;

        // Una invocació anónima => un métode que retorna x
        // Després tenim el ??, significa que si no es null retorna la variable Text, si és null lo de la dreta 
        public override string ToString() => Text ?? string.Empty;

        // El mateix utilitzant ternaris
        /*public override string ToString()
        {
            return Text == null ? string.Empty : Text;
            
        }*/
    }
}