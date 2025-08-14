using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Services
{
    interface INoteService
    {
        public Note updateNoteByName(string title);
        public Note createNewNote(string Name, string content);
        public void deleteNote(string noteName, int userId);
    }
}
