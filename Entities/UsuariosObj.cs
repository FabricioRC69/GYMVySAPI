namespace GYM_VidaYSalud.Entities
{
    public class UsuariosObj
    {
        public string Correo { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }

    public class UsuarioObj
    {
        public int idUsuario { get; set; }
    }

    public class RespuestaDatosUsuarios
    {
        public string Mensaje { get; set; } = string.Empty;
        public List<UsuariosObj> ListaDatos { get; set; } = null;
        public UsuariosObj Datos { get; set; } = null;
    }

}
