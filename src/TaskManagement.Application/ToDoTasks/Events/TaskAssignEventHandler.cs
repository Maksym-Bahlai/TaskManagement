using MediatR;

using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.Users.Events;

using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Application.ToDoTasks.Events;

public class TaskAssignEventHandler(ITasksRepository _tasksRepository) : INotificationHandler<TaskAssignEvent>
{
    public async Task Handle(TaskAssignEvent @event, CancellationToken cancellationToken)
    {
        var task = await _tasksRepository.GetByIdAsync(@event.TaskId, cancellationToken)
                       ?? throw new InvalidOperationException();

        task.AssignUser(@event.UserId);

        await _tasksRepository.UpdateAsync(task, cancellationToken);
    }
}