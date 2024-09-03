using Microsoft.AspNetCore.Mvc;
using ShortestPathLibrary;
using ShortestPathLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<GraphBuilder>(); // Register GraphBuilder as Singleton
builder.Services.AddTransient<ShortestPathService>(); // Register ShortestPathService as Transient - Each request creates a new instance

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");

// Define the endpoint for calculating the shortest path
app.MapGet("/shortestpath", (string fromNodeName, string toNodeName, [FromServices] GraphBuilder graphBuilder, [FromServices] ShortestPathService shortestPathService) =>
{
    // Build the graph using the GraphBuilder
    var graph = GraphBuilder.BuildGraph(); // This is a static method, so call it on the class itself

    // Find the start and end nodes in the graph
    var fromNode = graph.FirstOrDefault(node => node.Name == fromNodeName);
    var toNode = graph.FirstOrDefault(node => node.Name == toNodeName);

    if (fromNode == null || toNode == null)
    {
        return Results.BadRequest("Invalid node names provided.");
    }

    // Calculate the shortest path using the service
    var shortestPathData = shortestPathService.CalculateShortestPath(fromNodeName, toNodeName, graph);

    // Return the result
    return Results.Ok(shortestPathData);
})
.WithName("GetShortestPath")
.WithOpenApi();

app.Run();