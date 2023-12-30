using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios;
using AcademiaFS.ProyectoInventario.WebApi.Domain;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD;
using Farsiman.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
     builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerForFsIdentityServer(opt =>
{
    opt.Title = "Prueba";
    opt.Description = "Descripción";
    opt.Version = "v1.0";
});

builder.Services.AddFsAuthService(configureOptions =>
{
    configureOptions.Username = builder.Configuration.GetFromENV("Configurations:FsIdentityServer:Username");
    configureOptions.Password = builder.Configuration.GetFromENV("Configurations:FsIdentityServer:Password");
});


builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapProfile));

var connectionString = builder.Configuration.GetConnectionString("AcademiaFSInventario");
builder.Services.AddDbContext<InventarioHjdContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<UnitOfWordBuilder, UnitOfWordBuilder>();
builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<EmpleadoService>();
builder.Services.AddTransient<SalidasInventarioService>();
builder.Services.AddTransient<EstadoService>();
builder.Services.AddTransient<PerfileService>();
builder.Services.AddTransient<PerfilesPorPermisoService>();
builder.Services.AddTransient<PermisoService>();
builder.Services.AddTransient<ProductoService>();
builder.Services.AddTransient<ProductosLoteService>();
builder.Services.AddTransient<SucursalService>();
builder.Services.AddTransient<SalidasInventarioDetalleService>();




builder.Services.AddTransient<DomainService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithFsIdentityServer();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseFsAuthService();

app.MapControllers();
app.UseCors("AllowSpecificOrigin");

app.Run();
