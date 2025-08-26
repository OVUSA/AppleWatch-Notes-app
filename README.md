## Apple Watch Notes API

This is a C# .NET API designed to manage notes for an Apple Watch application. It provides standard CRUD (Create, Read, Update, Delete) operations for notes and uses a lightweight SQLite database for data storage

Features:
- Create: Add new notes to the database.
- Get: Retrieve a single note by it’s id or a list of all use notes.
- Update: Modify an existing note. 
- Delete: Remove a note from the database.
- Data Persistence: Uses a local SQLite database.

### API Endpoints
+ GET `/notes/{userId}`: Retrieves all notes.
+	PATCH `/notes/{noteTitle}`: Updates an existing note by ID.
+ PATCH Request body:
  `{
  "noteTitle": string,
  "content": string,
  "userId": string,
 	"nodeId": string,
	}`,
+ POST `/notes`: Creates a new note.
+ POST Request body:
  `{
  "noteTitle": string,
  "content": string,
  "userId": string,
	}`,
+	DELETE `/notes/{userId}/{noteId}`: Deletes a note by ID.

**Database**: The API uses a SQLite database. The database file (notes.db) will be created automatically in the project's data directory on the first run. 

### Prerequisites
- .NET SDK 8
- Visual Studio
-	NuGet Package Manager


