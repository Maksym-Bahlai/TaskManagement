using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Users.Commands.CreateUser;
using TaskManagement.Application.Users.Queries;
using TaskManagement.Contracts.Users;

namespace TaskManagement.Api.Controllers;

[Route("users")]
public class UsersController(ISender _mediator, IMapper _mapper) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var command = new CreateUserCommand(request.UserName, request.FirstName, request.LastName, request.Email);

        var result = await _mediator.Send(command);

        return result.Match(
            user => CreatedAtAction(
                actionName: nameof(GetUser),
                routeValues: new { result.Value.UserName },
                value: _mapper.Map<UserResponse>(user)),
            Problem);
    }

    [HttpGet("{userName}")]
    public async Task<IActionResult> GetUser(string userName)
    {
        var query = new GetUserQuery(userName);

        var result = await _mediator.Send(query);

        return result.Match(
            user => Ok(_mapper.Map<UserResponse>(user)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var query = new GetUsersQuery();

        var result = await _mediator.Send(query);

        return result.Match(
            users => Ok(_mapper.Map<List<UserResponse>>(users)),
            Problem);
    }
}