using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales
{
    public class SucursalService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly DomainService _domainService;

        public SucursalService(UnitOfWordBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
            // _domainService = domainService;
        }

        public Respuesta<List<ListarSucursalDto>> ListarSucursales()
        {
            var listado = (from sucursal in _unitOfWork.Repository<Sucursale>().AsQueryable()
                           where sucursal.Estado == true
                           select new ListarSucursalDto
                           {
                               SucursalId= sucursal.SucursalId,
                               Nombre= sucursal.Nombre,
                               Estado= sucursal.Estado,
                               UsuarioCreacion = sucursal.UsuarioCreacion

                           }).ToList();
            return Respuesta.Success(listado, Mensajes.PROCESO_EXITOSO, Codigos.Success);

        }


        public Respuesta<SucursalDto> AgregarSucursal(SucursalDto sucursalDtos)
        {
            try
            {
                var sucursal = _mapper.Map<Sucursale>(sucursalDtos);

                _unitOfWork.Repository<Sucursale>().Add(sucursal);
                _unitOfWork.SaveChanges();
                sucursalDtos.SucursalId = sucursal.SucursalId;

                return Respuesta.Success(_mapper.Map<SucursalDto>(sucursal), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<SucursalDto>(Mensajes.PROCESO_FALLIDO);
            }
        }


        public Respuesta<SucursalDto> EditarSucursal(SucursalDto producto)
        {

            try
            {
                var EditarProducto = _unitOfWork.Repository<Sucursale>().FirstOrDefault
                    (x => x.SucursalId == producto.SucursalId);

                if (producto != null)
                {

                    EditarProducto.Nombre = producto.Nombre;
                    EditarProducto.Estado = producto.Estado;
                    EditarProducto.UsuarioCreacion = 1;
                    EditarProducto.FechaModificacion = DateTime.Now;


                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<SucursalDto>(EditarProducto), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<SucursalDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
        public Respuesta<string> EliminarSucursal (int Id)
        {
            try
            {
                var EliminarProducto = _unitOfWork.Repository<Sucursale>().Where(x => x.SucursalId == Id).FirstOrDefault();

                EliminarProducto.Estado = false;

                _unitOfWork.SaveChanges();


                return Respuesta.Success<string>(Mensajes.PROCESO_EXITOSO, Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<string>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }



    }
}
