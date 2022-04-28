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

        public ClientesObj ConsultarUnCliente(long idCliente, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                var datos = (List<ClientesObj>)conn.Query<ClientesObj>("ConsultarUnCliente", new { idCliente }, commandType: CommandType.StoredProcedure);
                return datos.FirstOrDefault();
            }
        }

        public void RegistrarCliente(ClientesObj cliente, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("RegistrarCliente", new {cliente.Cedula, cliente.NombreCompleto, cliente.NumContacto, cliente.Correo }, commandType: CommandType.StoredProcedure);

            }
        }

        public void ModificarCliente(ClientesObj cliente, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("ModificarCliente", new { cliente.idCliente, cliente.Cedula, cliente.NombreCompleto, cliente.NumContacto, cliente.Correo }, commandType: CommandType.StoredProcedure);

            }
        }

        public void EliminarCliente(long idCliente, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("EliminarCliente", new { idCliente }, commandType: CommandType.StoredProcedure);

            }
        }

    }
}
