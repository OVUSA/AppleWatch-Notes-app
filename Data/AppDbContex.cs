using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using Dapper;

namespace AppleWatch_Notes_app.Data
{
    public class AppDbContex
    {
        private readonly string connectionString = "Data Source=mydb.db;Version=3;";
        private SQLiteConnection connection;
        public AppDbContex()
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();

            try
            {
                connection.Execute(SqlQueries.populateData);
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                Console.WriteLine($"Population failed: {ex.Message}");
            }
        }

        public void deleteNote(string noteName, string userId, string noteId)
        {

            connection.Execute(
              "DELETE FROM Notes WHERE UserId = @UserId AND Title = @NoteName , id = @noteId",
               new { UserId = userId, NoteName = noteName, id = noteId }
            );
        }
        public void createNote(string userId, string? content, string noteName, string NoteId, string CreatedAt)
        {
           connection.Query<Note>(
             "INSERT INTO Notes(Id, Title, Content, UserId, CreatedAt) VALUES(@id, @Title, @Content, @UserId, @CreatedAt)",
              new { id = NoteId, Title = noteName,  Content = content, UserId = userId, CreatedAt = CreatedAt});
           
        }

        public List<Note> getAllNotes(string userId)
        {
            var notes = connection.Query<Note>(
            "SELECT * FROM Notes WHERE UserId = @UserId",
            new { UserId = userId }
            ).ToList();
            return notes;
        }
        public Note getNoteByName(string title, string userId)
        {
            var note = connection.Query<Note>(
          "SELECT * " +
          "From Notes WHERE Title = @Title AND UserId = @UserId",
          new { Title = title, UserId = userId }
                 ).FirstOrDefault(); 
            return note;
        }

        public void updateNoteByName(string title, string userId, string[] content)
        {
           
            string joinedContent = string.Join(",", content);

            connection.Execute(
                "UPDATE Notes SET Content = @JoinedContent WHERE Title = @Title AND UserId = @UserId",
                new { JoinedContent = joinedContent, Title = title, UserId = userId }
            );
        }
    }
}