var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor
builder.Services.AddControllers(); // <- Asegúrate de que esto esté presente

// Agrega CORS u otros servicios necesarios
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configura la aplicación
app.UseCors("AllowLocalhost");
app.UseAuthorization();

// Mapear controladores
app.MapControllers(); // <- Asegúrate de que esto esté presente

app.Run();
