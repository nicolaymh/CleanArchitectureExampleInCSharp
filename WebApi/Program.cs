using AccesoDatos.Repositorios; // Importa el espacio de nombres donde se encuentra ProductoRepository
using Dominio.Servicios.Interfaces; // Importa el espacio de nombres donde se encuentra la interfaz IProductoService

var builder = WebApplication.CreateBuilder(args); // Inicializa el generador de la aplicación web

// Add services to the container.
builder.Services.AddControllers(); // Agrega soporte para controladores MVC

// Configura Swagger/OpenAPI para la documentación de la API
builder.Services.AddEndpointsApiExplorer(); // Agrega el explorador de endpoints para Swagger/OpenAPI
builder.Services.AddSwaggerGen(); // Agrega la generación de documentación Swagger/OpenAPI

// Inyección de dependencias
// Registra IProductoService con su implementación ProductoRepository en el contenedor de servicios
builder.Services.AddScoped<IProductoService, ProductoRepository>();

var app = builder.Build(); // Construye la aplicación web

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Verifica si la aplicación se está ejecutando en un entorno de desarrollo
{
    app.UseSwagger(); // Habilita Swagger en el entorno de desarrollo
    app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger en el entorno de desarrollo
}

app.UseHttpsRedirection(); // Habilita la redirección de HTTP a HTTPS

app.UseAuthorization(); // Habilita la autorización

app.MapControllers(); // Mapea los controladores a las rutas de la aplicación

app.Run(); // Ejecuta la aplicación
