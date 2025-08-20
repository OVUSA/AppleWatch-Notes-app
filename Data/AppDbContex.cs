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
                Id TEXT PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL )";
            string createNotesTable = @"
                CREATE TABLE IF NOT EXISTS Notes (
                Id TEXT PRIMARY KEY ,
                Title TEXT NOT NULL,
                Content TEXT,
                UserId INTEGER NOT NULL,
                CreatedAt TEXT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES Users(Id)
                )";


            string populateDate = @"
              INSERT INTO Users (Id, Name)
                VALUES 
                    (1, 'Michel'),
                    (2, 'Misha'),
                    (3, 'Lindsey'),
                    (4, 'Sean'),
                    (5, 'Jade'),
                    (6, 'Shawn');

             INSERT INTO Notes (Id, Title, Content, UserId, CreateAt)
                VALUES 
                    (1-01, 'Movies', 'Constantine,Shutter Island' 1,DateTime.Now),
                    (1-02, 'Authors', 'Edgar Allan Poe,Howard Phillips Lovecraft' 1,DateTime.Now),
                    (03, 'Restaurants', 'Tao,S Darling' 1,DateTime.Now),,
                    (5-01, 'Bars', 'Constantine,Shutter Island' 5,DateTime.Now),
                    (5-02, 'To-dos', 'Car wash, Call dentist' 5,DateTime.Now),
                    (4-01, 'Actors', 'CAl Pacino,SKeanu Reeve' 4, DateTime.Now),;";


            connection.Execute(createUserTable);
            connection.Execute(createNotesTable);
            connection.Execute(populateDate);

        }

        public void deleteNote(string noteName, string userId)
        {
            connection.Query($"DELETE From Notes Where UserId={userId} AND Title = {noteName}");
        }

        public Note createNote(string userId, string? content, string noteName, string NoteId)
        {
            var newNote = connection.Query<Note>(
                    "INSERT INTO Notes(Title, Content, UserId, CreatedAt) VALUES(@Title, @Content, @UserId, @CreatedAt)",
                    new { UserId = userId, Content = content, Title = noteName, id = NoteId, CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")});

            var createdNote = connection.Query<Note>(
                   "INSERT INTO Notes(Title, Content, UserId, CreatedAt) VALUES(@Title, @Content, @UserId, @CreatedAt)",
                   new { UserId = userId, Content = content, Title = noteName, id = NoteId, CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")});
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
        public Note getNoteByName(string title, string userId)
        {
            return (Note)connection.Query<Note>(
                $"Select * from Notes WHERE Title = {title} and UserId = {userId}");
        }

        public void updateNoteByName(string title, string userId, string content)
        {
            connection.Query<Note>($"Update Notes Set content = {content} Where title = {title} and userId = {userId}");
        }
    }
}