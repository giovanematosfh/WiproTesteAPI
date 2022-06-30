using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Wipro.Fila.Domain.Repository;
using Wipro.Fila.Infra.Contexts;
using Wipro.Fila.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer("Server=localhost;Database=CursoMVC;UID=teste;PWD=12345678;Trusted_Connection=True;MultipleActiveResultSets=True;"));
builder.Services.AddTransient<IItemFileRpository, ItemFilaRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
