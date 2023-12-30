using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Domain;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Empleados
{
    public class EmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
       // private readonly DomainService _domainService;

        public EmpleadoService(UnitOfWordBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
          // _domainService = domainService;
        }

        public Respuesta<List<EmpleadoListarDto>> ListarEmpleados()
        {
            var listado = (from empleado in _unitOfWork.Repository<Empleado>().AsQueryable()
                           where empleado.Estado == true
                           select new EmpleadoListarDto
                           {
                               EmpleadoId = empleado.EmpleadoId,
                               Apellido = empleado.Apellido,
                               Nombre = empleado.Nombre,
                               Direccion = empleado.Direccion,
                               Estado=empleado.Estado

                           }).ToList();
            return Respuesta.Success(listado,Mensajes.PROCESO_EXITOSO,Codigos.Success);
        }

        //public Respuesta<EmpleadoDto> InsertarColaboradores(EmpleadoDto empleadoDto)
        //{
        //}



        public Respuesta<EmpleadoDto> AgregarEmpleado(EmpleadoDto empleadoDtos)
        {
            try
            {
                var empleado = _mapper.Map<Empleado>(empleadoDtos);

                _unitOfWork.Repository<Empleado>().Add(empleado);
                _unitOfWork.SaveChanges();
                empleadoDtos.EmpleadoId= empleado.EmpleadoId;

                return Respuesta.Success(_mapper.Map<EmpleadoDto>(empleado), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<EmpleadoDto>(Mensajes.PROCESO_EXITOSO);
            }
        }

        public Respuesta<EmpleadoDto> EditarEmpleado(EmpleadoDto empleado)
        {

            try
            {
                var EditarEmpleado = _unitOfWork.Repository<Empleado>().FirstOrDefault
                    (x => x.EmpleadoId == empleado.EmpleadoId);

                if (empleado != null)
                {

                    EditarEmpleado.Nombre = empleado.Nombre;
                    EditarEmpleado.Apellido= empleado.Apellido;
                    EditarEmpleado.Direccion = empleado.Direccion;
                    EditarEmpleado.UsuarioModificacion = 1;
                    EditarEmpleado.FechaModificacion = DateTime.Now;
                   

                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<EmpleadoDto>(EditarEmpleado), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<EmpleadoDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }





        public Respuesta<string> EliminarEmpleado(int Id)
        {
            try
            {
                var Eliminarempleado = _unitOfWork.Repository<Empleado>().Where(x => x.EmpleadoId == Id).FirstOrDefault();

                Eliminarempleado.Estado = false;

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
