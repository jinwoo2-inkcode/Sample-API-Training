namespace training.Endpoints;

public static class RootEndPoints
{
    public static void AddRootEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World");
    }
}