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
        public IActionResult Get(User userName)
        {
            IEnumerable<Note> userNotes = noteService.allUserNotes(userName.userId);
            try
            {
                if (userNotes != null)
                {
                    return Ok(userNotes);
                }
                else
                {
                    return NotFound($"No notes with that name were found! Try again.");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An internal error occurred, contact administarator!");
            }

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
        public IActionResult Patch(string noteName, User userName)
        {
            var updatedNote = noteService.updateNoteByName(noteName, userName.userId);
            try
            {
                if (updatedNote != null)
                {
                    return Ok(updatedNote);
                }
                else
                {
                    return NotFound($"Weren't able to update {noteName}. Try again!");

                }
            }

            catch(Exception ex)
            {
                return StatusCode(500, "An internal error occurred while updating the note.");
            }
            
        }

    }
}
