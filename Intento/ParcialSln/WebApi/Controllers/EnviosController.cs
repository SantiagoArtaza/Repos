using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Models;
using WebApi.Repository;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IEnvioService _service;
        public EnviosController(IEnvioService envioService)
        {
            _service = envioService;
        }
        [HttpGet]
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
        [HttpGet("/Fechas")]
        public IActionResult GetFechas([Required]DateTime fecDesde, [Required]DateTime fecHasta)
        {
            try
            {
                var result = _service.GetEnvios(fecDesde, fecHasta);
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
        public IActionResult PutEnvio(int id, Envio envio)
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
    }
}
