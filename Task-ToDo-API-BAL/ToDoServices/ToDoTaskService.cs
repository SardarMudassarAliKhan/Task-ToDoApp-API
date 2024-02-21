using Task_ToDo_API_BAL.ITodoServices;
using Task_ToDo_API_DAL.IRepositories;
using Task_ToDo_API_DAL.Models;

namespace Task_ToDo_API_BAL.ToDoServices
{
    public class ToDoTaskService : ITodoTaskService
    {   
        private readonly IToDoRepository _todoTaskRepository;

        public ToDoTaskService(IToDoRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public async Task<ToDoTask> AddTodoTask(ToDoTask todoTask)
        {
            try
            {
                return await _todoTaskRepository.AddToDoTask(todoTask);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ToDoTask> DeleteTodoTask(int id)
        {
            try
            {
                return await _todoTaskRepository.DeleteToDoTask(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ToDoTask>> GetAllTodoTasks()
        {
            try
            {
                return await _todoTaskRepository.GetAllToDoTasks();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ToDoTask> GetTodoTaskById(int id)
        {
            try
            {
                return await _todoTaskRepository.GetToDoTaskById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ToDoTask> UpdateTodoTask(ToDoTask todoTask)
        {
            try
            {
                return await _todoTaskRepository.UpdateToDoTask(todoTask);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
