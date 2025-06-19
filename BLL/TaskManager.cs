using SkillTest.DAL;

namespace SkillTest.BLL
{
    public class TaskManager
    {
        private TaskRepo repo;

        public TaskManager(ApplicationDbContext DBcontext)
        {
            repo = new TaskRepo(DBcontext);
        }

        public List<Models.Task> GetActiveTasks()
        {
            return repo.GetActiveTasks();
        }

        public List<Models.Task> GetAllTasks()
        {
            return repo.GetAllTasks();
        }

        public Models.Task GetTaskById(int id)
        {
            return repo.GetTaskById(id);
        }
        public void CreateTask(string Title, string Description, int userID, DateTime dueDate, bool Active)
        {
            repo.CreateTask(Title, Description, userID, dueDate, Active);
        }

        public List<Models.Task> GetExpiredTasks()
        {
            return repo.GetExpiredTasks();
        }

        public void EditTask(int id, string Title, string Description, int userID, DateTime dueDate, bool Active)
        {
            repo.EditTask(id, Title, Description, userID, dueDate, Active);
        }

        public void DeleteTask(int id)
        {
            repo.DeleteTask(id);
        }
    }
}
