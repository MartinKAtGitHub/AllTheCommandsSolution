using AllTheCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllTheCommands.Data
{
    public interface IRepo
    {
        IEnumerable<Command> GettAllCommands();
        Command GetCommandById(int id);
    }
}
