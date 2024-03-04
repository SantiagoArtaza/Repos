using Back.Dominio;
using Back.Fachada.Implementacion;
using Back.Fachada.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurnoController : ControllerBase
    {
        private IAplicacion DataApi;

        public TurnoController()
        {
            DataApi = new Aplicacion();
        }

        [HttpGet("/medicos")]
        public IActionResult GetMedicos()
        {
            List<Medico> lst = null;
            try
            {
                lst = DataApi.GetMedicos();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/turnos")]
        public IActionResult PostTurnos(Turno turno)
        {
            try
            {
                if(turno == null)
                {
                    return BadRequest("Error en los datos");
                }
                return Ok(DataApi.SaveTurno(turno));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }

        }


        [HttpGet("/ConsultaExistente")]

        public IActionResult GetExiste(string fecha, string hora, int matricula) 
        {
            try
            {
              if (fecha == null ||hora ==null || matricula==null)
                {
                    return BadRequest("Error en los datos");
                }
                return Ok(DataApi.GetTurno(fecha,hora, matricula));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }



        }
    }
}