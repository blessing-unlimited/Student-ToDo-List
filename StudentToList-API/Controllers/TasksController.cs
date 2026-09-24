using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentToList_API.Models;
using StudentToList_API.Services;
using System.Security.Cryptography;
using StudentToList_API.DTO;

namespace StudentToList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _context.StudentTasks.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _context.StudentTasks.FindAsync(id);
            if (task is null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskDTO dto)
        {
            if (dto.TaskName is null)
                return NotFound();

            var task = new Tasks
            {
                Id = RandomNumberGenerator.GetInt32(1, int.MaxValue),
                TaskName = dto.TaskName,
                Description = dto.Description,
                Completed = dto.Completed,
                ImportanceList = (Tasks.Importance)dto.ImportanceList
            };

            await _context.StudentTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return Ok(CreatedAtAction(nameof(GetTask), new { id = task.Id }, task));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTask(int id, Tasks newTask)
        {
            var task = await _context.StudentTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task is null)
                return NotFound();
            

            task.TaskName = newTask.TaskName;
            task.Description = newTask.Description;
            task.Completed = newTask.Completed;
            task.ImportanceList = newTask.ImportanceList;

            await _context.SaveChangesAsync();
            return Ok(NoContent());

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.StudentTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task is null)
                return NotFound();

            _context.StudentTasks.Remove(task);
            await _context.SaveChangesAsync();
            return Ok(NoContent());
        }
    }
}
