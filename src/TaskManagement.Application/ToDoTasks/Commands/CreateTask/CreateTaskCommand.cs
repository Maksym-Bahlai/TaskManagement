using ErrorOr;
using MediatR;
using TaskManagement.Application.ToDoTasks.Common;

namespace TaskManagement.Application.ToDoTasks.Commands.CreateTask;

public record CreateTaskCommand(string Description, string UserName) : IRequest<ErrorOr<ToDoTaskResult>>;