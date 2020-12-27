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

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() >= 0;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _dbContext.Commands.Add(cmd);
        }

        public void UpdateCommand(Command cmd)
        {
            // Nothing
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _dbContext.Commands.Remove(cmd);
        }
    }
}
