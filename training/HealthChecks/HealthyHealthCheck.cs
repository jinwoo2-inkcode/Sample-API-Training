using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace training.HealthChecks;


public class HealthyHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, 
        CancellationToken cancellationToken = default)
    {

        //could check database connection, external service, cache, etc here
        return Task.FromResult(
            HealthCheckResult.Healthy("This is a test healthy service."));
    }
}
