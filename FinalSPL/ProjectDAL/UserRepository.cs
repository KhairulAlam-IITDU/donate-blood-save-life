using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class UserRepository
    {
        DBSLEntities myOnlineBloodDonorEntities = null;

        public UserRepository()
        {
            myOnlineBloodDonorEntities = new DBSLEntities();
        }

        public bool AddUser(User user)
        {
            myOnlineBloodDonorEntities.Users.Add(user);
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public bool EditUser(User user)
        {
            myOnlineBloodDonorEntities.Users.Attach(user);
            myOnlineBloodDonorEntities.Entry(user).State = System.Data.Entity.EntityState.Modified;
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public bool DeleteUser(User user)
        {
            myOnlineBloodDonorEntities.Users.Attach(user);
            myOnlineBloodDonorEntities.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public List<User> GetUserList()
        {
            return myOnlineBloodDonorEntities.Users.ToList();
        }

        public User GetUserByUsername(String username)
        {
            return myOnlineBloodDonorEntities.Users.FirstOrDefault(u => u.UserName == username);
        }

        public User GetUserByUserNameAndPassword(string username, string password)
        {
            return myOnlineBloodDonorEntities.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public bool Validuser(string username, string password)
        {
            return myOnlineBloodDonorEntities.Users.Count(u => u.UserName == username && u.Password == password) > 0;
        }
    }
}
