namespace training.Startup;

using global::HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using training.HealthChecks;
public static class HealthChecksConfig
{
    public static void AddAllHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<HealthyHealthCheck>("Healthy", tags: ["healthy"])
            .AddCheck<DegradedHealthCheck>("Degraded", tags: ["degraded"])
            .AddCheck<UnhealthyHealthCheck>("Unhealthy", tags: ["unhealthy"])
            .AddCheck<RandomHealthCheck>("Random", tags: ["random"]);
    }

    public static void MapAllHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");
        app.MapHealthChecks("/health/healthy", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("healthy")
        });
        app.MapHealthChecks("/health/degraded", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("degraded")
        });
        app.MapHealthChecks("/health/unhealthy", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("unhealthy")
        });
        app.MapHealthChecks("/health/random", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("random")
        });

        app.MapHealthChecks("/health/ui", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/ui/healthy", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("healthy"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/ui/degraded", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("degraded"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/ui/unhealthy", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("unhealthy"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/ui/random", new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("random"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}
