using AE_RA7_RBM.DTOs;
using AE_RA7_RBM.Models;
using AE_RA7_RBM.Services;
using Microsoft.AspNetCore.Mvc;

namespace AE_RA7_RBM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndicadoresController : ControllerBase
    {
        private readonly IndicadorService _indicadorService;
        private readonly ILogger<IndicadoresController> _logger;

        public IndicadoresController(
            IndicadorService indicadorService,
            ILogger<IndicadoresController> logger)
        {
            _indicadorService = indicadorService;
            _logger = logger;
        }

        // GET: api/indicadores
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Obteniendo todos los indicadores");

            var indicadores = _indicadorService.GetAll();
            return Ok(indicadores);
        }

        // GET: api/indicadores/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Obteniendo indicador con id {Id}", id);

            var indicador = _indicadorService.GetById(id);

            if (indicador == null)
            {
                return NotFound($"No existe ningún indicador con id {id}");
            }

            return Ok(indicador);
        }

        // GET: api/indicadores/tipo/{tipo}
        [HttpGet("tipo/{tipo}")]
        public IActionResult GetByTipo(string tipo)
        {
            _logger.LogInformation("Obteniendo indicadores de tipo {Tipo}", tipo);

            var indicadores = _indicadorService.GetByTipo(tipo);
            return Ok(indicadores);
        }

        // GET: api/indicadores/ambito/{ambito}
        [HttpGet("ambito/{ambito}")]
        public IActionResult GetByAmbito(string ambito)
        {
            _logger.LogInformation("Obteniendo indicadores de ámbito {Ambito}", ambito);

            var indicadores = _indicadorService.GetByAmbito(ambito);
            return Ok(indicadores);
        }

        // GET: api/indicadores/total-por-tipo
        [HttpGet("total-por-tipo")]
        public IActionResult GetTotalPorTipo()
        {
            _logger.LogInformation("Obteniendo total de indicadores por tipo");

            var resultado = _indicadorService.GetTotalPorTipo();
            return Ok(resultado);
        }

        // POST: api/indicadores
        [HttpPost]
        public IActionResult Create([FromBody] IndicadorDto indicadorDto)
        {
            _logger.LogInformation("Creando un nuevo indicador");
            var indicador = new Indicador
            {
                Tipo = indicadorDto.Tipo,
                Categoria = indicadorDto.Categoria,
                Nombre = indicadorDto.Nombre,
                Descripcion = indicadorDto.Descripcion,
                Valor = indicadorDto.Valor,
                Unidad = indicadorDto.Unidad,
                Fecha = indicadorDto.Fecha,
                Ambito = indicadorDto.Ambito
            };
            _indicadorService.Add(indicador);
            return Ok("Indicador creado correctamente");
        }

        // PUT: api/indicadores/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] IndicadorDto indicadorDto)
        {
            _logger.LogInformation("Actualizando indicador con id {Id}", id);

            var indicadorExistente = _indicadorService.GetById(id);
            if (indicadorExistente == null)
            {
                return NotFound($"No existe ningún indicador con id {id}");
            }

            indicadorExistente.Tipo = indicadorDto.Tipo;
            indicadorExistente.Categoria = indicadorDto.Categoria;
            indicadorExistente.Nombre = indicadorDto.Nombre;
            indicadorExistente.Descripcion = indicadorDto.Descripcion;
            indicadorExistente.Valor = indicadorDto.Valor;
            indicadorExistente.Unidad = indicadorDto.Unidad;
            indicadorExistente.Fecha = indicadorDto.Fecha;
            indicadorExistente.Ambito = indicadorDto.Ambito;

            _indicadorService.Update(indicadorExistente);
            return Ok("Indicador actualizado correctamente");
        }

        // DELETE: api/indicadores/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Eliminando indicador con id {Id}", id);

            var indicador = _indicadorService.GetById(id);
            if (indicador == null)
            {
                return NotFound($"No existe ningún indicador con id {id}");
            }

            _indicadorService.Delete(id);
            return Ok("Indicador eliminado correctamente");
        }
    }
}
