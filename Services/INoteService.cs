using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Services
{
    interface INoteService
    {
        public Note updateNoteByName(string title, string userId, string content);
        public Note createNewNote(string userId, string content, string noteName);
        public string deleteNote(string noteName, string userId);

        public IEnumerable<Note> allUserNotes(string userId);
        public Note getNoteByName(string title, string userId);
    }
}
