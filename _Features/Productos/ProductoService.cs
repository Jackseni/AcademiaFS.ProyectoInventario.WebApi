using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Domain;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Productos
{
    public class ProductoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DomainService _domainService;

        public ProductoService(UnitOfWordBuilder unitOfWork, IMapper mapper, DomainService validacionesDomain)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
            _domainService = validacionesDomain;
        }

        public Decimal ObtenerCantidadInventario(int SalidaInventarioId)
        {
            var CantidadObtenida = _unitOfWork.Repository<SalidasInventario>().FirstOrDefault(total => total.SalidaInventarioId == SalidaInventarioId);
            if (CantidadObtenida != null)
            {
                decimal total = CantidadObtenida.Total;
                return total;
            }
            return CantidadObtenida.Total;
        }

       

        public Respuesta<ProductoDto> AgregarProductoPorCantidad(ProductoDto productoDtos)
        {
            try
            {

                if (!_domainService.CantidadEnInventarioProducto(productoDtos.ProductoId))
                    return Respuesta.Fault<ProductoDto>(Mensajes.NO_EXISTE("Producto"), Codigos.Error);


                var producto = _mapper.Map<Producto>(productoDtos);

                _unitOfWork.Repository<Producto>().Add(producto);
                _unitOfWork.SaveChanges();
                productoDtos.ProductoId = producto.ProductoId;

                return Respuesta.Success(_mapper.Map<ProductoDto>(producto), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<ProductoDto>(Mensajes.PROCESO_FALLIDO);
            }

        }

        public Respuesta<List<ListaProductoDto>> ListarProductos()
        {
            var listado = (from product in _unitOfWork.Repository<Producto>().AsQueryable()
                           where product.Estado == true
                           select new ListaProductoDto
                           {
                               ProductoId = product.ProductoId,
                               Nombre = product.Nombre,
                               FechaCreacion = product.FechaCreacion,
                               Estado = product.Estado,

                           }).ToList();
            return Respuesta.Success(listado, Mensajes.PROCESO_EXITOSO, Codigos.Success);

        }

        public Respuesta<ProductoDto> AgregarProducto(ProductoDto productoDtos)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDtos);

                _unitOfWork.Repository<Producto>().Add(producto);
                _unitOfWork.SaveChanges();
                productoDtos.ProductoId = producto.ProductoId;

                return Respuesta.Success(_mapper.Map<ProductoDto>(producto), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<ProductoDto>(Mensajes.PROCESO_FALLIDO);
            }
        }


        public Respuesta<ProductoDto> EditarProducto(ProductoDto producto)
        {

            try
            {
                var EditarProducto = _unitOfWork.Repository<Producto>().FirstOrDefault
                    (x => x.ProductoId == producto.ProductoId);

                if (producto != null)
                {

                    EditarProducto.Nombre = producto.Nombre;
                    EditarProducto.Estado = producto.Estado;
                    EditarProducto.UsuarioCreacion = 1;
                    EditarProducto.FechaModificacion = DateTime.Now;


                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<ProductoDto>(EditarProducto), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<ProductoDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
        public Respuesta<string> EliminarProducto(int Id)
        {
            try
            {
                var EliminarProducto = _unitOfWork.Repository<Producto>().Where(x => x.ProductoId == Id).FirstOrDefault();

                EliminarProducto.Estado = false;

                _unitOfWork.SaveChanges();


                return Respuesta.Success<string>(Mensajes.PROCESO_EXITOSO, Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<string>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }


        public Respuesta<ProductoDetalleDto>ActualizarRegistroLotePorProducto( int productoId, int cantidadSolicitada)
        {
           

            ProductoDetalleDto productoDetalleDto = new ProductoDetalleDto()
            {

                cantidadSolicitada = cantidadSolicitada,
            };



            return Respuesta<ProductoDetalleDto>.Success(productoDetalleDto, Mensajes.PROCESO_EXITOSO, Codigos.Success);
        }


        public Respuesta<DetalleLoteProductoDto> ObtenerLotesPorProducto(int Idproducto)
        {
           

                if (!_domainService.ProductoExiste(Idproducto)) Respuesta<object>.Fault(Mensajes.PROCESO_FALLIDO, "400", null!);

                var datosProducto = _unitOfWork.Repository<Producto>().FirstOrDefault(x => x.ProductoId == Idproducto);
                var datosLote = (from lote in _unitOfWork.Repository<ProductosLote>().AsQueryable()
                                 where (lote.ProductoId == Idproducto )
                                 select lote)
                                .OrderBy(x => x.FechaVencimiento)
                                .ToList();

                List<ProductosLoteDto> datosloteDto = _mapper.Map<List<ProductosLoteDto>>(datosLote);
                DetalleLoteProductoDto loteProducto = new DetalleLoteProductoDto()
                {
                    ProductoId = datosProducto!.ProductoId,
                
                };

                return Respuesta.Success<DetalleLoteProductoDto>(loteProducto, Mensajes.PROCESO_EXITOSO, "200");

        }

    }
}
