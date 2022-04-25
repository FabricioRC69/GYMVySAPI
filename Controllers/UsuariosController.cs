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
        [Route("/api/Proyecto/ConsultarUsuarios")]
        public ActionResult<RespuestaDatosUsuarios> ConsultarUsuarios()
        {
            try
            {
                var respuesta = model.ConsultarUsuarios(_configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                resp.Mensaje = "Consulta correcta";
                resp.ListaDatos = respuesta;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                resp.Mensaje = ex.Message;
                resp.ListaDatos = null;
                return BadRequest(resp);
            }
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
        [HttpGet]
        [Route("/api/Proyecto/ConsultarUnUsuario")]
        public ActionResult<RespuestaDatosUsuarios> ConsultarUnUsuario(long idUsuario)
        {
            try
            {
                var respuesta = model.ConsultarUnUsuario(idUsuario, _configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                resp.Mensaje = "Consulta correcta";
                resp.Datos = respuesta;
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

        [HttpPut]
        [Route("/api/Proyecto/ModificarUsuario")]
        public ActionResult<RespuestaDatosUsuarios> ActualizarUsuario(UsuariosObj usuario)
        {
            try
            {
                var respuesta = model.ConsultarUnUsuario(usuario.idUsuario, _configuration.GetSection("Llaves:DefaultConnection").Value);

                if (respuesta != null)
                {
                    model.ModificarUsuario(usuario, _configuration.GetSection("Llaves:DefaultConnection").Value);

                    RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                    resp.Mensaje = "Se modificaron los datos con exito";
                    resp.Datos = null;
                    return Ok(resp);
                }
                else
                {
                    RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                    resp.Mensaje = "No se encontró el registro";
                    resp.Datos = null;
                    return Ok(resp);
                }
            }
            catch (Exception ex)
            {
                RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }
        [HttpPut]
        [Route("/api/Proyecto/ModificarUsuarioSinPermisos")]
        public ActionResult<RespuestaDatosUsuarios> ActualizarUsuarioSinPermisos(UsuariosObjSinPermisos usuario)
        {
            try
            {
                var respuesta = model.ConsultarUnUsuario(usuario.idUsuario, _configuration.GetSection("Llaves:DefaultConnection").Value);

                if (respuesta != null)
                {
                    model.ModificarUsuarioSinPermisos(usuario, _configuration.GetSection("Llaves:DefaultConnection").Value);

                    RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                    resp.Mensaje = "Se modificaron los datos con exito";
                    resp.Datos = null;
                    return Ok(resp);
                }
                else
                {
                    RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                    resp.Mensaje = "No se encontró el registro";
                    resp.Datos = null;
                    return Ok(resp);
                }
            }
            catch (Exception ex)
            {
                RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }
        [HttpDelete]
        [Route("/api/Proyecto/EliminarUsuario")]
        public ActionResult<RespuestaDatosUsuarios> EliminarUsuario(long idUsuario)
        {
            try
            {
                var cliente = model.ConsultarUnUsuario(idUsuario, _configuration.GetSection("Llaves:DefaultConnection").Value);

                if (cliente != null)
                {
                    model.EliminarUsuario(idUsuario, _configuration.GetSection("Llaves:DefaultConnection").Value);

                    RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                    resp.Mensaje = "Se eliminó el usuario con exito";
                    resp.Datos = null;
                    return Ok(resp);
                }
                else
                {
                    RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
                    resp.Mensaje = "No se encontró el registro";
                    resp.Datos = null;
                    return Ok(resp);
                }
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
