using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AppleWatch_Notes_app.Models;
using AppleWatch_Notes_app.Services;

namespace AppleWatch_Notes_app.Controllers
{
    [ApiController]
    [Route("notes")]
    public class NotesMaking : ControllerBase
    {

        private readonly ILogger<NotesMaking> _logger;
        private readonly INoteService noteService;

        public NotesMaking(ILogger<NotesMaking> logger)
        {
            _logger = logger;
           noteService = new NoteService();
        }

        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            IEnumerable<Note> userNotes = noteService.allUserNotes(userId);
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
        public Note Post(string noteName, string? content, [FromQuery]string userName)
        {
           return noteService.createNewNote(noteName,content,userName );
        }

        [HttpDelete]
        public string Delete(string noteName, string userName)
        {
           return noteService.deleteNote(noteName, userName);
            
        }
        [HttpPatch("{noteName}")]
        public IActionResult Patch(string noteName, [FromQuery] string userId, [FromBody] string content)
        {
            var updatedNote = noteService.updateNoteByName(noteName, userId, content);
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
