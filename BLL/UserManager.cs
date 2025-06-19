using SkillTest.DAL;

namespace SkillTest.BLL
{
    public class UserManager
    {
        private UserRepo repo;

        public UserManager(ApplicationDbContext DBcontext)
        {
            repo = new UserRepo(DBcontext);
        }

        public List<Models.User> GetActiveUsers()
        {
            return repo.GetActiveUsers();
        }

        public Models.User GetUser(int id)
        {
            return repo.GetUser(id);
        }

        public void CreateUser(string username, string Email, string password, bool Active)
        {
            repo.CreateUser(username, Email, password, Active);
        }

        public void EditUser(int id, string username, string email, string password, bool active)
        {
            repo.EditUser(id, username, email, password, active);
        }

        public void DeleteUser(int id)
        {
            repo.DeleteUser(id);
        }
    }
}
