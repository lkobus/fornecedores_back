using System.Linq;
using System.Threading.Tasks;
using Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NancyAPI.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ninject;

namespace NancyAPI.Controller
{
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private IEmpresaService _empresaService;
        public EmpresaController()
        {
            _empresaService = Startup.NINJECT.Get<IEmpresaService>();
        }

        [HttpPost]
        public ActionResult<string> Register(EmpresaDTO dto)
        {
            _empresaService.CreateEmpresa(dto);
            return "ok";
        }


        [HttpGet]
        public ActionResult<string> GetAll()
        {
            return JsonConvert.SerializeObject(
                _empresaService.FetchAll().Select(p => new EmpresaDTO(p))
            );
        }
    }
}