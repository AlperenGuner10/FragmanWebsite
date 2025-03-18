using MovieMVC.Models;
using MovieMVC.Repostiories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Generic Repository yap�land�rmas�
builder.Services.AddScoped(typeof(GenericRepository<>));

// Di�er hizmetler
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger yap�land�rmas�
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1");
		c.RoutePrefix = string.Empty; // Swagger UI'yi ana dizine yerle�tirir
	});
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
