using GraphQLKursovayaa.DataAccess.Data;
using GraphQLKursovayaa.DataAccess.Entity;
using GraphQLKursovayaa.DataAccess.DAO;
using HotChocolate.Execution;
using HotChocolate.Execution.Processing;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddDbContext<SampleAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer().AddQueryType<Query>().
    AddMutationType<Mutation>().AddSubscriptionType<Subscription>().AddInMemorySubscriptions();
builder.Services.AddScoped<ActionRepository, ActionRepository>();
builder.Services.AddScoped<AdvokatRepository, AdvokatRepository>();
builder.Services.AddScoped<CaseRepository, CaseRepository>();
builder.Services.AddScoped<ClientRepository, ClientRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseWebSockets();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<SampleAppDbContext>();
    DataSeeder.SeedData(db);
}
app.MapGraphQL("/graphql");
app.Run();