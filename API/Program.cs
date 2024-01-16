using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//creazione del service per la gestione del DB (tramtie DbContext che è un'estensione di StoreContext), per farlo è necessario passare un parametro Options che contiene la stringa di connessione dichiarata dentro appsettings*.JS
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Si crea la repository pattern per la tabella prodotti
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* app.UseHttpsRedirection(); -> per ora inutile */
//aggiungiamo gestione dei services, con il metodo CreateScope riusciamo ad accedere agli scope (ambiti) creati all'inizio, i builder.services per intenderci
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
//proviamo a creare il DB se non già creato, inserendo anche i record tramite classe StoreContextSeed
try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "errore durante creazione migration");
}
//fine gestione dei services


app.MapControllers();

app.Run();
