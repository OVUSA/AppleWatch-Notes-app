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

            string createUserTable = @"
                CREATE TABLE IF NOT EXISTS User (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL )";
            string createNotesTable = @"
                CREATE TABLE IF NOT EXISTS Notes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Content TEXT,
                UserId INTEGER NOT NULL,
                CreatedAt TEXT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES Users(Id)
                )";

            connection.Execute(createUserTable);
            connection.Execute(createNotesTable);

        }

        public void deleteNote(string noteName, string userId)
        {
            connection.Query($"DELETE From Notes Where UserId={userId} AND Title = {noteName}");
        }

        public Note createNote(string userId, string? content, string noteName, string NoteId)
        {

            var newNote = connection.Query<Note>(
                    "INSERT INTO Notes(Title, Content, UserId, CreatedAt) VALUES(@Title, @Content, @UserId, @CreatedAt)",
                    new { UserId = userId, Content = content,Title = noteName, id = NoteId, CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") }
                    );
            return (Note)newNote;

        }

        public List<Note> getAllNotes(string userId)
        {
            var notes = connection.Query<Note>(
            "SELECT * FROM Notes WHERE UserId = @UserId",
            new { UserId = userId }
            ).ToList();
            return notes;

        }
    }
}