namespace AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Dto
{
    public class EmpleadoListarDto
    {
        public int EmpleadoId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Direccion { get; set; }

        public bool Estado { get; set; }
    }
}
