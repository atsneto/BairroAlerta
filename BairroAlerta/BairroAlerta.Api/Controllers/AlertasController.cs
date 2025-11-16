using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BairroAlerta.Api.Services;
using BairroAlerta.Api.Models;
using BairroAlerta.Api.Data;

namespace BairroAlerta.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasController : ControllerBase
    {
        private readonly AlertaContext _context;
        private readonly IDetectorService _detector;

        public AlertasController(AlertaContext context, IDetectorService detector)
        {
            _context = context;
            _detector = detector;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> Get()
        {
            return await _context.Alertas.ToListAsync();
        }

        [HttpPost("detectar")]
        public async Task<ActionResult<Alerta>> Detectar()
        {
            var alerta = _detector.GerarAlertaFake();
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();

            return Ok(alerta);
        }
    }
}
