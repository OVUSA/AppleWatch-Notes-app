using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppleWatch_Notes_app.Models
{
    public class Note
    {
        public string Name { get; set; } = "Not Defined";
        public DateTime date { get; set; } = DateTime.Now;
        public string content { get; set; } = " ";

        private string SourceDevice { get; set; } = "Siri";

      
    }
}
