namespace Task_ToDo_API_DAL.Models
{
    public class ToDoTask : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string Priority { get; set; }
        public string status { get; set; }
    }
}
