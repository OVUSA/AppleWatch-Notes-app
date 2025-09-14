using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AppleWatch_Notes_app.Models;
using AppleWatch_Notes_app.Services;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
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
        [Authorize]
        [HttpPost]
        public Note Post(string noteTitle, [FromQuery] string? content, string userId)
        {
           return noteService.createNewNote(noteTitle,content,userId);
        }

        [Authorize]
        [HttpDelete]
        public string Delete(string noteTitle, string userId, string noteId)
        {
           return noteService.deleteNote(noteTitle, userId, noteId);
            
        }
        [Authorize]
        [HttpPatch("{noteName}")]
        public IActionResult Patch(string noteName, [FromQuery] string userId, [FromBody] string content, string? nodeId)
        {
            var updatedNote = noteService.updateNoteByName(noteName, userId, content, nodeId);
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
