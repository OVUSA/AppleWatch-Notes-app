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
        CREATE TABLE IF NOT EXISTS Users (
            Id TEXT PRIMARY KEY,
            Name TEXT NOT NULL )";

            string createNotesTable = @"
        CREATE TABLE IF NOT EXISTS Notes (
            Id TEXT PRIMARY KEY ,
            Title TEXT NOT NULL,
            Content TEXT,
            UserId TEXT NOT NULL, 
            CreatedAt TEXT NOT NULL,
            FOREIGN KEY (UserId) REFERENCES Users(Id)
            )";

            // Use a date format compatible with SQLite
            string populateData = @"
        INSERT INTO Users (Id, Name)
        VALUES
            ('001', 'Michel'),
            ('002', 'Misha'),
            ('003', 'Lindsey'),
            ('004', 'Sean');

        INSERT INTO Notes (Id, Title, Content, UserId, CreatedAt)
        VALUES
            ('1-01', 'Movies', 'Constantine,Shutter Island', '001', '2025-08-21 23:14:07'),
            ('1-02', 'Authors', 'Edgar Allan Poe,Howard Phillips Lovecraft', '002', '2025-08-21 23:14:07'),
            ('03', 'Restaurants', 'Tao,S Darling', '001', '2025-08-21 23:14:07'),
            ('5-01', 'Bars', 'Constantine,Shutter Island', '002', '2025-08-21 23:14:07'),
            ('5-02', 'To-dos', 'Car wash, Call dentist', '003', '2025-08-21 23:14:07'),
            ('4-01', 'Actors', 'Al Pacino,Keanu Reeves', '004', '2025-08-21 23:14:07');";

          //  connection.Execute(createUserTable);
         //   connection.Execute(createNotesTable);

            try
            {
               // connection.Execute(populateData);
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {

                Console.WriteLine($"Population failed: {ex.Message}");
            }
        }

        public void deleteNote(string noteName, string userId)
        {
            connection.Query($"DELETE From Notes Where UserId={userId} AND Title = {noteName}");
        }

        public void createNote(string userId, string? content, string noteName, string NoteId)
        {
            var newNote = connection.Query<Note>(
                    "INSERT INTO Notes(Title, Content, UserId, CreatedAt) VALUES(@Title, @Content, @UserId, @CreatedAt)",
                    new { UserId = userId, Content = content, Title = noteName, id = NoteId, CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")});

         //   var createdNote = connection.Query<Note>(
             //      "INSERT INTO Notes(Title, Content, UserId, CreatedAt) VALUES(@Title, @Content, @UserId, @CreatedAt)",
               //    new { UserId = userId, Content = content, Title = noteName, id = NoteId, CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")});
            
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
          "SELECT title AS Title, " +
          "createdAt as date, " +
          "content as content " +
          "From Notes WHERE Title = @Title AND UserId = @UserId",
          new { Title = title, UserId = userId }
                 ).FirstOrDefault(); 

            return note;
        }

        public void updateNoteByName(string title, string userId, string[] content)
        {
           
            string joinedContent = string.Join(",", content);

            //  Use a parameterized query with 'connection.Execute' for the update
            connection.Execute(
                "UPDATE Notes SET Content = @JoinedContent WHERE Title = @Title AND UserId = @UserId",
                new { JoinedContent = joinedContent, Title = title, UserId = userId }
            );
        }
    }
}