using AssessmentSystemCore.Application.Commands;
using AssessmentSystemCore.Application.Queries;
using AssessmentSystemCore.Application.Requests;
using AssessmentSystemCore.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AssessmentSystemCore.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IWriteRepository _writeRepository;
        private IReadRepository _readRepository;

        public UserController(IWriteRepository repository, IReadRepository readRepository)
        {
            _writeRepository = repository;
            _readRepository = readRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddUserRequest request)
        {
            var cmd = new AddUserCommand(_writeRepository);

            var response = cmd.Handle(request);

            return StatusCode(201, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var query = new GetUserByIdQuery(_readRepository);

            var request = new GetUserByIdRequest() { Id = id };

            var response = query.Handle(request);

            return response.IsSucess ? Ok(response) : NotFound(new { errors = response.Errors });
        }

        [HttpGet()]
        public IActionResult Get([FromQuery] GetUserRequest request)
        {
            var query = new GetUserQuery(_readRepository);

            var response = query.Handle(request);

            return Ok(response);
        }

        [HttpPut("id")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
        {
            request.SetId(id);

            var cmd = new UpdateUserCommand(_writeRepository);
            
            var response = cmd.Handle(request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveById([FromRoute] Guid id)
        {
            var request = new RemoveUserRequest() { Id = id };

            var cmd = new RemoveUserCommand(_writeRepository);

            var response = cmd.Handle(request);

            return Ok();
        }
    }
}
