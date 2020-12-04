using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllTheCommands.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
       /// <summary>
       /// Holds the syntax for the command 
       /// </summary>
        public string Line { get; set; }
        public string Platform { get; set; }
    }
}
