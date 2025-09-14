using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Models
{
    public class Note
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        
        //private string SourceDevice { get; set; } = "Siri";

      
    }
}
