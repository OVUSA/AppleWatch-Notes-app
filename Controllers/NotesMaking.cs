using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AppleWatch_Notes_app.Models;
using AppleWatch_Notes_app.Services;

namespace AppleWatch_Notes_app.Controllers
{
    [ApiController]
    [Route("[notes]")]
    public class NotesMaking : ControllerBase
    {

        private readonly ILogger<NotesMaking> _logger;
        private NoteService noteService = new NoteService();

        public NotesMaking(ILogger<NotesMaking> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable <Note> Get(User userName)
        {
            return noteService.allUserNotes(userName.userId);


        }
        [HttpPost]
        public Note Post(string noteName, string? content, User userName)
        {
           return noteService.createNewNote(noteName,content,userName.userId );
        }

        [HttpDelete]
        public IActionResult  Delete(string noteName, User userName)
        {
            if(noteService.deleteNote(noteName, userName.userId))
            {
                return Ok("Note deleted successfully");
            }
            else
            {
                return NotFound($"The note with {noteName} wasn't found. Try again");
            }
            
        }
        [HttpPatch("{noteName}")]
        public Note Patch(string noteName, User userName)
        {
            return noteService.updateNoteByName(noteName,userName.userId);
        }

    }
}
