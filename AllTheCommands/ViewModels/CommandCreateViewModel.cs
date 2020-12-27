using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllTheCommands.ViewModels
{
    public class CommandCreateViewModel
    {
        [Required]
        [MaxLength(600)]
        public string HowTo { get; set; }

        /// <summary>
        /// Holds the syntax for the command 
        /// </summary>
        [Required]
        [MaxLength(300)]
        public string Line { get; set; }

        [Required]
        [MaxLength(300)]
        public string Platform { get; set; }
    }
}
