var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();
var app = builder.Build();

app.MapGet("/", () => "Up and Running!");
app.MapGraphQL();
app.Run();
