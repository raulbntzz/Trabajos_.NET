using RecetasCocina_AE4.Datos.Repositorios;
using RecetasCocina_AE4.DTOs;
using RecetasCocina_AE4.Models;

namespace RecetasCocina_AE4.Services
{
    public class IngredientesService : IIngredientesService
    {
        private readonly IIngredienteRepository ingredienteRepository;

        public IngredientesService(IIngredienteRepository ingredienteRepository)
        {
            this.ingredienteRepository = ingredienteRepository;
        }

        public async Task<IEnumerable<IngredienteDto>> ObtenerIngredientesUsuario(string usuarioId)
        {
            var ingredientes = await ingredienteRepository.GetAllByUserIdAsync(usuarioId);
            return ingredientes.Select(MapToDto);
        }

        public async Task<IngredienteDto?> ObtenerIngredientePorId(int id, string usuarioId)
        {
            var ingrediente = await ingredienteRepository.GetByIdAsync(id, usuarioId);
            return ingrediente != null ? MapToDto(ingrediente) : null;
        }

        public async Task CrearIngrediente(IngredienteDto ingredienteDto, string usuarioId)
        {
            var ingrediente = new Ingrediente
            {
                Nombre = ingredienteDto.Nombre,
                Categoria = ingredienteDto.Categoria,
                UsuarioId = usuarioId
            };

            await ingredienteRepository.CreateAsync(ingrediente);
        }

        public async Task ActualizarIngrediente(IngredienteDto ingredienteDto, string usuarioId)
        {
            var ingrediente = await ingredienteRepository.GetByIdAsync(ingredienteDto.Id, usuarioId);
            if (ingrediente == null)
                throw new InvalidOperationException("Ingrediente no encontrado");

            ingrediente.Nombre = ingredienteDto.Nombre;
            ingrediente.Categoria = ingredienteDto.Categoria;

            await ingredienteRepository.UpdateAsync(ingrediente);
        }

        public async Task EliminarIngrediente(int id, string usuarioId)
        {
            await ingredienteRepository.DeleteAsync(id, usuarioId);
        }

        private IngredienteDto MapToDto(Ingrediente ingrediente)
        {
            return new IngredienteDto
            {
                Id = ingrediente.Id,
                Nombre = ingrediente.Nombre,
                Categoria = ingrediente.Categoria
            };
        }
    }
}
