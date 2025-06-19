using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillTest.BLL;
using SkillTest.Models;

namespace SkillTest.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        private UserManager userManager
        {
            get
            {
                return new UserManager(_context);
            }
        }

        // GET: /user
        [HttpGet]
        public ActionResult<User> Index()
        {
            var allUsers = userManager.GetActiveUsers();
            if(allUsers.Count != 0)
            {
                return Ok(allUsers);
            }
            return BadRequest("Error getting all users.");
        }

        // GET: /user/details/1
        [HttpGet("details/{id}")]
        public ActionResult<User> Details(int id)
        {
            var user = userManager.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User does not exist.");
            }
        }

        [HttpPost("create")]
        public ActionResult Create(string username, string email, string password, bool active)
        {
            userManager.CreateUser(username, email, password, active);
            return Ok();
        }

        // POST:
        [HttpPost("edit")]
        public ActionResult Edit(int id, string username, string email, string password, bool active)
        {
            userManager.EditUser(id, username, email, password, active);
            return Ok();
        }

        // DELETE:
        [HttpDelete("{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            userManager.DeleteUser(id);
            return Ok();
            
        }
    }
}
