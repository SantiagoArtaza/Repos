using Microsoft.AspNetCore.Mvc;
using WebApi.Aplicacion;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IAplicacion _repository;

        public EnviosController(IAplicacion repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var result = _repository.GetAll();
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
