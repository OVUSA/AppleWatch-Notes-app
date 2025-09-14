using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Data
{
    public static class SqlQueries
    {

        public static readonly string CreateUserTable = @"
        CREATE TABLE IF NOT EXISTS Users (
            Id TEXT PRIMARY KEY,
            Name TEXT NOT NULL )";

        public static readonly string CreateNotesTable = @"
         CREATE TABLE IS NOT EXISTS Notes (
            id VARCHAR(10) PRIMARY KEY,
            Title TEXT NOT NULL,
            CONTENT TEXT
            CreatedAt TEXT NOT NULL,
            FOREIGN KEY (UserId) REFERENCES Users(Id))";

       public static readonly string populateData = @"
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


    }
}
