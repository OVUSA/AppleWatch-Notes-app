using AppleWatch_Notes_app.Data;
using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;

namespace AppleWatch_Notes_app.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContex _context;

        public NoteService(AppDbContex context)
        {
            _context = context;
        }
        public IEnumerable<Note> allUserNotes(string userId)
        {
            throw new NotImplementedException();
        }

        public Note createNewNote(string userId, string? content, string noteName)
        {
            throw new NotImplementedException();
        }

        public Boolean deleteNote(string noteName, string userId)
        {
            return _context.deleteNote(noteName, userId);
           
        }

        public Note updateNoteByName(string title, string userId)
        {
            throw new NotImplementedException();
        }


    }
}
