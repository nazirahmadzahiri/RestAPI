using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Data;
using RestAPI.Dtos;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    // api/commads
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();



        // GET Api/Commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        // GET Api/Commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

        // POST Api/Commands
        [HttpPost]
        public IActionResult CreateCommand([FromBody] CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);


            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.Id }, commandReadDto);

            //return Ok(commandReadDto);

        }
        //PUT api/Commands/{id}
        [HttpPut("{id}")]

        public IActionResult UpdateCommand(int id, CommandUpdateDto CommandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(CommandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //PATCH api/Commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            var commmandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commmandToPatch, ModelState );
            if(!TryValidateModel(commmandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commmandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        //DELETE api/Commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
