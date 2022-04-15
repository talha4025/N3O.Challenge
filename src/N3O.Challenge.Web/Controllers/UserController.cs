using MediatR;
using Microsoft.AspNetCore.Mvc;
using N3O.Challenge.Domain.Commands;
using N3O.Challenge.Domain.Entities;
using N3O.Challenge.Domain.Models;
using N3O.Challenge.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace N3O.Challenge.Web.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user) {

            user.Id = new System.Guid();
            var result= await _mediator.Send(new CreateUserCommand(user.Id,user));
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() {

            var query = new GetAllUsersQuery();
            IEnumerable<UserResponseModel> result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id) {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id) {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutUser([FromBody] User user) {
            await _mediator.Send(new UpdateUserCommand(user.Id, user));
            return Ok();
        }
    }
}