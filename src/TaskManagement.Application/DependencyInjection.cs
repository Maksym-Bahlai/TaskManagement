using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

using TaskManagement.Application.Common.Behaviors;
using TaskManagement.Application.Mappings;

namespace TaskManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

           // options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        return services;
    }
}