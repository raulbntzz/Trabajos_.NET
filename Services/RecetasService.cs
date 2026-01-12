using RecetasCocina_AE4.Datos;
using RecetasCocina_AE4.Datos.Repositorios;
using RecetasCocina_AE4.DTOs;
using RecetasCocina_AE4.Models;
using Microsoft.EntityFrameworkCore;

namespace RecetasCocina_AE4.Services
{
    public class RecetasService : IRecetasService
    {
        private readonly IRecetaRepository recetaRepository;
        private readonly ApplicationDbContext context;

        public RecetasService(IRecetaRepository recetaRepository, ApplicationDbContext context)
        {
            this.recetaRepository = recetaRepository;
            this.context = context;
        }

        public async Task<IEnumerable<RecetaDto>> ObtenerRecetasUsuario(string usuarioId)
        {
            var recetas = await recetaRepository.GetAllByUserIdAsync(usuarioId);
            return recetas.Select(MapToDto);
        }

        public async Task<RecetaDto?> ObtenerRecetaPorId(int id, string usuarioId)
        {
            var receta = await recetaRepository.GetByIdAsync(id, usuarioId);
            return receta != null ? MapToDto(receta) : null;
        }

        public async Task CrearReceta(RecetaDto recetaDto, string usuarioId)
        {
            var receta = new Receta
            {
                Nombre = recetaDto.Nombre,
                Descripcion = recetaDto.Descripcion,
                Preparacion = recetaDto.Preparacion,
                TiempoPreparacionMinutos = recetaDto.TiempoPreparacionMinutos,
                Porciones = recetaDto.Porciones,
                ImagenUrl = recetaDto.ImagenUrl,
                FechaCreacion = DateTime.UtcNow,
                UsuarioId = usuarioId
            };

            await recetaRepository.CreateAsync(receta);
        }

        public async Task ActualizarReceta(RecetaDto recetaDto, string usuarioId)
        {
            var receta = await recetaRepository.GetByIdAsync(recetaDto.Id, usuarioId);
            if (receta == null)
                throw new InvalidOperationException("Receta no encontrada");

            receta.Nombre = recetaDto.Nombre;
            receta.Descripcion = recetaDto.Descripcion;
            receta.Preparacion = recetaDto.Preparacion;
            receta.TiempoPreparacionMinutos = recetaDto.TiempoPreparacionMinutos;
            receta.Porciones = recetaDto.Porciones;
            receta.ImagenUrl = recetaDto.ImagenUrl;

            await recetaRepository.UpdateAsync(receta);
        }

        public async Task EliminarReceta(int id, string usuarioId)
        {
            await recetaRepository.DeleteAsync(id, usuarioId);
        }

        public async Task<bool> AgregarIngrediente(int recetaId, int ingredienteId, string cantidad, string usuarioId)
        {
            var receta = await recetaRepository.GetByIdAsync(recetaId, usuarioId);
            if (receta == null)
                return false;

            var existeRelacion = await context.RecetaIngredientes
                .AnyAsync(ri => ri.RecetaId == recetaId && ri.IngredienteId == ingredienteId);

            if (existeRelacion)
                return false;

            var recetaIngrediente = new RecetaIngrediente
            {
                RecetaId = recetaId,
                IngredienteId = ingredienteId,
                Cantidad = cantidad
            };

            context.RecetaIngredientes.Add(recetaIngrediente);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarIngrediente(int recetaId, int ingredienteId, string usuarioId)
        {
            var receta = await recetaRepository.GetByIdAsync(recetaId, usuarioId);
            if (receta == null)
                return false;

            var recetaIngrediente = await context.RecetaIngredientes
                .FirstOrDefaultAsync(ri => ri.RecetaId == recetaId && ri.IngredienteId == ingredienteId);

            if (recetaIngrediente == null)
                return false;

            context.RecetaIngredientes.Remove(recetaIngrediente);
            await context.SaveChangesAsync();
            return true;
        }

        private RecetaDto MapToDto(Receta receta)
        {
            return new RecetaDto
            {
                Id = receta.Id,
                Nombre = receta.Nombre,
                Descripcion = receta.Descripcion,
                Preparacion = receta.Preparacion,
                TiempoPreparacionMinutos = receta.TiempoPreparacionMinutos,
                Porciones = receta.Porciones,
                ImagenUrl = receta.ImagenUrl,
                FechaCreacion = receta.FechaCreacion,
                Ingredientes = receta.RecetaIngredientes.Select(ri => new IngredienteRecetaDto
                {
                    IngredienteId = ri.IngredienteId,
                    NombreIngrediente = ri.Ingrediente?.Nombre ?? "",
                    Cantidad = ri.Cantidad
                }).ToList()
            };
        }
    }
}
