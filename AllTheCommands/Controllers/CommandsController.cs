using AllTheCommands.Data;
using AllTheCommands.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllTheCommands.Controllers
{

    // NOTE we don't need to use Views, so i am going to use ControllerBase to make this more lean
    [Route("/api/commands")] // NOTE i hard code this, because even if i were to change the name of this controller in the future, i still want the old implementations to work so i avoid [controller]
    [ApiController]
    public class CommandsController : ControllerBase 
    {
        private readonly IRepo _repo;

        public CommandsController(IRepo repo)
        {
            _repo = repo;
        }
        // GET api/commands/ 
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repo.GettAllCommands().ToList();
            return Ok(commandItems); 
        }
        
        // GET api/commands/{id} 
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Command>> GetCommand(int id)
        {
            return Ok(_repo.GetCommandById(id));
        }


    }
}
