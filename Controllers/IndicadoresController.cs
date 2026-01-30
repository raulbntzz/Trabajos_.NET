using AE_RA8_RBM.DTOs;
using AE_RA8_RBM.Models;
using AE_RA8_RBM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AE_RA8_RBM.Controllers
{
    public class IndicadoresController : Controller
    {
        private readonly IndicadorApiService _apiService;
        private readonly ILogger<IndicadoresController> _logger;

        public IndicadoresController(IndicadorApiService apiService, ILogger<IndicadoresController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        // GET: Indicadores - Listado completo
        public async Task<IActionResult> Index()
        {
            try
            {
                var indicadores = await _apiService.GetAllAsync();
                ViewBag.Mensaje = "Listado completo de indicadores obtenidos desde la API REST";
                return View(indicadores);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener indicadores");
                TempData["Error"] = "Error al conectar con la API: " + ex.Message;
                return View(new List<IndicadorDto>());
            }
        }

        // GET: Indicadores/Filtros - Aplicar filtros
        public async Task<IActionResult> Filtros(string? tipo, string? ambito)
        {
            try
            {
                // SIEMPRE obtener todos los indicadores para poblar los selectores
                var todosIndicadores = await _apiService.GetAllAsync();
                ViewBag.Tipos = todosIndicadores.Select(i => i.Tipo).Distinct().OrderBy(t => t).ToList();
                ViewBag.Ambitos = todosIndicadores.Select(i => i.Ambito).Distinct().OrderBy(a => a).ToList();
                
                // Obtener indicadores según el filtro aplicado
                List<IndicadorDto> indicadores;

                if (!string.IsNullOrEmpty(tipo))
                {
                    indicadores = await _apiService.GetByTipoAsync(tipo);
                    ViewBag.FiltroAplicado = $"Tipo: {tipo}";
                    ViewBag.TipoSeleccionado = tipo;
                }
                else if (!string.IsNullOrEmpty(ambito))
                {
                    indicadores = await _apiService.GetByAmbitoAsync(ambito);
                    ViewBag.FiltroAplicado = $"Ámbito: {ambito}";
                    ViewBag.AmbitoSeleccionado = ambito;
                }
                else
                {
                    indicadores = todosIndicadores;
                    ViewBag.FiltroAplicado = "Sin filtros aplicados";
                }

                return View(indicadores);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al filtrar indicadores");
                TempData["Error"] = "Error al aplicar filtros: " + ex.Message;
                return View(new List<IndicadorDto>());
            }
        }

        // GET: Indicadores/Resumen - Mostrar resúmenes y estadísticas
        public async Task<IActionResult> Resumen()
        {
            try
            {
                var indicadores = await _apiService.GetAllAsync();
                var totalPorTipo = await _apiService.GetTotalPorTipoAsync();

                var resumen = new ResumenIndicadores
                {
                    TotalIndicadores = indicadores.Count,
                    TotalPorTipo = totalPorTipo,
                    TotalPorAmbito = indicadores
                        .GroupBy(i => i.Ambito)
                        .ToDictionary(g => g.Key, g => g.Count()),
                    TotalPorCategoria = indicadores
                        .GroupBy(i => i.Categoria)
                        .ToDictionary(g => g.Key, g => g.Count())
                };

                ViewBag.IndicadoresRecientes = indicadores
                    .OrderByDescending(i => i.Fecha)
                    .Take(5)
                    .ToList();

                return View(resumen);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener resumen");
                TempData["Error"] = "Error al obtener resumen: " + ex.Message;
                return View(new ResumenIndicadores());
            }
        }

        // GET: Indicadores/Create
        public IActionResult Create()
        {
            var indicador = new IndicadorDto
            {
                Fecha = DateTime.Now
            };
            return View(indicador);
        }

        // POST: Indicadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IndicadorDto indicador)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.CreateAsync(indicador);
                    TempData["Success"] = "Indicador creado correctamente mediante la API REST";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al crear indicador");
                    ModelState.AddModelError("", "Error al crear el indicador: " + ex.Message);
                }
            }
            return View(indicador);
        }

        // GET: Indicadores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var indicador = await _apiService.GetByIdAsync(id);
                if (indicador == null)
                {
                    TempData["Error"] = $"No se encontró el indicador con ID {id}";
                    return RedirectToAction(nameof(Index));
                }
                return View(indicador);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener indicador para editar");
                TempData["Error"] = "Error al obtener el indicador: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Indicadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IndicadorDto indicador)
        {
            if (id != indicador.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var resultado = await _apiService.UpdateAsync(id, indicador);
                    if (!resultado)
                    {
                        TempData["Error"] = $"No se encontró el indicador con ID {id}";
                        return RedirectToAction(nameof(Index));
                    }
                    TempData["Success"] = "Indicador actualizado correctamente mediante la API REST";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al actualizar indicador");
                    ModelState.AddModelError("", "Error al actualizar el indicador: " + ex.Message);
                }
            }
            return View(indicador);
        }

        // GET: Indicadores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var indicador = await _apiService.GetByIdAsync(id);
                if (indicador == null)
                {
                    TempData["Error"] = $"No se encontró el indicador con ID {id}";
                    return RedirectToAction(nameof(Index));
                }
                return View(indicador);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener indicador para eliminar");
                TempData["Error"] = "Error al obtener el indicador: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Indicadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var resultado = await _apiService.DeleteAsync(id);
                if (!resultado)
                {
                    TempData["Error"] = $"No se encontró el indicador con ID {id}";
                }
                else
                {
                    TempData["Success"] = "Indicador eliminado correctamente mediante la API REST";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar indicador");
                TempData["Error"] = "Error al eliminar el indicador: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Indicadores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var indicador = await _apiService.GetByIdAsync(id);
                if (indicador == null)
                {
                    TempData["Error"] = $"No se encontró el indicador con ID {id}";
                    return RedirectToAction(nameof(Index));
                }
                return View(indicador);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener detalles del indicador");
                TempData["Error"] = "Error al obtener los detalles: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
