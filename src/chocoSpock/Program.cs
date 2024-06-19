using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

var conStrBuilder = new SqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("trekDB"));

conStrBuilder.Password = builder.Configuration["SA_PWD"];

        
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();
var app = builder.Build();

app.Configuration["ConnectionStrings:trekDB"] = conStrBuilder.ConnectionString;;
app.MapGet("/", () => "Up and Running!");
app.MapGraphQL();
app.Run();
