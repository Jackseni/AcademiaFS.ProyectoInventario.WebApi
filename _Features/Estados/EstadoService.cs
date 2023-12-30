using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Azure.Core;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Estados
{
    public class EstadoService
    {


        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly DomainService _domainService;

        public EstadoService(UnitOfWordBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
            // _domainService = domainService;
        }

        public Respuesta<List<ListarEstadoDto>> ListarEstados()
        {
            var listado = (from estado in _unitOfWork.Repository<Estado>().AsQueryable()
                           where estado.Estado1 == true
                           select new ListarEstadoDto
                           {
                               EstadoId=estado.EstadoId,
                               NombreEstado = estado.NombreEstado,
                               Estado1 = estado.Estado1,
                               UsuarioCreacion = estado.UsuarioCreacion,
                               FechaCreacion = estado.FechaCreacion
                           }).ToList();
            return Respuesta.Success(listado,Mensajes.PROCESO_EXITOSO,Codigos.Success);

        }

        public Respuesta<EstadoDto> AgregarEstado(EstadoDto estadoDtos)
        {

            try
            {
                var estado = _mapper.Map<Estado>(estadoDtos);

                _unitOfWork.Repository<Estado>().Add(estado);
                _unitOfWork.SaveChanges();
                estadoDtos.EstadoId = estado.EstadoId;

                return Respuesta.Success(_mapper.Map<EstadoDto>(estado), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<EstadoDto>(Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<EstadoDto> EditarEstado(EstadoDto estado)
        {

            try
            {
                var EditarEstado = _unitOfWork.Repository<Estado>().FirstOrDefault
                    (x => x.EstadoId == estado.EstadoId);

                if (estado != null)
                {

                    EditarEstado.NombreEstado = estado.NombreEstado;
                    EditarEstado.Estado1= estado.Estado;
                    EditarEstado.UsuarioModificacion = 1;
                    EditarEstado.FechaModificacion = DateTime.Now;


                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<EstadoDto>(EditarEstado), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<EstadoDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
        public Respuesta<string> EliminarEstado(int Id)
        {
            try
            {
                var EliminarEstado = _unitOfWork.Repository<Estado>().Where(x => x.EstadoId == Id).FirstOrDefault();

                EliminarEstado.Estado1 = false;

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