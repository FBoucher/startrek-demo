using System.Data.SqlClient;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

var conStrBuilder = new SqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("trekDB"));

conStrBuilder.Password = builder.Configuration["SA_PWD"];

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .SetIsOriginAllowed(origin => true);
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .SetIsOriginAllowed(origin => true);
                      });
});


builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();
var app = builder.Build();

app.Configuration["ConnectionStrings:trekDB"] = conStrBuilder.ConnectionString;;
app.MapGet("/", () => "Up and Running!");
app.MapGraphQL();
app.UseCors(MyAllowSpecificOrigins);
app.Run();
