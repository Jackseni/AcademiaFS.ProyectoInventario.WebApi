using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles
{
    public class PerfileService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly DomainService _domainService;

        public PerfileService(UnitOfWordBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
            // _domainService = domainService;
        }

        public Respuesta<List<ListarPerfilDto>> ListarPerfiles ()
        {
            var listado = (from perfil in _unitOfWork.Repository<Perfile>().AsQueryable()
                           where perfil.Activo == true
                           select new ListarPerfilDto
                           {
                               PerfilId = perfil.PerfilId,
                               Nombre = perfil.Nombre,
                               Activo = perfil.Activo,
                               
                           }).ToList();
            return Respuesta.Success(listado,Mensajes.PROCESO_EXITOSO, Codigos.Success);

        }

        public Respuesta<PerfileDto> AgregarPerfil(PerfileDto perfilDtos)
        {
            try
            {
                var perfil = _mapper.Map<Perfile>(perfilDtos);

                _unitOfWork.Repository<Perfile>().Add(perfil);
                _unitOfWork.SaveChanges();
                perfilDtos.PerfilId = perfil.PerfilId;

                return Respuesta.Success(_mapper.Map<PerfileDto>(perfil), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<PerfileDto>(Mensajes.PROCESO_FALLIDO);
            }
        }


        public Respuesta<PerfileDto> EditarPerfil(PerfileDto perfil)
        {

            try
            {
                var EditarPerfil = _unitOfWork.Repository<Perfile>().FirstOrDefault
                    (x => x.PerfilId == perfil.PerfilId);

                if (perfil != null)
                {

                    EditarPerfil.Nombre = perfil.Nombre;
                    EditarPerfil.Activo = perfil.Activo;
                    EditarPerfil.ModificadoPor = 1;
                    EditarPerfil.ModificadoEl = DateTime.Now;


                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<PerfileDto>(EditarPerfil), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<PerfileDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
        public Respuesta<string> EliminarPerfil(int Id)
        {
            try
            {
                var EliminarPerfil = _unitOfWork.Repository<Perfile>().Where(x => x.PerfilId == Id).FirstOrDefault();

                EliminarPerfil.Activo = false;

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
