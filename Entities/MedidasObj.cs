namespace GYM_VidaYSalud.Entities
{
    public class MedidasObj
    {
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal Hombro { get; set; }
        public decimal Pecho { get; set; }
        public decimal Cadera { get; set; }
        public decimal Abdomen { get; set; }
        public decimal Cintura { get; set; }
        public decimal BicepD { get; set; }
        public decimal BicepI { get; set; }
        public decimal MusloD { get; set; }
        public decimal MusloI { get; set; }
        public decimal PantorrillaD { get; set; }
        public decimal PantorrillaI { get; set; }
        public string Cedula { get; set; } = string.Empty;
    }

    public class RespuestaDatosMedidas
    {
        public string Mensaje { get; set; } = string.Empty;
        public List<MedidasObj> ListaDatos { get; set; } = null;
        public MedidasObj Datos { get; set; } = null;

    }
}
