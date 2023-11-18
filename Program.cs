using Microsoft.EntityFrameworkCore;
using prova.Data;
using prova.Repositorio;
using prova.Repositorio.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(x => x.UseSqlServer("Data Source=DEV125268N;Initial Catalog=Alunos;User ID=sa;Password=abcd.1234;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

builder.Services.AddScoped<IAluno, RepositorioAluno>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());

app.MapControllers();

app.Run();
