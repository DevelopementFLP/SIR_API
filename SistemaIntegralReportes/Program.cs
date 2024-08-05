using GecosIntegrationBrokerService;
using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.Data;
using SistemaIntegralReportes.EntityModels;
using SistemaIntegralReportes.Interfaces;
using SistemaIntegralReportes.Servicios;

//Rodrigo
using SistemaIntegralReportes.Repositorio.DBContext;
using SistemaIntegralReportes.Repositorio.Automapper;
using SistemaIntegralReportes.Servicios.Contrato;
using SistemaIntegralReportes.Servicios.Implementacion;
using SistemaIntegralReportes.PruebaDeRepositorio.Implementacion;
using SistemaIntegralReportes.Repositorio.Contrato;


var builder = WebApplication.CreateBuilder(args);

var misOrigenes = "_misOrigenes";

builder.Services.AddCors(p => p.AddPolicy(name: misOrigenes, bldr =>
{
    bldr.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
}
));

builder.Services.AddDbContext<PerfilesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PerfilesDbContext") ?? throw new InvalidOperationException("Connection string 'PerfilesDbContext' not found.")));
builder.Services.AddDbContext<ReportesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReportesDbContext") ?? throw new InvalidOperationException("Connection string 'ReportesDbContext' not found.")));
builder.Services.AddDbContext<UsuariosDataModelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsuariosDataModelContext") ?? throw new InvalidOperationException("Connection string 'UsuariosDataModelContext' not found.")));
builder.Services.AddDbContext<SistemaIntegralReportesContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlTestConection")));
//Rodrigo
builder.Services.AddDbContext<DBcontexBD>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlTestConection")));


builder.Services.AddHttpClient("GecosService", client =>
{
    var baseUrl = builder.Configuration.GetConnectionString("GecosIntegrationService");
    client.BaseAddress = new Uri(baseUrl);
});

// AnimalFaenaService
builder.Services.AddScoped<HaciendaService, AnimalHaciendaService>();
builder.Services.AddHttpClient<AnimalHaciendaService>();

// LoteFaenasService
builder.Services.AddScoped<HaciendaService, LoteHaciendaService>();
builder.Services.AddHttpClient<LoteHaciendaService>();

// TipificacioFaenaService
builder.Services.AddScoped<HaciendaService, TipificacionHaciendaService>();
builder.Services.AddHttpClient<TipificacionHaciendaService>();

// SalidasProduccionService
builder.Services.AddScoped<ProduccionService, SalidaProduccionService>();
builder.Services.AddHttpClient<SalidaProduccionService>();

// ProductosCargaService
builder.Services.AddScoped<CargaService, ProductosCargaService>();
builder.Services.AddHttpClient<ProductosCargaService>();

// FaenaTipificacionChileService
builder.Services.AddScoped<FaenaService, FaenaTipificacionChileService>();
builder.Services.AddHttpClient<FaenaTipificacionChileService>();


// GecosIntegrationBrokerService
builder.Services.AddTransient<GecosIntegrationBrokerServiceClient>();

builder.Services.AddTransient<IEmailService, EmailService>();

// Add services to the container.
builder.Services.AddControllersWithViews();


//RODRIGO
//Implementacion de interfaz para usarla en el proyecto
builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Implementacion de interfaz para usarla en la API
builder.Services.AddScoped<IDispositivo, DispositivoServicio>();
builder.Services.AddScoped<IFormateoDispositivo, FormateoDispositivoServicio>();
builder.Services.AddScoped<ITipoDispositivo, TipoDispositivoServicio>();
builder.Services.AddScoped<IUbicacionesDispositivo, UbicacionesDispositivoServicio>();
builder.Services.AddScoped<IListaDeCajas, ListaDeCajasServicio>();



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
//app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseCors(misOrigenes);

app.MapControllers();

app.Run();
