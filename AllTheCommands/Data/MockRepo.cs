using AllTheCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllTheCommands.Data
{
    public class MockRepo : IRepo
    {
        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Check Test", Line = "Test", Platform = "Linux" };
        }

        public IEnumerable<Command> GettAllCommands()
        {
            return new List<Command> 
            {
                new Command {Id = 0, HowTo = "Check Test", Line = "Test", Platform = "Linux" },
                new Command {Id = 1, HowTo = "Code like a champ", Line = "code more", Platform = "Windows" },
                new Command {Id = 2, HowTo = "Boil an egg", Line = "boil water", Platform = "Pot" }
            };

        }
    }
}
