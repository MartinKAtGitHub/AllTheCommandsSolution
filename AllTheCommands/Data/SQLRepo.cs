using AllTheCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllTheCommands.Data
{
    public class SQLRepo : IRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public SQLRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Command> GettAllCommands()
        {
            return _dbContext.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _dbContext.Commands.FirstOrDefault(command => command.Id == id);
        }
    }
}
