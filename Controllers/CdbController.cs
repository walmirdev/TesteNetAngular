using Microsoft.AspNetCore.Mvc;
using TesteNetAngular.Services.Interfaces;

namespace TesteNetAngular.Controllers
{
    [ApiController]
    [Route("/api/cdb")]
    public class CdbController : ControllerBase
    {

        private readonly ICdbService _service;

        public CdbController(ICdbService service)
        {
            _service = service;
        }

        [HttpGet]
        public CdbResult GetCDB([FromQuery] decimal valor, int prazo)
        {
            try
            {
                return _service.CalcCdb(valor, prazo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}