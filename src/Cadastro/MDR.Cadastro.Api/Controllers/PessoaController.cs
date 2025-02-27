using Microsoft.AspNetCore.Mvc;

namespace MDR.Cadastro.Api.Controllers
{
    [ApiController]
    [Route("{tenant}/[controller]")]
    public class PessoaController : ControllerBase
    {
        [HttpGet("Pessoa/{id}")]
        public IEnumerable<object> Get(string id)
        {
            return default;
        }
    }
}
