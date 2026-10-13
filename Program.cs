using ApiEmpresa.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();  
builder.Services.AddOpenApi();

var connectionString =
    builder.Configuration.GetConnectionString("ConexionMySQL")
    ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'ConexionMySQL'.");

builder.Services.AddDbContext<Conexiones>(opt => opt.UseMySQL(connectionString));

builder.Services.AddHsts(o =>
{
    o.MaxAge = builder.Environment.IsDevelopment() ? TimeSpan.FromMinutes(1) : TimeSpan.FromDays(365);
    o.ExcludedHosts.Clear();   
});

var app = builder.Build();


app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        var h = context.Response.Headers;
        h["X-Content-Type-Options"] = "nosniff";
        h["Cache-Control"] = "no-cache, no-store, must-revalidate";
        h["Pragma"] = "no-cache";
        return Task.CompletedTask;
    });
    await next();
});


app.UseExceptionHandler();


if (!app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("EnableHstsForScan"))
{
    app.UseHsts();
}

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();
