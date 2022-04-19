using GYM_VidaYSalud.Entities;
using GYM_VidaYSalud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_VidaYSalud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidasController : ControllerBase
    {

        MedidasModel model = new MedidasModel();
        private readonly IConfiguration _configuration;

        public MedidasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        [Route("/api/Proyecto/ConsultarTodasMedidas")]
        public ActionResult<RespuestaDatosMedidas> ConsultarClientes()
        {
            try
            {
                var respuesta = model.ConsultarMedidas(_configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                resp.Mensaje = "Consulta correcta";
                resp.ListaDatos = respuesta;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                resp.Mensaje = ex.Message;
                resp.ListaDatos = null;
                return BadRequest(resp);
            }
        }

        [HttpGet]
        [Route("/api/Proyecto/ConsultarUnaMedida")]
        public ActionResult<RespuestaDatosMedidas> ConsultarMedidaPersona(string Cedula)
        {
            try
            {
                var respuesta = model.ConsultarUnaMedida(Cedula, _configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                resp.Mensaje = "Consulta correcta";
                resp.Datos = respuesta;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }

        [HttpPost]
        [Route("/api/Proyecto/RegistrarMedida")]
        public ActionResult<RespuestaDatosMedidas> RegistrarMedida(MedidasObj medida , string Cedula)
        {
            try
            {
                model.RegistrarMedida(medida,
                    _configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                resp.Mensaje = "Medida registrada con exito";
                resp.Datos = null;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }
        [HttpPut]
        [Route("/api/Proyecto/ModificarMedida")]
        public ActionResult<RespuestaDatosMedidas> Actualizar(string Cedula, string Peso, string Altura, string Hombro, string Pecho, string Cadera, string Abdomen
            , string Cintura, string BicepD, string BicepI, string MusloD, string MusloI, string PantorrillaD, string PantorrillaI)
        {
            try
            {
                var medida = model.ConsultarUnaMedida(Cedula, _configuration.GetSection("Llaves:DefaultConnection").Value);

                if (medida != null)
                {
                    model.ModificarMedida(
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
                    PantorrillaI,
                    _configuration.GetSection("Llaves:DefaultConnection").Value);

                    RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                    resp.Mensaje = "Se modificaron los datos con exito";
                    resp.Datos = null;
                    return Ok(resp);
                }
                else
                {
                    RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                    resp.Mensaje = "No se encontró el registro";
                    resp.Datos = null;
                    return Ok(resp);
                }
            }
            catch (Exception ex)
            {
                RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }
    }
}
