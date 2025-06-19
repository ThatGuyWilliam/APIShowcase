using Microsoft.EntityFrameworkCore;

namespace SkillTest.DAL
{
    public class TaskRepo
    {
        private readonly ApplicationDbContext db;
        public TaskRepo(ApplicationDbContext dbcntx)
        {
            db = dbcntx;
        }

        public List<Models.Task> GetActiveTasks()
        {
            try
            {
                return db.Task.Where(x => x.Active).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Models.Task> GetAllTasks()
        {
            try
            {
                return db.Task.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<Models.Task> GetExpiredTasks()
        {
            try
            {
                return db.Task.Where(x => x.DueDate < DateTime.Now).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Models.Task GetTaskById(int id)
        {
            try
            {
                return db.Task.Where(x => x.ID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void CreateTask(string Title, string Description, int userID, DateTime dueDate, bool Active)
        {
            try
            {
                Models.Task task = new Models.Task();
                task.Title = Title;
                task.Description = Description;
                task.DueDate = dueDate;
                task.Active = Active;
                var user = db.Users.Where(x => x.ID == userID).FirstOrDefault();
                task.Assignee = user;
                db.Task.Add(task);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditTask(int id, string Title, string Description, int userID, DateTime dueDate, bool Active)
        {
            try
            {
                var task = db.Task.Where(x => x.ID == id).FirstOrDefault();
                if (task != null)
                {
                    task.Title = Title;
                    task.Description = Description;
                    var user = db.Users.Where(x => x.ID == userID).FirstOrDefault();
                    task.Assignee = user;
                    task.DueDate = dueDate;
                    task.Active = Active;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public void DeleteTask(int id) 
        {
            try
            {
                var task = db.Task.Where(x => x.ID == id).FirstOrDefault();
                if (task != null)
                {
                    task.Active = false;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }
}
