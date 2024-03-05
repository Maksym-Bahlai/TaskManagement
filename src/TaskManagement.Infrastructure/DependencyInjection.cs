using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Infrastructure.BackgroundServices;
using TaskManagement.Infrastructure.Common.Persistence;
using TaskManagement.Infrastructure.Tasks.Persistence;
using TaskManagement.Infrastructure.Users.Persistence;

namespace TaskManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddBackgroundServices(configuration)
            .AddPersistence();

        return services;
    }

    private static IServiceCollection AddBackgroundServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTaskReassigned();

        return services;
    }

    private static IServiceCollection AddTaskReassigned(
        this IServiceCollection services)
    {
        services.AddHostedService<TaskReassignBackgroundService>();
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source = TaskManagement.sqlite"));

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ITasksRepository, TasksRepository>();

        return services;
    }
}