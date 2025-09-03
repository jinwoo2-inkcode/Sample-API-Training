using System.Reflection.Metadata.Ecma335;

namespace training.Endpoints;

public static class ErrorEndPoints
{
    public static void AddErrorEndpoints(this WebApplication app)
    {
        app.MapGet("/error/{code}", (int code) => 
        {
            return code switch
            {
                500 => Results.Problem("An unexpected error occurred.", statusCode: 500),
                404 => Results.NotFound("The resource was not found."),
                400 => Results.BadRequest("The request was invalid."),
                401 => Results.Unauthorized(),
                403 => Results.Forbid(),
                _ => Results.StatusCode(code)
            };
        });
    }
}

