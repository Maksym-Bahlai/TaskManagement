using AutoMapper;

using ErrorOr;

using MediatR;

using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.ToDoTasks.Common;
using TaskManagement.Domain.ToDoTasks;

namespace TaskManagement.Application.ToDoTasks.Queries;

public class GetTasksQueryHandler(ITasksRepository _tasksRepository, IMapper _mapper)
    : IRequestHandler<GetTasksQuery, ErrorOr<List<ToDoTaskResult>>>
{
    public async Task<ErrorOr<List<ToDoTaskResult>>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        return await _tasksRepository.GetAllAsync(cancellationToken) is List<ToDoTask> tasks && tasks.Any()
            ? _mapper.Map<List<ToDoTaskResult>>(tasks)
            : Error.NotFound(description: "Tasks not found.");
    }
}
