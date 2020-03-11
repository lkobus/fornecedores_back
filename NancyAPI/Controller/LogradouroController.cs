using ListagemFornecedores.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace NancyAPI.Controller
{
    [Route("api/logradouro")]
    [ApiController]
    public class LogradouroController : ControllerBase
    {

        public LogradouroController()
        {
        }

        [HttpGet]
        public ActionResult<string> GetAll()
        {
            return JsonConvert.SerializeObject(UFEnum.ToList());
        }
    }
}