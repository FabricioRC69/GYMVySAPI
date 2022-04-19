using Dapper;
using GYM_VidaYSalud.Entities;
using System.Data;
using System.Data.SqlClient;

namespace GYM_VidaYSalud.Models
{
    public class UsuariosModel
    {

        public UsuariosObj Consultalogin(string Correo, string Contraseña, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                var datos = (List<UsuariosObj>)conn.Query<UsuariosObj>("ConsultarUsuarioLogin", new { Correo, Contraseña}, commandType: CommandType.StoredProcedure);
                return datos.FirstOrDefault();
            }
        }
        public void RegistraUsuario(UsuariosObj usuario, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("RegistrarUsuario", new { usuario.Correo, usuario.Contraseña, usuario.Rol }, commandType: CommandType.StoredProcedure);

            }
        }
        public void RegistraBitacoraRegistroYLogin(int idUsuario, string correo, string mensajeError, string conexion)
        {
            DateTime fecha = DateTime.Now;
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("RegistrarBitacora", new { idUsuario, correo, mensajeError, fecha}, commandType: CommandType.StoredProcedure);

            }
        }
        
         public UsuarioObj ComprobarUsuarioPorCorreo(string Correo, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                var datos = (List<UsuarioObj>)conn.Query<UsuarioObj>("ComprobarUsuarioPorCorreo", new { Correo}, commandType: CommandType.StoredProcedure);
                return datos.FirstOrDefault();
            }
        }

    }
}
