using Microsoft.AspNetCore.Builder;

using TaskManagement.Infrastructure.Common.Middleware;

namespace TaskManagement.Infrastructure;

public static class RequestPipeline
{
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseMiddleware<EventualConsistencyMiddleware>();
        return app;
    }
}