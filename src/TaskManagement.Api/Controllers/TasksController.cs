using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.ToDoTasks.Commands.CreateTask;
using TaskManagement.Application.ToDoTasks.Queries;
using TaskManagement.Contracts.Tasks;

namespace TaskManagement.Api.Controllers;

[Route("tasks")]
public class TasksController(ISender _mediator, IMapper _mapper) : ApiController
{
    [HttpPost("{userName}")]
    public async Task<IActionResult> CreateTask(string description, string userName)
    {
        var command = new CreateTaskCommand(description, userName);

        var result = await _mediator.Send(command);

        return result.Match(
            task => CreatedAtAction(
                actionName: nameof(GetTask),
                routeValues: new { TaskId = result.Value.Id },
                value: _mapper.Map<ToDoTaskResponse>(task)),
            Problem);
    }

    [HttpGet("{taskId:guid}")]
    public async Task<IActionResult> GetTask(Guid taskId)
    {
        var query = new GetTaskQuery(taskId);

        var result = await _mediator.Send(query);

        return result.Match(
            task => Ok(_mapper.Map<ToDoTaskResponse>(task)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var query = new GetTasksQuery();

        var result = await _mediator.Send(query);

        return result.Match(
            tasks => Ok(_mapper.Map<List<ToDoTaskResponse>>(tasks)),
            Problem);
    }
}