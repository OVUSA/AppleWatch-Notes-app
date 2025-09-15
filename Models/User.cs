using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Models
{
    public class User
    {
        public string Name { get;  set; }
        public string userId { get; set; }
        
        public List<Note> personalNotes;
        public string PasswordHash { get; set; }

        public User(string userName, string userID)
        { 
            Name = userName;
            userId = userID;
            personalNotes = new List<Note>();
            
        }
        public User() { }

        public string generateUserId()
        {
            Random random = new Random();
            return random.Next(100).ToString();
        }

    }
}
