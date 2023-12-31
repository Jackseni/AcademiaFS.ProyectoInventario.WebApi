﻿namespace AcademiaFS.ProyectoInventario.WebApi._Common
{
    public class Mensajes
    {
        public const string PROCESO_EXITOSO = "Operación Correcta";
        public const string PROCESO_FALLIDO = "Error. Intente más tarde";
        public const string DATOS_INCORRECTOS = "Los datos se han enviado de forma incorrecta. Revise llaves foráneas, constraints, nulos, etc";
        public const string VALOR_INCORRECTO = "El valor es mayor es mayor del que hay en stock";

        public static string CAMPO_VACIO(string nombrePropiedad)
        {
            return $"El campo '{nombrePropiedad}' es requerido";
        }
        public static string LONGITUD_ERRONEA(string nombrePropiedad, int numeroCaracteres)
        {
            return $"El campo '{nombrePropiedad}' no cumple con el número de caracteres permitidos ({numeroCaracteres})";
        }
        public static string REPETIDO(string nombrePropiedad)
        {
            return $"Este(a) '{nombrePropiedad}' ya existe";
        }
        public static string NO_EXISTE(string nombrePropiedad)
        {
            return $"El/la '{nombrePropiedad}' no existe";
        }

        public static string CANTIDAD_MAYOR(string nombrePropiedad)
        {
            return $"La '{nombrePropiedad}' Pasa el limite";
        }

        public static string EXITO(string nombrePropiedad)
        {
            return $"La '{nombrePropiedad}' Es correcto";
        }


    }



}
