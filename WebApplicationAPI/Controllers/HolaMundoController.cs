using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Services;

namespace WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class HolaMundoController : ControllerBase
    {
        IHolaMundoService HolaMundoService;

        TareaContext dbContext;

        private readonly ILogger<HolaMundoController> _logger;

        public HolaMundoController(ILogger<HolaMundoController> logger, IHolaMundoService holaMundoService,
                                   TareaContext dbContext)
        {
            _logger = logger;
            HolaMundoService = holaMundoService;
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            _logger.LogDebug("Retornando en controller hola mundo");
            return Ok(HolaMundoService.GetHolaMundo());
        }

        [HttpGet]
        [Route("creaciondb")]
        public IActionResult CreacionDb()
        {
            dbContext.Database.EnsureCreated();

            return Ok();
        }
    }
}
