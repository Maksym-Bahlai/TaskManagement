using AutoMapper;
using ErrorOr;
using MediatR;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.ToDoTasks.Common;
using TaskManagement.Domain.ToDoTasks;

namespace TaskManagement.Application.ToDoTasks.Commands.CreateTask;

public class CreateTaskCommandHandler(
    IUsersRepository _usersRepository,
    ITasksRepository _tasksRepository,
    IMapper _mapper) : IRequestHandler<CreateTaskCommand, ErrorOr<ToDoTaskResult>>
{
    public async Task<ErrorOr<ToDoTaskResult>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByUserNameAsync(request.UserName, cancellationToken);

        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        var task = new ToDoTask(
            Guid.NewGuid(),
            request.Description,
            TaskState.Waiting);

        await _tasksRepository.AddAsync(task, cancellationToken);

        user.AssignTask(task.Id);

        await _usersRepository.UpdateAsync(user, cancellationToken);

        return _mapper.Map<ToDoTaskResult>(task);
    }
}