using Scalar.AspNetCore;
using training.Endpoints;
using training.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();
app.UseHttpsRedirection();

app.ApplyCorsConfig();

app.MapAllHealthChecks();
app.AddRootEndpoints();
app.AddCourseEndpoints();

app.Run();
