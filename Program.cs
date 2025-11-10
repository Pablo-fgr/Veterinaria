using Microsoft.EntityFrameworkCore;
using Veterinaria.DB;
using Veterinaria.Service;

var builder = WebApplication.CreateBuilder(args);

// --- INICIO: Reemplaza a ConfigureServices de Startup.cs ---

// 1. A?adir servicios al contenedor.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// 2. Configurar el DbContext con la cadena de conexi?n
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VeterinariaDBContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Registrar tus servicios personalizados
builder.Services.AddHttpClient(); // Para RenaperService
builder.Services.AddScoped<RenaperService>();
builder.Services.AddScoped < OwnerService > ();
builder.Services.AddScoped<MascotaService>();
builder.Services.AddScoped<AtencionService>();


// --- FIN: Reemplaza a ConfigureServices ---


var app = builder.Build();

// --- INICIO: Reemplaza a Configure de Startup.cs ---

// 1. Configurar el pipeline de peticiones HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days.
    app.UseHsts();
}

// 2. Middlewares
app.UseHttpsRedirection();
app.UseStaticFiles(); // Para que encuentre el CSS
app.UseRouting();

// 3. Endpoints de Blazor
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// --- FIN: Reemplaza a Configure ---

app.Run();
