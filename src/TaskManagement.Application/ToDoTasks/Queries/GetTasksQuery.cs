using ErrorOr;
using MediatR;
using TaskManagement.Application.ToDoTasks.Common;

namespace TaskManagement.Application.ToDoTasks.Queries;

public record GetTasksQuery() : IRequest<ErrorOr<List<ToDoTaskResult>>>;