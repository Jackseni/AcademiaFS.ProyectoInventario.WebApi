using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos
{
    public class PerfilesPorPermisoService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly DomainService _domainService;

        public PerfilesPorPermisoService(UnitOfWordBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
            // _domainService = domainService;
        }

        public Respuesta<List<ListarPerfilPorPermisoDto>> ListarPerfilesPorPermiso()
        {
            var listado = (from perfil in _unitOfWork.Repository<PerfilesPorPermiso>().AsQueryable()
                           where perfil.Activo == true
                           select new ListarPerfilPorPermisoDto
                           {
                               PerfilId = perfil.PerfilId,
                               PermisoId = perfil.PermisoId,
                               Activo = perfil.Activo,

                           }).ToList();
            return Respuesta.Success(listado, Mensajes.PROCESO_EXITOSO, Codigos.Success);

        }


        public Respuesta<PerfilesPorPermisoDto> AgregarPerfilPorPermiso(PerfilesPorPermisoDto perfilPorPermisoDtos)
        {
            try
            {
                var perfilPorPermiso = _mapper.Map<PerfilesPorPermiso>(perfilPorPermisoDtos);

                _unitOfWork.Repository<PerfilesPorPermiso>().Add(perfilPorPermiso);
                _unitOfWork.SaveChanges();
                perfilPorPermisoDtos.PerfilId = perfilPorPermiso.PerfilId;

                return Respuesta.Success(_mapper.Map<PerfilesPorPermisoDto>(perfilPorPermiso), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<PerfilesPorPermisoDto>(Mensajes.PROCESO_FALLIDO);
            }
        }


        public Respuesta<PerfilesPorPermisoDto> EditarPerfilPorPermiso(PerfilesPorPermisoDto perfil)
        {

            try
            {
                var EditarPerfilPorPermiso = _unitOfWork.Repository<PerfilesPorPermiso>().FirstOrDefault
                    (x => x.PerfilId == perfil.PerfilId);

                if (perfil != null)
                {
                    EditarPerfilPorPermiso.Activo = perfil.Activo;
                    EditarPerfilPorPermiso.ModificadoPor = 1;
                    EditarPerfilPorPermiso.ModificadoEl = DateTime.Now;


                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<PerfilesPorPermisoDto>(EditarPerfilPorPermiso), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<PerfilesPorPermisoDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
        public Respuesta<string> EliminarPerfilPorPermiso(int Id)
        {
            try
            {
                var EliminarPerfil = _unitOfWork.Repository<PerfilesPorPermiso>().Where(x => x.PerfilId == Id).FirstOrDefault();

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
