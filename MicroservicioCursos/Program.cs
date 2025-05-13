using MicroservicioCursos.Data;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Cargar configuración
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>(); // opcional si usas user-secrets en local

// Obtener URI del Key Vault
var keyVaultEndpoint = builder.Configuration["KeyVault:Endpoint"];
if (string.IsNullOrWhiteSpace(keyVaultEndpoint))
    throw new InvalidOperationException("❌ FALTA la variable KeyVault__Endpoint.");

var keyVaultUri = new Uri(keyVaultEndpoint);

// Cargar configuración desde Key Vault
builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());

// 💡 Leer la cadena como connection string
var connectionString = builder.Configuration.GetConnectionString("CursosDB");

// 🔍 Solo para depurar:
Console.WriteLine($"🔎 CONEXIÓN: {connectionString}");
if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("❌ La cadena de conexión CursosDB es null o vacía.");

// Configurar EF
builder.Services.AddDbContext<CursosDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
