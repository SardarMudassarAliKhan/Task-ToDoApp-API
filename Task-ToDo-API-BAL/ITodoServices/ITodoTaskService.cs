using Task_ToDo_API_DAL.Models;

namespace Task_ToDo_API_BAL.ITodoServices
{
    public interface ITodoTaskService
    {
        Task<List<ToDoTask>> GetAllTodoTasks();
        Task<ToDoTask> GetTodoTaskById(int id);
        Task<ToDoTask> AddTodoTask(ToDoTask todoTask);
        Task<ToDoTask> UpdateTodoTask(ToDoTask todoTask);
        Task<ToDoTask> DeleteTodoTask(int id);
    }
}
