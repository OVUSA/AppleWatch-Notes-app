using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Models
{
    public class User
    {
        private string Name;
        private string userId;
        
        IEnumerable<Note> personalNotes;

        public User(string userName, string userId = "userId1")
        {
            Name = userName;
            userId =  (userName + generateUserId()).ToString();
            personalNotes = new IEnumerable<Note>
        }


        public int generateUserId()
        {
            Random random = new Random();
            return random.Next(100);
        }

    }
}
