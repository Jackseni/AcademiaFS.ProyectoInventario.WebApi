using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles
{
    public class SalidasInventarioDetalleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly DomainService _domainService;

        public SalidasInventarioDetalleService(UnitOfWordBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
            // _domainService = domainService;
        }

        public Respuesta<List<ListarSalidasInventarioDetalleDto>> ListarSalidasInventarioDetalle()
        {
            var listado = (from salidInventario in _unitOfWork.Repository<SalidasInventarioDetalle>().AsQueryable()
                           where salidInventario.Estado == true
                           select new ListarSalidasInventarioDetalleDto
                           {
                               SalidaInventarioId= salidInventario.SalidaInventarioId,
                               DetalleId=salidInventario.DetalleId,
                               CantidadProducto=salidInventario.CantidadProducto,
                               Estado=salidInventario.Estado,
                               LoteId = salidInventario.LoteId,
                               UsuarioCreacion = salidInventario.UsuarioCreacion

                           }).ToList();
            return Respuesta.Success(listado, Mensajes.PROCESO_EXITOSO, Codigos.Success);

        }

        public Respuesta<List<ListarSalidasInventarioDetalleDto>> ListarSalidasInventarioDetallePorProducto()
        {




            var listado = (from salidInventario in _unitOfWork.Repository<SalidasInventarioDetalle>().AsQueryable()
                           where salidInventario.Estado == true
                           select new ListarSalidasInventarioDetalleDto
                           {
                               SalidaInventarioId = salidInventario.SalidaInventarioId,
                               DetalleId = salidInventario.DetalleId,
                               CantidadProducto = salidInventario.CantidadProducto,
                               Estado = salidInventario.Estado,
                               LoteId = salidInventario.LoteId,
                               UsuarioCreacion = salidInventario.UsuarioCreacion

                           }).ToList();
            return Respuesta.Success(listado, Mensajes.PROCESO_EXITOSO, Codigos.Success);

        }

        public Respuesta<SalidasInventarioDetalleDto> AgregarSalidaInventarioDetalle(SalidasInventarioDetalleDto salidainventarioDetalleDtos)
        {
            try
            {
                var salidasInventariosDetalle = _mapper.Map<SalidasInventarioDetalle>(salidainventarioDetalleDtos);

                _unitOfWork.Repository<SalidasInventarioDetalle>().Add(salidasInventariosDetalle);
                _unitOfWork.SaveChanges();
                salidainventarioDetalleDtos.SalidaInventarioId = salidasInventariosDetalle.SalidaInventarioId;

                return Respuesta.Success(_mapper.Map<SalidasInventarioDetalleDto>(salidasInventariosDetalle), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<SalidasInventarioDetalleDto>(Mensajes.PROCESO_FALLIDO);
            }
        }


        public Respuesta<SalidasInventarioDetalleDto> EditarSalidaInventarioDetalle(SalidasInventarioDetalleDto salidaInventarioDetalle)
        {

            try
            {
                var EditarInventarioDetalle = _unitOfWork.Repository<SalidasInventarioDetalle>().FirstOrDefault
                    (x => x.SalidaInventarioId == salidaInventarioDetalle.SalidaInventarioId);

                if (salidaInventarioDetalle != null)
                {

                    EditarInventarioDetalle.DetalleId = salidaInventarioDetalle.DetalleId;
                    EditarInventarioDetalle.SalidaInventarioId = salidaInventarioDetalle.SalidaInventarioId;
                    EditarInventarioDetalle.LoteId = salidaInventarioDetalle.LoteId;
                    EditarInventarioDetalle.CantidadProducto = salidaInventarioDetalle.CantidadProducto;
                    EditarInventarioDetalle.Estado = salidaInventarioDetalle.Estado;
                    EditarInventarioDetalle.UsuarioCreacion = 1;
                    EditarInventarioDetalle.FechaModificacion = DateTime.Now;


                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<SalidasInventarioDetalleDto>(EditarInventarioDetalle), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<SalidasInventarioDetalleDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
        public Respuesta<string> EliminarSalidaInventarioDetalle(int Id)
        {
            try
            {
                var EliminarSalidasInventarioDetalle = _unitOfWork.Repository<SalidasInventarioDetalleDto>().Where(x => x.SalidaInventarioId == Id).FirstOrDefault();

                EliminarSalidasInventarioDetalle.Estado = false;

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
