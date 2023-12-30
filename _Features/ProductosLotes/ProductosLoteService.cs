using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Domain;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes
{
    public class ProductosLoteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly DomainService _domainService;

        public ProductosLoteService(UnitOfWordBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
            // _domainService = domainService;
        }


        public Respuesta<ObtenerProductoLoteDto> ObtenerLotePorFehaVencimiento(int ProductoId)
        {
             if (ProductoId <= 0)
            {
                return Respuesta.Fault<ObtenerProductoLoteDto>(Mensajes.NO_EXISTE("Producto"), Codigos.Error);
            }
            ObtenerProductoLoteDto? loteDto = (from lotes in _unitOfWork.Repository<ProductosLote>().AsQueryable()
                                               where (lotes.ProductoId == ProductoId && lotes.Estado)
                                               select new ObtenerProductoLoteDto
                                               {
                                                   Costo =lotes.Costo,
                                                   Inventario = lotes.Inventario,
                                                   FechaVencimiento= lotes.FechaVencimiento
                                               }).OrderBy(x => x.FechaVencimiento).FirstOrDefault();

            if (loteDto == null)
            {
                return Respuesta.Fault<ObtenerProductoLoteDto>(Mensajes.NO_EXISTE("Producto"), Codigos.Error);

            }

            return Respuesta.Fault<ObtenerProductoLoteDto>(Mensajes.EXITO("Producto"), Codigos.Error);


        }

        public Respuesta<List<ListarProductoLoteDto>> ListarProductosLote()
        {
            var listado = (from product in _unitOfWork.Repository<ProductosLote>().AsQueryable()
                           where product.Estado == true
                           select new ListarProductoLoteDto
                           {
                               ProductoId = product.ProductoId,
                               Estado = product.Estado,
                               CantidadInicial = product.CantidadInicial,
                               FechaVencimiento = product.FechaVencimiento,
                               LoteId = product.LoteId,
                               Costo = product.Costo,
                               UsuarioCreacion = product.UsuarioCreacion,


                           }).ToList();
            return Respuesta.Success(listado,Mensajes.PROCESO_EXITOSO,Codigos.Success);

        }


        public Respuesta<ProductosLoteDto> AgregarProductoLote(ProductosLoteDto productoDtos)
        {
            try
            {
                var producto = _mapper.Map<ProductosLote>(productoDtos);

                _unitOfWork.Repository<ProductosLote>().Add(producto);
                _unitOfWork.SaveChanges();
                productoDtos.ProductoId = producto.ProductoId;

                return Respuesta.Success(_mapper.Map<ProductosLoteDto>(producto), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<ProductosLoteDto>(Mensajes.PROCESO_FALLIDO);
            }
        }


        public Respuesta<ProductosLoteDto> EditarProductoLote(ProductosLoteDto producto)
        {

            try
            {
                var EditarProducto = _unitOfWork.Repository<ProductosLote>().FirstOrDefault
                    (x => x.ProductoId == producto.ProductoId);

                if (producto != null)
                {

                    EditarProducto.ProductoId = producto.ProductoId;
                    EditarProducto.CantidadInicial = producto.CantidadInicial;
                    EditarProducto.Costo = producto.Costo;
                    EditarProducto.FechaVencimiento = producto.FechaVencimiento;
                    EditarProducto.Inventario= producto.Inventario;
                    EditarProducto.Estado = producto.Estado;    
                    EditarProducto.UsuarioCreacion = 1;
                    EditarProducto.FechaModificacion = DateTime.Now;


                    _unitOfWork.SaveChanges();
                }


                return Respuesta.Success(_mapper.Map<ProductosLoteDto>(EditarProducto), Mensajes.PROCESO_EXITOSO, Codigos.Success);
            }
            catch
            {
                return Respuesta.Fault<ProductosLoteDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }
        public Respuesta<string> EliminarProductoLote(int Id)
        {
            try
            {
                var EliminarProducto = _unitOfWork.Repository<ProductosLoteDto>().Where(x => x.ProductoId == Id).FirstOrDefault();

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
