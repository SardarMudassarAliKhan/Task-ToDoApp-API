using Microsoft.EntityFrameworkCore;
using Task_ToDo_API_DAL.Models;

namespace Task_ToDo_API_DAL.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
