using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Note Get()
        {
            //return all notes


        }
        [HttpPost]
        public Note Post()
        {

        }
        [HttpDelete]
        public IEnumerable<string> Delete()
        {

        }
        [HttpPatch("{noteName}")]
        public Note Patch(string noteName) {

            return noteService.updateNoteByName(noteName);

        }

    }
}
