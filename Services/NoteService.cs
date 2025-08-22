using AppleWatch_Notes_app.Data;
using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Note createNewNote(string noteTitle, string content, string userId) {


            string noteId = (allUserNotes(userId).Count()+1).ToString();

            DateTime createdAt = DateTime.Now;
            _context.createNote(userId, content, noteTitle,userId+noteId, createdAt.ToString());

            return getNoteByTitle(noteTitle, userId);
        }
    
  

        public string deleteNote(string noteName, string userId, string noteId)
        {
            _context.deleteNote(noteName, userId, noteId);
            return $"Note {noteName} is successfully deleted.";         
        }

        public Note updateNoteByName(string title, string userId, string content)
        {

            string[] contentlist = content.Split(",");
            _context.updateNoteByName(title, userId, contentlist);
            return getNoteByTitle(title, userId);
        }

        public Note getNoteByTitle(string title, string userId)
        {
            return _context.getNoteByName(title, userId);
        }

    }
}
