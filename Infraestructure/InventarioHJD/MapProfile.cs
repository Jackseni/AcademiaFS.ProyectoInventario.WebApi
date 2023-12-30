using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using AutoMapper;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SalidasInventario, SalidasInventarioDto>().ReverseMap();
            //CreateMap<ListarSalidasInventarioDto,SalidasInventario>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Perfile, PerfileDto>().ReverseMap();

            CreateMap<PerfilesPorPermiso, PerfilesPorPermisoDto>().ReverseMap();
            CreateMap<Permiso, PermisoDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<ProductosLote, ProductosLoteDto>().ReverseMap();
            CreateMap<SalidasInventarioDetalle, SalidasInventarioDetalleDto>().ReverseMap();
            CreateMap<Sucursale, SucursalDto>().ReverseMap();



        }
         
    }
}
