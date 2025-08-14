using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Data
{
    public class AppDbContex
    {

        public IEnumerable<User> existingData()
        {
            User user1 = new User("Olya");
            Note myNote = new Note();
            myNote.content = "This is the new content for the note.";

            User user2 = new User("Mary");
            Note user2Notes = new Note();
            myNote.Name = "movie recomendations";
            myNote.content = "1.Constantin 2.The Shining 3.Sleepy Hollow";

            IEnumerable<User> allUsers = new List<User>();
            allUsers.Intersect((IEnumerable<User>)user1);
            allUsers.Intersect((IEnumerable<User>)user2);

            return allUsers;

        }

    }
}