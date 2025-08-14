using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Services
{
    interface INoteService
    {
        public Note updateNoteByName(string title, string userId);
        public Note createNewNote(string userId, string content, string noteName);
        public Boolean deleteNote(string noteName, string userId);

        public IEnumerable<Note> allUserNotes(string userId);
    }
}
