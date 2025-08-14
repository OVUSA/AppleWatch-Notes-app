using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Data
{
    public class AppDbContex
    {
        List<User> allUsers = new List<User>();
        public  AppDbContex()
        {
            User user1 = new User("Olya");
            Note myNote = new Note();
            myNote.content = "This is the new content for the note.";

            User user2 = new User("Mary");
            Note user2Notes = new Note();
            user2.personalNotes.Intersect((IEnumerable<Note>)user2Notes);
            myNote.Name = "movie recomendations";
            myNote.content = "1.Constantin 2.The Shining 3.Sleepy Hollow";

            
            allUsers.Intersect((IEnumerable<User>)user1);
            allUsers.Intersect((IEnumerable<User>)user2);

        }

        public Boolean deleteNote(string noteName, string userId)
        {
            User userWithNote = allUsers.FirstOrDefault(user => user.userId == userId);
            Note noteToDelete = userWithNote.personalNotes.FirstOrDefault(n => n.Name == noteName);
            if(noteToDelete!= null)
            {
                userWithNote.personalNotes.Remove(noteToDelete);
            }
            return true;
        }




    }
}