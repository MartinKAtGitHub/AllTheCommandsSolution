using AllTheCommands.Data;
using AllTheCommands.Models;
using AllTheCommands.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper;

        public CommandsController(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/commands/ 
        [HttpGet]
        public ActionResult<IEnumerable<CommandsViewModel>> GetAllCommands()
        {
            var commandItems = _repo.GettAllCommands().ToList();

            return Ok(_mapper.Map<IEnumerable<CommandsViewModel>>(commandItems));
        }

        // GET api/commands/{id} 
        [HttpGet("{id}", Name = "GetCommand")]
        public ActionResult<IEnumerable<CommandsViewModel>> GetCommand(int id)
        {

            var item = _repo.GetCommandById(id);
            if (item != null)
            {
                // This is the power of AutoMapper. We don't have to map it our self
                return Ok(_mapper.Map<CommandsViewModel>(item));
            }

            return NotFound();
        }

        // POST api/commands/ 
        [HttpPost]
        public ActionResult<CommandsViewModel> CreateCommand(CommandCreateViewModel commandCreateViewModel)
        {
            var commanModel = _mapper.Map<Command>(commandCreateViewModel);

            // TODO if(ModelState.isValid)
            _repo.CreateCommand(commanModel);
            _repo.SaveChanges();

            var command = _mapper.Map<CommandsViewModel>(commanModel);

            //return Ok(command);
            return CreatedAtRoute(nameof(GetCommand), new { Id = command.Id }, command); // We do this to get (201 CREATED) and the URI in the Header. This respects REST principles more then just OK()
        }


        //PUT  api/commands/{id}
        [HttpPut("{id}")] // We update the whole model with this. Not optimal, use PATCH instead
        public ActionResult UpdateCommand(int id, CommandUpdateViewModel commandUpdateViewModel)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateViewModel, commandModelFromRepo);

            _repo.UpdateCommand(commandModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

        // PATCH  api/commands/{id} | need NugetPackages
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateViewModel> patchDoc)
        {

            /*
             The JSON need to follow JSON patch standards http://jsonpatch.com/.
            eks: Postman -> PATCH api/commands/{id}
            Raw | Body:
            [
                {
                    "op": "replace",
                    "path": "/howto",
                    "value": "NEW PATCH CHANGE"
                },

            {
                    "op": "replace",
                    "path": "/platform",
                    "value": "MacOS"
                }
            ]

             */


            var commandModelFromRepo = _repo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateViewModel>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repo.UpdateCommand(commandModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }


        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteCommand(commandModelFromRepo);
            _repo.SaveChanges();

            return NoContent();

        }


    }
}
