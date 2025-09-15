using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Data
{
    public class UserRepository
    {

        private IDictionary<string, User> Users = new Dictionary<string, User>();

        public void Add(User user)
        {
            Users[user.userId] = user;
        }

        public User GetByUserName(string userName)
       {
            return Users.FirstOrDefault(u => u.Value.Name == userName).Value;
        }
    }
}
