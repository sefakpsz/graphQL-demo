using System.Data;
using GraphQL.Server.Ui.Voyager;
using GraphQLDemo.Data;
using GraphQLDemo.GraphQL;
using GraphQLDemo.GraphQL.Platforms;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<AppDbContext>(opt =>
//     opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr"))
// );

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr"))
);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseWebSockets();

app.UseRouting();

app.MapGraphQL();

app.UseGraphQLVoyager(
    path: "/graphql-voyager",
    options: new VoyagerOptions()
    {
        GraphQLEndPoint = "/graphql"
    });

app.Run();
