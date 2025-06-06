using System.Linq;
using projectpsd.Model;

namespace projectpsd.Repositories
{
    public class UserRepository : BaseRepository<MsUser>
    {
        public MsUser GetUserByEmail(string email)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserEmail == email);
        }

        public MsUser GetUserByUsername(string username)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserName == username);
        }

        public MsUser GetUserByEmailAndPassword(string email, string hashedPassword)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserEmail == email && u.UserPassword == hashedPassword);
        }

        public IQueryable<MsUser> GetCustomers()
        {
            return db.MsUsers.Where(u => u.UserRole == "Customer");
        }
    }
}