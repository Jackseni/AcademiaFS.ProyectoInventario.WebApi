using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios
{
    public class UsuarioService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(UnitOfWordBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaInventario();
            _mapper = mapper;
        }


        public Respuesta<UsuarioDto?> Login(string username, string password)
        {


            var respuesta = (from usuario in _unitOfWork.Repository<Usuario>().AsQueryable()
                             where usuario.NombreUsuario == username && usuario.Contrasena == password && usuario.Estado == true
                             select new UsuarioDto
                             {
                                 NombreUsuario = usuario.NombreUsuario,
                                 UsuarioId = usuario.UsuarioId,
                                 PerfilId = usuario.PerfilId,
                             }).FirstOrDefault();

            if (respuesta != null)
            {
                return Respuesta.Success(respuesta, "Sesión iniciada", "200");
            }
            else
            {
                return Respuesta.Fault("Usuario o contraseña incorrectos", "404", respuesta);
            }
         }


            private static bool VerificarContraseña(string password, string hashedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                // Calcular el hash SHA-256 de la contraseña proporcionada
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                // Comparar el hash calculado con el hash almacenado
                return Convert.ToBase64String(hash) == hashedPassword;
            }
        }





        //    public  Respuesta<UsuarioDto> Login(string username, string password)
        //        {
        //    // Obtener el usuario por nombre de usuario
        //    var usuario = _unitOfWork.Repository<Usuario>()
        //        .AsQueryable()
        //        .FirstOrDefault(u => u.NombreUsuario == username );

        //    if (usuario != null && VerificarContraseña(password, usuario.Contrasena))
        //    {
        //        // Crear un objeto UsuarioDto para la respuesta
        //        var respuesta = new UsuarioDto
        //        {
        //            NombreUsuario = usuario.NombreUsuario,
        //            UsuarioId = usuario.UsuarioId,
        //            PerfilId = usuario.PerfilId,
        //        };

        //        // Devolver respuesta exitosa
        //        return Respuesta.Success(respuesta, "Sesión iniciada", "200");
        //    }
        //    else
        //    {
        //        // Devolver respuesta de fallo
        //        return Respuesta.Fault<UsuarioDto?>("Usuario o contraseña incorrectos", "404", null);
        //    }
        //}
    }
}
