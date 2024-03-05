using Microsoft.EntityFrameworkCore;

using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.ToDoTasks;
using TaskManagement.Infrastructure.Common.Persistence;

namespace TaskManagement.Infrastructure.Tasks.Persistence;

public class TasksRepository(AppDbContext _dbContext) : ITasksRepository
{
    public async Task AddAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(toDoTask, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<ToDoTask?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Tasks.FindAsync(id, cancellationToken);
    }

    public async Task<List<ToDoTask>?> GetAllAsync(CancellationToken cancellationToken)
    {
         return await _dbContext.Tasks.ToListAsync(cancellationToken);
    }

    public async Task RemoveAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        _dbContext.Remove(toDoTask);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(ToDoTask toDoTask, CancellationToken cancellationToken)
    {
        _dbContext.Update(toDoTask);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}