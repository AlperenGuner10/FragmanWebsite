using MovieMVC.Models;
using MovieMVC.Repostiories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Generic Repository yapýlandýrmasý
builder.Services.AddScoped(typeof(GenericRepository<>));

// Diðer hizmetler
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger yapýlandýrmasý
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1");
		c.RoutePrefix = string.Empty; // Swagger UI'yi ana dizine yerleþtirir
	});
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
