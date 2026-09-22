using netwise_recruitment_task.Clients.Implementations;
using netwise_recruitment_task.Clients.Interfaces;
using netwise_recruitment_task.Repositories.Implementations;
using netwise_recruitment_task.Repositories.Interfaces;
using netwise_recruitment_task.Services.Implementations;
using netwise_recruitment_task.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient<ICatClient, NetwiseCatClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CatApiSettings:BaseAddress"] ?? throw new InvalidOperationException("Base address is not set."));
});

builder.Services.AddScoped<ICatService, NetwiseCatService>();
builder.Services.AddScoped<ICatRepository, NetwiseCatFileRepository>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();