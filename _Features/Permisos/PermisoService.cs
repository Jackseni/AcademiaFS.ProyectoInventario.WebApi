using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Permisos
{
    public class PermisoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly DomainService _domainService;

        public PermisoService(UnitOfWordBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
            // _domainService = domainService;
        }

        public Respuesta<List<ListarPermisoDto>> ListarPermisos()
        {
            var listado = (from perfil in _unitOfWork.Repository<Permiso>().AsQueryable()
                           where perfil.Activo == true
                           select new ListarPermisoDto
                           {
                               PermisoId = perfil.PermisoId,
                               Permiso1 = perfil.Permiso1,
                               Activo = perfil.Activo,

                           }).ToList();
            return Respuesta.Success(listado,Mensajes.PROCESO_EXITOSO, Codigos.Success);

        }

        public Respuesta<PermisoDto> AgregarPermiso(PermisoDto permisoDtos)
        {
            try
            {
                var permiso = _mapper.Map<Permiso>(permisoDtos);

                _unitOfWork.Repository<Permiso>().Add(permiso);
                _unitOfWork.SaveChanges();
                permisoDtos.PermisoId = permiso.PermisoId;

                return Respuesta.Success(_mapper.Map<PermisoDto>(permiso), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<PermisoDto>(Mensajes.PROCESO_FALLIDO);
            }
        }


        public Respuesta<PermisoDto> EditarPermiso(PermisoDto perfil)
        {

            try
            {
                var EditarPermiso = _unitOfWork.Repository<Permiso>().FirstOrDefault
                    (x => x.PermisoId == perfil.PermisoId);

                if (perfil != null)
                {

                    EditarPermiso.Permiso1 = perfil.Permiso1;
                    EditarPermiso.Activo = perfil.Activo;
                    EditarPermiso.ModificadoPor = 1;
                    EditarPermiso.ModificadoEl = DateTime.Now;


                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<PermisoDto>(EditarPermiso), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<PermisoDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
        public Respuesta<string> EliminarPermiso(int Id)
        {
            try
            {
                var EliminarPermiso = _unitOfWork.Repository<Permiso>().Where(x => x.PermisoId == Id).FirstOrDefault();

                EliminarPermiso.Activo = false;

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
