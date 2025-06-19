using Microsoft.AspNetCore.Mvc;
using SkillTest.BLL;
using SkillTest.Models;

namespace SkillTest.Controllers
{
    [Route("Task")]
    public class TaskController : Controller
    {

        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        private TaskManager taskManager
        {
            get
            {
                return new TaskManager(_context);
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = taskManager.GetAllTasks();
            if (tasks.Count != 0)
            {
                return Ok(tasks);
            }
            return BadRequest("Error getting all tasks.");
        }

        // GET: /task/details/1
        [HttpGet("details/{id}")]
        public ActionResult<User> Details(int id)
        {
            var task = taskManager.GetTaskById(id);
            if (task != null)
            {
                
                return Ok(task);
            }
            else
            {
                return NotFound("Task does not exist.");
            }
        }

        ///task/create?title=hello&description=123&userID=1&duedate=2024/01/01&Active=true
        [HttpPost("create")]
        public ActionResult Create(string title, string description, int userID, DateTime dueDate, bool active)
        {
            taskManager.CreateTask(title, description, userID, dueDate, active);
            return Ok();
        }

        [HttpGet("active")]
        public ActionResult GetActiveTasks()
        {
            var tasks = taskManager.GetActiveTasks();
            return Ok(tasks);
        }

        [HttpGet("expired")]
        public ActionResult GetExpiredTasks()
        {
            var tasks = taskManager.GetExpiredTasks();
            return Ok(tasks);
        }

        [HttpPost("edit")]
        public ActionResult Edit(int id, string title, string description, int userID, DateTime dueDate, bool active)
        {
            taskManager.EditTask(id, title, description, userID, dueDate, active);
            return Ok();
        }

        // DELETE: /task/5
        [HttpDelete("{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            taskManager.DeleteTask(id);
            return Ok();
        }
    }
}
