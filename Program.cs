using Backend_CruzRoja;
using Backend_CruzRoja.AppService;
using Backend_CruzRoja.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
// Asegúrate de tener el espacio de nombres correcto

var builder = WebApplication.CreateBuilder(args);

// Registrar los servicios
builder.Services.AddScoped(typeof(UsuariosAppService));
builder.Services.AddScoped(typeof(TipoMantenimientoAppService));
builder.Services.AddScoped(typeof(MarcaVehiculoAppService));
builder.Services.AddScoped(typeof(ModeloVehiculoAppService));
builder.Services.AddScoped(typeof(LatoneriaAppService));
builder.Services.AddScoped(typeof(MecanicaAppService));
builder.Services.AddScoped(typeof(VehiculoAppService));
builder.Services.AddScoped(typeof(EstadoUsuarioAppService));
builder.Services.AddScoped(typeof(EstadoConductoresAppService));
builder.Services.AddScoped(typeof(RolUsuarioAppService));
builder.Services.AddScoped(typeof(ConductorAppService));
builder.Services.AddScoped(typeof(CategoComprasYServiciosAppService));
builder.Services.AddScoped(typeof(HojadeVidaAppService));
builder.Services.AddScoped(typeof(SOAT_TECNO_AppService));
builder.Services.AddScoped(typeof(DetallePeriodicidadAppService));
builder.Services.AddScoped(typeof(MantenimientoAppService));
builder.Services.AddScoped(typeof(DashboardAppservice));
builder.Services.AddScoped(typeof(TipoRecorridoAppService));
builder.Services.AddScoped(typeof(TipoVehiculoAppService));
builder.Services.AddScoped(typeof(ProyectoAppService));
builder.Services.AddScoped(typeof(RegKilometrajeAppService));

//// Registrar la implementación del servicio de correo
//builder.Services.AddScoped<IEmailService, EmailService>();

// Configura la configuración del servicio de correo
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddControllers()
    .AddJsonOptions(opciones =>
    opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
    builder => builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       //.AllowCredentials()
                       .AllowAnyMethod()));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("name=con"));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configurar el middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebApp");

app.UseHttpsRedirection();
app.UseStaticFiles(); // Servir archivos estáticos

app.UseAuthorization();

app.MapControllers();

app.Run();
