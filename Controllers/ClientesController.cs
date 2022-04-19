﻿using GYM_VidaYSalud.Entities;
using GYM_VidaYSalud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_VidaYSalud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        ClientesModel model = new ClientesModel();
        private readonly IConfiguration _configuration;

        public ClientesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/api/Proyecto/ConsultarTodosClientes")]
        public ActionResult<RespuestaDatosClientes> ConsultarClientes()
        {
            try
            {
                var respuesta = model.ConsultarClientes(_configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosClientes resp = new RespuestaDatosClientes();
                resp.Mensaje = "Consulta correcta";
                resp.ListaDatos = respuesta;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosClientes resp = new RespuestaDatosClientes();
                resp.Mensaje = ex.Message;
                resp.ListaDatos = null;
                return BadRequest(resp);
            }
        }

        [HttpGet]
        [Route("/api/Proyecto/ConsultarUnCliente")]
        public ActionResult<RespuestaDatosClientes> ConsultarUnCliente(string Cedula)
        {
            try
            {
                var respuesta = model.ConsultarUnCliente(Cedula, _configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosClientes resp = new RespuestaDatosClientes();
                resp.Mensaje = "Consulta correcta";
                resp.Datos = respuesta;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosClientes resp = new RespuestaDatosClientes();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }

        [HttpPost]
        [Route("/api/Proyecto/RegistrarCliente")]
        public ActionResult<RespuestaDatosClientes> RegistrarCliente(ClientesObj cliente)
        {
            try
            {
                model.RegistrarCliente(cliente,
                    _configuration.GetSection("Llaves:DefaultConnection").Value);

                RespuestaDatosClientes resp = new RespuestaDatosClientes();
                resp.Mensaje = "Cliente registrado con exito";
                resp.Datos = null;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                RespuestaDatosClientes resp = new RespuestaDatosClientes();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }
        
        [HttpPut]
        [Route("/api/Proyecto/ModificarCliente")]
        public ActionResult<RespuestaDatosClientes> Actualizar(string Cedula, string NombreCompleto, string NumContacto, string Correo)
        {
            try
            {
                var cliente = model.ConsultarUnCliente(Cedula, _configuration.GetSection("Llaves:DefaultConnection").Value);

                if (cliente != null)
                {
                    model.ModificarCliente(Cedula, NombreCompleto, NumContacto, Correo, _configuration.GetSection("Llaves:DefaultConnection").Value);

                    RespuestaDatosClientes resp = new RespuestaDatosClientes();
                    resp.Mensaje = "Se modificaron los datos con exito";
                    resp.Datos = null;
                    return Ok(resp);
                }
                else
                {
                    RespuestaDatosClientes resp = new RespuestaDatosClientes();
                    resp.Mensaje = "No se encontró el registro";
                    resp.Datos = null;
                    return Ok(resp);
                }
            }
            catch (Exception ex)
            {
                RespuestaDatosClientes resp = new RespuestaDatosClientes();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }

        [HttpDelete]
        [Route("/api/Proyecto/EliminarCliente")]
        public ActionResult<RespuestaDatosClientes> EliminarCliente(string Cedula)
        {
            try
            {
                var cliente = model.ConsultarUnCliente(Cedula, _configuration.GetSection("Llaves:DefaultConnection").Value);

                if (cliente != null)
                {
                    model.EliminarCliente(Cedula, _configuration.GetSection("Llaves:DefaultConnection").Value);

                    RespuestaDatosClientes resp = new RespuestaDatosClientes();
                    resp.Mensaje = "Se eliminó el cliente con exito";
                    resp.Datos = null;
                    return Ok(resp);
                }
                else
                {
                    RespuestaDatosClientes resp = new RespuestaDatosClientes();
                    resp.Mensaje = "No se encontró el registro";
                    resp.Datos = null;
                    return Ok(resp);
                }
            }
            catch (Exception ex)
            {
                RespuestaDatosClientes resp = new RespuestaDatosClientes();
                resp.Mensaje = ex.Message;
                resp.Datos = null;
                return BadRequest(resp);
            }
        }

    }
}
