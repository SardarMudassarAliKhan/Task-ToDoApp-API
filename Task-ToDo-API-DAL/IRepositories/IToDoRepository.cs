using Task_ToDo_API_DAL.Models;

namespace Task_ToDo_API_DAL.IRepositories
{
    public interface IToDoRepository
    {
        Task<List<ToDoTask>> GetAllToDoTasks();
        Task<ToDoTask> GetToDoTaskById(int id);
        Task<ToDoTask> AddToDoTask(ToDoTask toDoTask);
        Task<ToDoTask> UpdateToDoTask(ToDoTask toDoTask);
        Task<ToDoTask> DeleteToDoTask(int id);
    }
}
