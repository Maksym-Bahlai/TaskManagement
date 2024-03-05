using TaskManagement.Domain.ToDoTasks;

namespace TaskManagement.Application.Common.Interfaces;

public interface ITasksRepository
{
    Task<ToDoTask?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<ToDoTask>?> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(ToDoTask toDoTask, CancellationToken cancellationToken);
    Task RemoveAsync(ToDoTask toDoTask, CancellationToken cancellationToken);
    Task UpdateAsync(ToDoTask toDoTask, CancellationToken cancellationToken);
}