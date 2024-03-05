using ErrorOr;
using MediatR;
using TaskManagement.Application.ToDoTasks.Common;

namespace TaskManagement.Application.ToDoTasks.Queries;

public record GetTaskQuery(Guid Id) : IRequest<ErrorOr<ToDoTaskResult>>;