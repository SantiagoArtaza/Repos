using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Xnacion1.Repository;
using Xnacion1.Service;

namespace Xnacion1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnviosController : ControllerBase
    {
        private readonly IService _service;
        public EnviosController(IService serv)
        {
            _service = serv;
        }


        [HttpGet("/obtenerEnvios")]

        public ActionResult GetAll()
        {
            try
            {
                var result = _service.GetAll();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error interno: " + ex.Message);
            }
        }
        [HttpGet("/obtenerEnviosFiltrados")]

        public ActionResult GetbyDate([Required] DateTime fecDesde, [Required] DateTime fecHasta)
        {
            try
            {
                var result = _service.GetEnvios(fecDesde,fecHasta);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error interno: " + ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutEnvio(int id, TEnvio envio)
        {
            try
            {
                var result = _service.Update(id, envio);
                if (result)
                {
                    return Ok("Se modificó correctamente :) ");
                }
                return BadRequest("No se pudo modificar");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error interno: " + ex.Message);
            }



        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEnvio(int id )
        {
            try
            {
                var result = _service.DeleteEnvio(id);
                if (result)
                {
                    return Ok("Se Elimino correctamente:) ");
                }
                return BadRequest("No se pudo Elminar");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error interno: " + ex.Message);
            }



        }
        [HttpPost("Crear Envio")]
        public IActionResult CrearEnvio(TEnvio envio)
        {
            try
            {
                var result = _service.CrearEnvio(envio);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error interno: " + ex.Message);
            }



        }
    } 
}
