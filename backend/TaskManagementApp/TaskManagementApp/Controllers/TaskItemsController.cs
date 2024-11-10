using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.bl;
using TaskManagementApp.Models;

namespace TaskManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly TaskBL _taskBL;

        public TaskItemsController(TaskBL taskBL)
        {
            _taskBL = taskBL;
        }

        // GET: api/TaskItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            var taskItems = await _taskBL.GetTasksAsync();
            return Ok(taskItems);
        }

        // GET: api/TaskItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(int id)
        {
            var taskItem = await _taskBL.GetTaskByIdAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return Ok(taskItem);
        }

        // POST: api/TaskItems
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem)
        {
            await _taskBL.AddTaskAsync(taskItem);
            return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.TaskItemId }, taskItem);
        }

        // PUT: api/TaskItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(int id, TaskItem taskItem)
        {
            if (id != taskItem.TaskItemId)
            {
                return BadRequest();
            }

            await _taskBL.UpdateTaskAsync(taskItem);

            return NoContent();
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var taskItem = await _taskBL.GetTaskByIdAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            await _taskBL.DeleteTaskAsync(taskItem);

            return NoContent();
        }
    }
}
