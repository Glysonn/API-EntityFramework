using AulaEntityFramework.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// armazenando a connection string (configurada no app settings) nessa variável
var connectionStringMysql = builder.Configuration.GetConnectionString("ConexaoPadrao");
// configurando o banco MYSQL
builder.Services.AddDbContext<AgendaContext>(
    options => options.UseMySql(
        connectionStringMysql,
        ServerVersion.Parse("8.0.31-Oubuntu0.22.04.1")
    )
);



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
