namespace training.Startup;

using System.Runtime.CompilerServices;
using training.Data;

public static class DependenciesConfig
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApiServices();
        builder.Services.AddCorsServices();
        builder.Services.AddAllHealthChecks();

        builder.Services.AddTransient<CourseData>();
    }
}