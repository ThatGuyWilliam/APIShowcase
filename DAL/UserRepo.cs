using Microsoft.EntityFrameworkCore;
using SkillTest.Models;

namespace SkillTest.DAL
{
    public class UserRepo
    {
        private readonly ApplicationDbContext db;
        public UserRepo(ApplicationDbContext dbcntx)
        {
            db = dbcntx;
        }

        public List<Models.User> GetActiveUsers()
        {
            return db.Users.Where(x => x.Active).ToList();
        }

        public Models.User GetUser(int id) {
            return db.Users.Where(x => x.ID == id).FirstOrDefault();
        }

        public void DeleteUser(int id)
        {
            try
            {
                var user = db.Users.Where(x => x.ID == id).FirstOrDefault();
                if (user != null)
                {
                    user.Active = false;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void EditUser(int id, string username, string email, string password, bool active)
        {
            try
            {
                var user = db.Users.Where(x => x.ID == id).FirstOrDefault();
                if (user != null)
                {
                    user.UserName = username;
                    user.Email = email;
                    user.Password = password;
                    user.Active = active;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateUser(string username, string Email, string password, bool Active)
        {
            try
            {
                User user = new User();
                user.UserName = username;
                user.Email = Email;
                user.Password = password;
                user.Active = Active;
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            } 
        }

    }
}
