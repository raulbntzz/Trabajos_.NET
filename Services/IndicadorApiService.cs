using AE_RA8_RBM.DTOs;
using System.Text;
using System.Text.Json;

namespace AE_RA8_RBM.Services
{
    public class IndicadorApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<IndicadorApiService> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public IndicadorApiService(HttpClient httpClient, ILogger<IndicadorApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<IndicadorDto>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Obteniendo todos los indicadores desde la API REST");
                var response = await _httpClient.GetAsync("indicadores");
                response.EnsureSuccessStatusCode();
                
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<IndicadorDto>>(content, _jsonOptions) ?? new List<IndicadorDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los indicadores desde la API REST");
                throw;
            }
        }

        public async Task<IndicadorDto?> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Obteniendo indicador {Id} desde la API REST", id);
                var response = await _httpClient.GetAsync($"indicadores/{id}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                
                response.EnsureSuccessStatusCode();
                
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IndicadorDto>(content, _jsonOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener indicador {Id} desde la API REST", id);
                throw;
            }
        }

        public async Task<List<IndicadorDto>> GetByTipoAsync(string tipo)
        {
            try
            {
                _logger.LogInformation("Obteniendo indicadores por tipo '{Tipo}' desde la API REST", tipo);
                var encodedTipo = Uri.EscapeDataString(tipo);
                var response = await _httpClient.GetAsync($"indicadores/tipo/{encodedTipo}");
                response.EnsureSuccessStatusCode();
                
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<IndicadorDto>>(content, _jsonOptions) ?? new List<IndicadorDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener indicadores por tipo '{Tipo}' desde la API REST", tipo);
                throw;
            }
        }

        public async Task<List<IndicadorDto>> GetByAmbitoAsync(string ambito)
        {
            try
            {
                _logger.LogInformation("Obteniendo indicadores por ámbito '{Ambito}' desde la API REST", ambito);
                var encodedAmbito = Uri.EscapeDataString(ambito);
                var response = await _httpClient.GetAsync($"indicadores/ambito/{encodedAmbito}");
                response.EnsureSuccessStatusCode();
                
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<IndicadorDto>>(content, _jsonOptions) ?? new List<IndicadorDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener indicadores por ámbito '{Ambito}' desde la API REST", ambito);
                throw;
            }
        }

        public async Task<Dictionary<string, int>> GetTotalPorTipoAsync()
        {
            try
            {
                _logger.LogInformation("Obteniendo totales por tipo desde la API REST");
                var response = await _httpClient.GetAsync("indicadores/total-por-tipo");
                response.EnsureSuccessStatusCode();
                
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Dictionary<string, int>>(content, _jsonOptions) ?? new Dictionary<string, int>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener totales por tipo desde la API REST");
                throw;
            }
        }

        public async Task<bool> CreateAsync(IndicadorDto indicador)
        {
            try
            {
                _logger.LogInformation("Creando nuevo indicador mediante la API REST");
                var json = JsonSerializer.Serialize(indicador);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("indicadores", content);
                response.EnsureSuccessStatusCode();
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear indicador mediante la API REST");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(int id, IndicadorDto indicador)
        {
            try
            {
                _logger.LogInformation("Actualizando indicador {Id} mediante la API REST", id);
                var json = JsonSerializer.Serialize(indicador);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PutAsync($"indicadores/{id}", content);
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return false;
                
                response.EnsureSuccessStatusCode();
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar indicador {Id} mediante la API REST", id);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Eliminando indicador {Id} mediante la API REST", id);
                var response = await _httpClient.DeleteAsync($"indicadores/{id}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return false;
                
                response.EnsureSuccessStatusCode();
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar indicador {Id} mediante la API REST", id);
                throw;
            }
        }
    }
}
