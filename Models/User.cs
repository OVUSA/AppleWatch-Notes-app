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
            userId =  generateUserId();
            personalNotes = new List<Note>();
        }


        public string generateUserId()
        {
            Random random = new Random();
            return random.Next(100).ToString();
        }

    }
}
