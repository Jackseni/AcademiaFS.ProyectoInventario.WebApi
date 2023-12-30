
using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Domain;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios
{
    public class SalidasInventarioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DomainService _domainService;

        public SalidasInventarioService(UnitOfWordBuilder unitOfWork, IMapper mapper, DomainService validacionesDomain)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
            _domainService = validacionesDomain;
        }

        public decimal ObtenerCostoProducto(int? idLote)
        {
            var productoLoteObtenido = _unitOfWork.Repository<ProductosLote>().FirstOrDefault(lote => lote.LoteId == idLote);
            if (productoLoteObtenido != null)
            {
                decimal costo = productoLoteObtenido.Costo;
                return costo;
            }
            return 0;
        }

        public bool EsJefeDeBodega(int idUsuario)
        {
            bool esJefe = false;
            var usuarios = _unitOfWork.Repository<Usuario>().AsQueryable();
            var perfiles = _unitOfWork.Repository<Perfile>().AsQueryable();
            var perfil = (from p in perfiles
                          join user in usuarios on p.PerfilId equals user.PerfilId
                          where user.UsuarioId == idUsuario
                          select p.Nombre).FirstOrDefault();
            if (perfil.Equals(Perfile.JEFE_DE_BODEGA))
            {
                esJefe = true;
            }
            return esJefe;
        }

        public Respuesta<ListarSalidasInventarioDto> InsertarSalidaInventario(ListarSalidasInventarioDto salidasInventarioDto)
        {

            try
            {
                if (salidasInventarioDto.Estado)
                {
                    if (!_domainService.SucursalExiste(salidasInventarioDto.SucursalId))
                        return Respuesta.Fault<ListarSalidasInventarioDto>(Mensajes.NO_EXISTE("Sucursal"), Codigos.Error);


                    if (_domainService.CantidadTotal())
                        return Respuesta.Fault<ListarSalidasInventarioDto>(Mensajes.CANTIDAD_MAYOR("Cantidad"), Codigos.Error);

                    decimal costoTotal = 0;
                    decimal costoProducto = 0;


                    SalidasInventario salidasInventario = new SalidasInventario() {

                        Estado = true,
                        SucursalId = salidasInventarioDto.SucursalId,
                        UsuarioId = salidasInventarioDto.UsuarioId,
                        FechaSalida = salidasInventarioDto.FechaSalida,
                        Total = costoTotal,
                       FechaRecibido= salidasInventarioDto.FechaRecibido,
                       EstadoId = salidasInventarioDto.EstadoId,
                       UsuarioCreacion= salidasInventarioDto.UsuarioCreacion,
                       FechaCreacion = salidasInventarioDto.FechaCreacion

                   };

                    salidasInventario.UsuarioCreacion = 1;
                    salidasInventario.FechaCreacion = DateTime.Now;

                    foreach (var item in salidasInventario.Usuarios)
                    {
                        if (!EsJefeDeBodega(item.UsuarioId))
                            return Respuesta.Fault<ListarSalidasInventarioDto>(Mensajes.NO_EXISTE("Usuario"), Codigos.Error);

                    }

                    _unitOfWork.Repository<SalidasInventario>().Add(salidasInventario);
                    _unitOfWork.SaveChanges();

                    foreach (var detalle in salidasInventarioDto.SalidasInventarioDetalles)
                    {
                        SalidasInventarioDetalle salidadetalle = new SalidasInventarioDetalle()
                        {
                            SalidaInventarioId = detalle.SalidaInventarioId,
                            LoteId = detalle.LoteId,
                            CantidadProducto = detalle.CantidadProducto,
                            UsuarioCreacion= detalle.UsuarioCreacion,
                            FechaCreacion = detalle.FechaCreacion

                        };

                        costoProducto = ObtenerCostoProducto(detalle.LoteId);
                        costoTotal += (salidadetalle.CantidadProducto * costoProducto);
                    }

                    salidasInventario.Total = costoTotal;

                    _unitOfWork.Repository<SalidasInventario>().Update(salidasInventario);
                    _unitOfWork.SaveChanges();

                    return Respuesta<ListarSalidasInventarioDto>.Success(salidasInventarioDto, Mensajes.PROCESO_EXITOSO, Codigos.Success);
                }
                else
                {
                    return Respuesta.Fault<ListarSalidasInventarioDto>("Sólo Los Jefe de Bodega pueden listar ", Codigos.Success);
                }
            }
            catch (Exception ex)
            {
                return _domainService.ValidacionCambiosBase<ListarSalidasInventarioDto>(ex);
            }
        }


        public Respuesta<List<InventarioReporteRangoFechaDto>> ReporteInventario(DateTime fechaInicio, DateTime fechaFinal)
        {
           
                var listado = (from salida in _unitOfWork.Repository<SalidasInventario>().AsQueryable()
                               where salida.FechaSalida.Date >= fechaInicio.Date && salida.FechaSalida.Date <= fechaFinal.Date
                               select new InventarioReporteRangoFechaDto
                               {
                                   SalidaInventarioId = salida.SalidaInventarioId,
                                   SucursalId = salida.SucursalId,
                                   EstadoId = salida.EstadoId,
                                   FechaSalida = salida.FechaSalida,
                                   Total = salida.Total,
                                   UsuarioId = salida.UsuarioId,

                               }).ToList();

                return Respuesta.Success(listado, Mensajes.PROCESO_EXITOSO, Codigos.Success);

        }


        public Respuesta<List<ListarSalidasInventarioDto>> ReporteInventarioPorId(int IdSucursal)
        {

            var listado = (from sucur in _unitOfWork.Repository<SalidasInventario>().AsQueryable()
                           where sucur.SucursalId == IdSucursal
                           select new ListarSalidasInventarioDto
                           {
                               
                               SucursalId = sucur.SucursalId,
                               EstadoId = sucur.EstadoId,
                               FechaSalida = sucur.FechaSalida,
                               Total = sucur.Total,
                               UsuarioId = sucur.UsuarioId

                           }).ToList();

            return Respuesta.Success(listado, Mensajes.PROCESO_EXITOSO, Codigos.Success);

        }

        public Respuesta<SalidasInventarioDto> AgregarSalidaInventario(SalidasInventarioDto salidainventarioDtos)
        {
            try
            {
                var salidasInventarios = _mapper.Map<SalidasInventario>(salidainventarioDtos);

                _unitOfWork.Repository<SalidasInventario>().Add(salidasInventarios);
                _unitOfWork.SaveChanges();
                salidainventarioDtos.SalidaInventarioId = salidasInventarios.SalidaInventarioId;

                return Respuesta.Success(_mapper.Map<SalidasInventarioDto>(salidasInventarios), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<SalidasInventarioDto>(Mensajes.PROCESO_FALLIDO);
            }
        }
        public Respuesta<SalidasInventarioDto> EditarSalidaInventario(SalidasInventarioDto salidaInventario)
        {

            try
            {
                var EditarInventario = _unitOfWork.Repository<SalidasInventario>().FirstOrDefault
                    (x => x.SalidaInventarioId == salidaInventario.SalidaInventarioId);

                if (salidaInventario != null)
                {

                    EditarInventario.SalidaInventarioId = salidaInventario.SalidaInventarioId;
                    EditarInventario.SucursalId = salidaInventario.SucursalId;
                    EditarInventario.UsuarioId = salidaInventario.UsuarioId;
                    EditarInventario.FechaSalida = salidaInventario.FechaSalida;
                    EditarInventario.Total = salidaInventario.Total;
                    EditarInventario.FechaRecibido = salidaInventario.FechaRecibido;
                    EditarInventario.UsuarioIdRecibe = salidaInventario.UsuarioIdRecibe;
                    EditarInventario.EstadoId=salidaInventario.EstadoId;
                    EditarInventario.Estado = salidaInventario.Estado;
                    EditarInventario.UsuarioCreacion = 1;
                    EditarInventario.FechaModificacion = DateTime.Now;


                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success(_mapper.Map<SalidasInventarioDto>(EditarInventario), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<SalidasInventarioDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
        public Respuesta<string> EliminarSalidaInventario(int Id)
        {
            try
            {
                var EliminarSalidasInventario = _unitOfWork.Repository<SalidasInventarioDto>().Where(x => x.SalidaInventarioId == Id).FirstOrDefault();

                EliminarSalidasInventario.Estado = false;

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
