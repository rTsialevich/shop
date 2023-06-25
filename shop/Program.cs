using Application;
using Domain.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<WriteDbContext>(builder =>
{
    builder.UseSqlServer(configuration.GetConnectionString("WriteDatabase"));
});
builder.Services.AddDbContext<ReadDbContext>(builder =>
{
    builder.UseSqlServer(configuration.GetConnectionString("ReadDatabase"));
});

builder.Services.AddScoped<IWriteDbContext, WriteDbContext>();
builder.Services.AddScoped<IReadDbContext, ReadDbContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationClass).Assembly));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var writeDbContext = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
    writeDbContext.Database.Migrate();

    var readDbContext = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
    readDbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
