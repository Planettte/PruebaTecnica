using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

[Route("api/[controller]")]
[ApiController]
public class EvaluacionesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EvaluacionesController(AppDbContext context)
    {
        _context = context;
    }

    // Obtener evaluaciones por curso
    [HttpGet("curso/{cursoId}")]
    public async Task<IActionResult> GetEvaluacionesPorCurso(int cursoId)
    {
        var evaluaciones = await _context.Evaluaciones
            .Where(e => e.CursoId == cursoId)
            .ToListAsync();

        return Ok(evaluaciones);
    }

    // Obtener preguntas de una evaluación
    [HttpGet("{evaluacionId}")]
    public async Task<IActionResult> GetPreguntasDeEvaluacion(int evaluacionId)
    {
        var evaluacion = await _context.Evaluaciones
            .Include(e => e.Pregunta)
            .ThenInclude(p => p.Respuesta)
            .FirstOrDefaultAsync(e => e.EvaluacionId == evaluacionId);

        if (evaluacion == null)
        {
            return NotFound("Evaluación no encontrada.");
        }

        return Ok(evaluacion.Pregunta);
    }

    // Guardar intento de evaluación
    [HttpPost("intento")]
    public async Task<IActionResult> GuardarIntento([FromBody] Intentos intento)
    {
        _context.Intentos.Add(intento);
        await _context.SaveChangesAsync();
        return Ok(intento);
    }

    // Obtener historial de evaluaciones de un usuario
    [HttpGet("historial/{usuarioId}")]
    public async Task<IActionResult> GetHistorialEvaluaciones(int usuarioId)
    {
        var historial = await _context.Intentos
            .Where(i => i.UsuarioId == usuarioId)
            .Include(i => i.Evaluacion)
            .ToListAsync();

        return Ok(historial);
    }
}
