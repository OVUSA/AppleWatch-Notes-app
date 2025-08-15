using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Models
{
    public class User
    {
        private string Name;
        public string userId { get; private set; }
        
        public List<Note> personalNotes;

        public User(string userName)
        {
            Name = userName;
            userId =  (userName + generateUserId()).ToString();
            personalNotes = new List<Note>();
        }


        public int generateUserId()
        {
            Random random = new Random();
            return random.Next(100);
        }

    }
}
