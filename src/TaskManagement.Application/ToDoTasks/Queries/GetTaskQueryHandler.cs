using AutoMapper;

using ErrorOr;

using MediatR;

using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.ToDoTasks.Common;
using TaskManagement.Domain.ToDoTasks;

namespace TaskManagement.Application.ToDoTasks.Queries;

public class GetTaskQueryHandler(ITasksRepository _tasksRepository, IMapper _mapper)
    : IRequestHandler<GetTaskQuery, ErrorOr<ToDoTaskResult>>
{
    public async Task<ErrorOr<ToDoTaskResult>> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        return await _tasksRepository.GetByIdAsync(request.Id, cancellationToken) is { } task
            ? _mapper.Map<ToDoTaskResult>(task)
            : Error.NotFound(description: "Task not found.");
    }
}
