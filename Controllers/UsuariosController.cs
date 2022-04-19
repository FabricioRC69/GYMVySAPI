using GYM_VidaYSalud.Entities;
using GYM_VidaYSalud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GYM_VidaYSalud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        UsuariosModel model = new UsuariosModel();
        private readonly IConfiguration _configuration;

        public UsuariosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        [Route("/api/Proyecto/ConsultarLogin")]
        public ActionResult<RespuestaDatosUsuarios> ConsultarLogin(string Correo, string Contraseña)
        {
            try
            {
                var respuesta = model.Consultalogin(Correo, Contraseña, _configuration.GetSection("Llaves:DefaultConnection").Value);

                var idUsuario = model.ComprobarUsuarioPorCorreo(Correo, _configuration.GetSection("Llaves:DefaultConnection").Value);

                if (new EmailAddressAttribute().IsValid(Correo))
                {
                    if (idUsuario != null)
                    {
                        model.RegistraBitacoraRegistroYLogin(idUsuario.idUsuario, Correo, "Credenciales incorrectas. Cod: E-400", _configuration.GetSection("Llaves:DefaultConnection").Value);
                    }
                }
                else
                {

                    RespuestaDatosUsuarios respu = new RespuestaDatosUsuarios();
                    respu.Mensaje = "Correo invalido";
                    respu.Datos = null;
                    return BadRequest(respu);
                }
                if(respuesta == null)
                {
                    RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                    resp.Mensaje = "Correo o contraseña incorrectos";
                    resp.Datos = respuesta;
                    return Ok(resp);
               
                } else
                {
                    RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                    resp.Mensaje = "Consulta correcta";
                    resp.Datos = respuesta;
                    return Ok(resp);
                }
              
            }
            catch (Exception ex)
            {
                var idUsuario = model.ComprobarUsuarioPorCorreo(Correo, _configuration.GetSection("Llaves:DefaultConnection").Value);
                RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                model.RegistraBitacoraRegistroYLogin(idUsuario.idUsuario, Correo, ex.Message, _configuration.GetSection("Llaves:DefaultConnection").Value);
                return BadRequest(resp);
            }
        }

        [HttpPost]
        [Route("/api/Proyecto/RegistrarUsuario")]
        public ActionResult<RespuestaDatosUsuarios> RegistrarUsuario(UsuariosObj usuario)
        {
            try
            {
                
                model.RegistraUsuario(usuario, _configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                resp.Mensaje = "Usuario registrado con exito";
                resp.Datos = null;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }
    }
}
