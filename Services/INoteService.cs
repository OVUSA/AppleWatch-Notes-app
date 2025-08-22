using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Services
{
    interface INoteService
    {
        public Note updateNoteByName(string title, string userId, string content, string noteId);
        public Note createNewNote(string userId, string content, string noteTitle);
        public string deleteNote(string noteName, string userId, string noteId);
        public IEnumerable<Note> allUserNotes(string userId);
        public Note getNoteByTitle(string noteTitle, string userId, string noteId);
    }
}
