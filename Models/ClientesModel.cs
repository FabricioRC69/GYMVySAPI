using GYM_VidaYSalud.Entities;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace GYM_VidaYSalud.Models
{
    public class ClientesModel
    {
          public List<ClientesObj> ConsultarClientes(string conexion)
            {
            using (var conn = new SqlConnection(conexion))
            {
                return (List<ClientesObj>)conn.Query<ClientesObj>("ConsultarTodosClientes", new { }, commandType: CommandType.StoredProcedure);
            }
        }

        public ClientesObj ConsultarUnCliente(string Cedula, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                var datos = (List<ClientesObj>)conn.Query<ClientesObj>("ConsultarUnCliente", new { Cedula }, commandType: CommandType.StoredProcedure);
                return datos.FirstOrDefault();
            }
        }

        public void RegistrarCliente(ClientesObj cliente, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("RegistrarCliente", new { cliente.Cedula, cliente.NombreCompleto, cliente.NumContacto, cliente.Correo }, commandType: CommandType.StoredProcedure);

            }
        }

        public void ModificarCliente(string Cedula, string NombreCompleto, string NumContacto, string Correo, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("ModificarCliente", new { Cedula, NombreCompleto, NumContacto, Correo }, commandType: CommandType.StoredProcedure);

            }
        }

        public void EliminarCliente(string Cedula, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("EliminarCliente", new { Cedula}, commandType: CommandType.StoredProcedure);

            }
        }
    }
}
