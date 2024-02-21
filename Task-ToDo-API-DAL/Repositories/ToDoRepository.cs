using Microsoft.EntityFrameworkCore;
using Task_ToDo_API_DAL.ApplicationDbContext;
using Task_ToDo_API_DAL.IRepositories;
using Task_ToDo_API_DAL.Models;

namespace Task_ToDo_API_DAL.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext toDoAppDbContext;

        public ToDoRepository(AppDbContext appDbContext)
        {
            toDoAppDbContext = appDbContext;
        }

        public async Task<ToDoTask> AddToDoTask(ToDoTask toDo)
        {
            try
            {
                toDoAppDbContext.Add(toDo);
                await toDoAppDbContext.SaveChangesAsync();
                return toDo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ToDoTask> DeleteToDoTask(int id)
        {
            try
            {
                var toDo = await toDoAppDbContext.ToDoTasks.FindAsync(id);
                if (toDo == null)
                {
                    return null;
                }

                toDoAppDbContext.Remove(toDo);
                await toDoAppDbContext.SaveChangesAsync();
                return toDo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ToDoTask>> GetAllToDoTasks()
        {
            try
            {
                return await toDoAppDbContext.ToDoTasks.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ToDoTask> GetToDoTaskById(int id)
        {
            try
            {
                return await toDoAppDbContext.ToDoTasks.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ToDoTask> UpdateToDoTask(ToDoTask toDo)
        {
            try
            {
                toDoAppDbContext.Entry(toDo).State = EntityState.Modified;
                await toDoAppDbContext.SaveChangesAsync();
                return toDo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
