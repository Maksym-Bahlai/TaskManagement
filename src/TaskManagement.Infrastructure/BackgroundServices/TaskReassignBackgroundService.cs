using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManagement.Domain.ToDoTasks;
using TaskManagement.Infrastructure.Common.Persistence;

namespace TaskManagement.Infrastructure.BackgroundServices;

public class TaskReassignBackgroundService(
    IServiceScopeFactory serviceScopeFactory) : IHostedService, IDisposable
{
    private readonly AppDbContext _dbContext = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
    private Timer _timer = null!;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(ReassignUser, null, TimeSpan.Zero, TimeSpan.FromMinutes(2));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    private async void ReassignUser(object? state)
    {
        var tasks = await _dbContext.Tasks.Include(t => t.User).Where(x => x.State != TaskState.Completed).ToListAsync();
        var users = await _dbContext.Users.ToListAsync();

        foreach (var task in tasks)
        {
            var availableUsers = users.Where(u => u.Id != task.UserId).ToList();

            if (availableUsers.Any())
            {
                var randomUser = availableUsers[new Random().Next(availableUsers.Count)];
                task.ReassignUser(randomUser.Id);
            }
            else
            {
                task.UnassignedUser();
            }
        }

        await _dbContext.SaveChangesAsync();
    }
}