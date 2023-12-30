using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.ProyectoInventario.WebApi.Domain
{
    public class DomainService
    {

        private readonly IUnitOfWork _unitOfWork;
        public DomainService(UnitOfWordBuilder unitOfWork)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
        }

        public Respuesta<T> ValidacionCambiosBase<T>(Exception exception)
        {
            if (exception.Message.Contains("saving the entity changes"))
                return Respuesta.Fault<T>(Mensajes.DATOS_INCORRECTOS, Codigos.BadRequest);
            else
                return Respuesta.Fault<T>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
        }


        public bool CantidadTotal()
        {
            bool mayormil = _unitOfWork.Repository <SalidasInventario>().Where(x => x.Total >= 5000).Any();

            return mayormil;


        }

        public bool CantidadEnInventarioProducto(int cantidad)
        {
            bool cantidadd = _unitOfWork.Repository<SalidasInventario>().Where(x => x.Total < cantidad).Any();

            return cantidadd;


        }

        public bool EmpleadoExisteId(int id)
        {
            bool existe = _unitOfWork.Repository<Empleado>().Where(x => x.EmpleadoId == id).Any();

            return existe;
        }

        public bool ProductoExiste(int productoId)
        {
            bool existe = _unitOfWork.Repository<Producto>().Where(x => x.ProductoId == productoId).Any();

            return existe;
        }

        public bool SucursalExiste(int sucursal)
        {
            bool existe = _unitOfWork.Repository<Sucursale>().Where(x => x.SucursalId == sucursal).Any();

            return existe;
        }

       public bool InventarioDisponile( List<ProductosLoteDto> productoLoteDto , int cantidadSolicitada)
        {
            int totalProducto = productoLoteDto
                .Where(x => x.InventarioDisponible > 0 && x.Estado)
                .Sum(x => x.InventarioDisponible);
            return totalProducto > cantidadSolicitada;
        }


        public bool LotesExiste(int LoteId)
        {
            bool existe = _unitOfWork.Repository<ProductosLote>().Where(x => x.LoteId == LoteId  && x.Estado).Any();

            return existe;
        }

        internal bool InventarioDisponile(object lotes, int cantidadSolicitada)
        {
            throw new NotImplementedException();
        }
    }
}