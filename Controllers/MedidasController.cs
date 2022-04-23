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
        public ActionResult<RespuestaDatosMedidas> ConsultarMedidas()
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
        public ActionResult<RespuestaDatosMedidas> ConsultarMedidaPersona(long idMedidas)
        {
            try
            {
                var respuesta = model.ConsultarUnaMedida(idMedidas, _configuration.GetSection("Llaves:DefaultConnection").Value);

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
        public ActionResult<RespuestaDatosMedidas> RegistrarMedida(MedidasObj medida)
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
        public ActionResult<RespuestaDatosMedidas> Actualizar(MedidasObj medida)
        {
            try
            {
                model.ModificarMedida(medida,
                    _configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
                resp.Mensaje = "Medida Actualizada con exito";
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

        [HttpGet]
        [Route("/api/Proyecto/MedidaSelectList")]
        public ActionResult<RespuestaDatosMedidaSelectList> MedidaSelectList()
        {
            try
            {
                var respuesta = model.ConsultarMedidaSelectList(_configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosMedidaSelectList resp = new RespuestaDatosMedidaSelectList();
                resp.Mensaje = "Consulta correcta";
                resp.ListaDatos = respuesta;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosMedidaSelectList resp = new RespuestaDatosMedidaSelectList();
                resp.Mensaje = ex.Message;
                resp.ListaDatos = null;
                return BadRequest(resp);
            }
        }
        [HttpGet]
        [Route("/api/Proyecto/MedidaSelectListAll")]
        public ActionResult<RespuestaDatosMedidaSelectList> MedidaSelectListAll(long idCliente)
        {
            try
            {
                var respuesta = model.ConsultarMedidaSelectListAll(idCliente, _configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosMedidaSelectList resp = new RespuestaDatosMedidaSelectList();
                resp.Mensaje = "Consulta correcta";
                resp.ListaDatos = respuesta;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosMedidaSelectList resp = new RespuestaDatosMedidaSelectList();
                resp.Mensaje = ex.Message;
                resp.ListaDatos = null;
                return BadRequest(resp);
            }
        }
    }
}
