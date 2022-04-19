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

        public MedidasObj ConsultarUnaMedida(string Cedula, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                var datos = (List<MedidasObj>)conn.Query<MedidasObj>("ConsultarMedidaPersona", new { Cedula }, commandType: CommandType.StoredProcedure);
                return datos.FirstOrDefault();
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
                    medida.Cedula
                }, commandType: CommandType.StoredProcedure);

            }
        }

        public void ModificarMedida(string Cedula, string Peso, string Altura, string Hombro, string Pecho, string Cadera, string Abdomen
           , string Cintura, string BicepD, string BicepI, string MusloD, string MusloI, string PantorrillaD, string PantorrillaI, string conexion)
        {
            using (var conn = new SqlConnection(conexion))
            {
                conn.Execute("ModificarMedida", new
                {
                    Cedula,
                    Peso,
                    Altura,
                    Hombro,
                    Pecho,
                    Cadera,
                    Abdomen,
                    Cintura,
                    BicepD,
                    BicepI,
                    MusloD,
                    MusloI,
                    PantorrillaD,
                    PantorrillaI
                }, commandType: CommandType.StoredProcedure);

            }
        }
    }
}
