using Dapper;
using GYM_VidaYSalud.Entities;
using System.Data;
using System.Data.SqlClient;

namespace GYM_VidaYSalud.Models
{
    public class MedidasModel
    {
        public List<MedidasObj> ConsultarMedidas(string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                return (List<MedidasObj>)conn.Query<MedidasObj>("ConsultarTodasMedidas", new { }, commandType: CommandType.StoredProcedure);
            }
        }

        public MedidasObj ConsultarUnaMedida(long idMedidas, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                var datos = (List<MedidasObj>)conn.Query<MedidasObj>("ConsultarMedidaPersona", new { idMedidas }, commandType: CommandType.StoredProcedure);
                return datos.FirstOrDefault();
            }
        }

        public List<MedidasSelectObj> ConsultarMedidaSelectList(string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                return (List<MedidasSelectObj>)conn.Query<MedidasSelectObj>("MedidaSelectList", new { }, commandType: CommandType.StoredProcedure);
            }
        }
        public List<MedidasSelectObj> ConsultarMedidaSelectListAll(long idCliente, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                return (List<MedidasSelectObj>)conn.Query<MedidasSelectObj>("MedidaSelectListAll", new { idCliente }, commandType: CommandType.StoredProcedure);
            }
        }

        public void RegistrarMedida(MedidasObj medida, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("RegistrarMedida", new
                {
                    medida.Peso,
                    medida.Altura,
                    medida.Hombro,
                    medida.Pecho,
                    medida.Cadera,
                    medida.Abdomen,
                    medida.Cintura,
                    medida.BicepD,
                    medida.BicepI,
                    medida.MusloD,
                    medida.MusloI,
                    medida.PantorrillaD,
                    medida.PantorrillaI,
                    medida.idCliente
                }, commandType: CommandType.StoredProcedure);

            }
        }

        public void ModificarMedida(MedidasObj medida, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("ModificarMedida", new
                {
                    medida.idMedidas,
                    medida.Peso,
                    medida.Altura,
                    medida.Hombro,
                    medida.Pecho,
                    medida.Cadera,
                    medida.Abdomen,
                    medida.Cintura,
                    medida.BicepD,
                    medida.BicepI,
                    medida.MusloD,
                    medida.MusloI,
                    medida.PantorrillaD,
                    medida.PantorrillaI,
                    medida.idCliente
                }, commandType: CommandType.StoredProcedure);

            

             }
        }
    }
}
