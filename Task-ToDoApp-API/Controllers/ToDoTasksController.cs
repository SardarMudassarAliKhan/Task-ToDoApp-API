using Microsoft.AspNetCore.Mvc;
using Task_ToDo_API_BAL.ITodoServices;
using Task_ToDo_API_DAL.Models;

namespace Task_ToDoApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTasksController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;

        public ToDoTasksController(ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }

        [HttpGet(nameof(GetAllTodoTasks))]
        public async Task<IActionResult> GetAllTodoTasks()
        {
            try
            {
                var todoTasks = await _todoTaskService.GetAllTodoTasks();
                return Ok(todoTasks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet(nameof(GetTodoTaskById))]
        public async Task<IActionResult> GetTodoTaskById(int id)
        {
            try
            {
                var todoTask = await _todoTaskService.GetTodoTaskById(id);
                if (todoTask == null)
                {
                    return NotFound();
                }
                return Ok(todoTask);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost(nameof(AddTodoTask))]
        public async Task<IActionResult> AddTodoTask(ToDoTask todoTask)
        {
            try
            {
                var addedTodoTask = await _todoTaskService.AddTodoTask(todoTask);
                return CreatedAtAction(nameof(GetTodoTaskById), new { id = addedTodoTask.Id }, addedTodoTask);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut(nameof(UpdateTodoTask))]
        public async Task<IActionResult> UpdateTodoTask(int id, ToDoTask todoTask)
        {
            try
            {
                if (id != todoTask.Id)
                {
                    return BadRequest("Id mismatch");
                }
                var updatedTodoTask = await _todoTaskService.UpdateTodoTask(todoTask);
                if (updatedTodoTask == null)
                {
                    return NotFound();
                }
                return Ok(updatedTodoTask);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete(nameof(DeleteTodoTask))]
        public async Task<IActionResult> DeleteTodoTask(int id)
        {
            try
            {
                var deletedTodoTask = await _todoTaskService.DeleteTodoTask(id);
                if (deletedTodoTask == null)
                {
                    return NotFound();
                }
                return Ok(deletedTodoTask);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
