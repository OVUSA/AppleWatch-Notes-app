using AppleWatch_Notes_app.Data;
using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;

namespace AppleWatch_Notes_app.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContex _context;

        public NoteService()
        {
            _context = new AppDbContex();
        }
        public IEnumerable<Note> allUserNotes(string userId)
        {
            return _context.getAllNotes(userId);
        }

        public Note createNewNote(string userId, string? content, string noteName)
        {
            _context.createNote(userId, content, noteName,"01");
            return getNoteByName(noteName, userId);

        }

        public string deleteNote(string noteName, string userId)
        {
            _context.deleteNote(noteName, userId);
            return $"Note {noteName} is successfully deleted.";         
        }

        public Note updateNoteByName(string title, string userId, string content)
        {
            _context.updateNoteByName(title, userId, content);
            return getNoteByName(title, userId);
        }

        public Note getNoteByName(string title, string userId)
        {
            return _context.getNoteByName(title, userId);
        }

    }
}
