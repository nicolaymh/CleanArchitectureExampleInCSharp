using AccesoDatos.Repositorios; // Importa el espacio de nombres donde se encuentra ProductoRepository
using Dominio.Servicios.Interfaces; // Importa el espacio de nombres donde se encuentra la interfaz IProductoService

var builder = WebApplication.CreateBuilder(args); // Inicializa el generador de la aplicaci�n web

// Add services to the container.
builder.Services.AddControllers(); // Agrega soporte para controladores MVC

// Configura Swagger/OpenAPI para la documentaci�n de la API
builder.Services.AddEndpointsApiExplorer(); // Agrega el explorador de endpoints para Swagger/OpenAPI
builder.Services.AddSwaggerGen(); // Agrega la generaci�n de documentaci�n Swagger/OpenAPI

// Inyecci�n de dependencias
// Registra IProductoService con su implementaci�n ProductoRepository en el contenedor de servicios
builder.Services.AddScoped<IProductoService, ProductoRepository>();

var app = builder.Build(); // Construye la aplicaci�n web

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Verifica si la aplicaci�n se est� ejecutando en un entorno de desarrollo
{
    app.UseSwagger(); // Habilita Swagger en el entorno de desarrollo
    app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger en el entorno de desarrollo
}

app.UseHttpsRedirection(); // Habilita la redirecci�n de HTTP a HTTPS

app.UseAuthorization(); // Habilita la autorizaci�n

app.MapControllers(); // Mapea los controladores a las rutas de la aplicaci�n

app.Run(); // Ejecuta la aplicaci�n
