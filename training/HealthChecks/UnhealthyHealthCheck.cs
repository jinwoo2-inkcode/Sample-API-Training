using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace training.HealthChecks
{
    public class UnhealthyHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            //could check database connection, external service, cache, etc here
            return Task.FromResult(
                HealthCheckResult.Unhealthy("This is a test unhealthy service."));
        }
    }
}
