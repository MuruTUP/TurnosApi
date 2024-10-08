using Microsoft.AspNetCore.Mvc;
using PeluqueriaServiciosApi.Data.Models;
using PeluqueriaServiciosApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeluqueriaServiciosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnosRepository _repository;
        public TurnoController(ITurnosRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<TurnoController>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno.");
            }
        }

        // GET api/<TurnoController>/5
        [HttpGet("Search by ID")]
        public IActionResult GetById(int id)
        {
            try
            {
                var turnoEncontrado = _repository.GetById(id);
                if (turnoEncontrado != null)
                {
                    return Ok(turnoEncontrado);
                }
                return NotFound("No se ha encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno.");
            }
        }


        [HttpGet("Get By Cliente")]
        public IActionResult GetByCliente(string usuario)
        {
            try
            {
                var turnosEncontrados = _repository.GetByCliente(usuario);
                if (turnosEncontrados != null)
                {
                    return Ok(turnosEncontrados);
                }
                return NotFound("No se han encontrado turnos, o no existe el usuario");
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno.");
            }
        }

        // POST api/<TurnoController>
        [HttpPost("Crear Turno")]
        public IActionResult Post([FromBody] TTurno oTurno)
        {
            try
            {
                if (_repository.Create(oTurno))
                {
                    return Ok("Creado con éxito");
                }
                return BadRequest("Revise los datos ingresados");
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno.");
            }
        }

        // PUT api/<TurnoController>/5
        [HttpPut("Actualizar datos")]
        public IActionResult Put(int id, TTurno oTurno)
        {
            try
            {
                if (_repository.Update(id, oTurno))
                {
                    return Ok("Información actualizada con éxito");
                }
                return BadRequest("Hubo un error. Revise los datos nuevamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno.");
            }
        }

        // DELETE api/<TurnoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_repository.Delete(id))
                {
                    return Ok("Turno cancelado con éxito");
                }
                return BadRequest("Todo mal, no encontramos el turno, o el turno ya fué cancelado. Vofi");
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno.");
            }
        }
    }
}
