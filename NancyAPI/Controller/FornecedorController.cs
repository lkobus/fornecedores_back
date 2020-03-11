using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using NancyAPI.DTO;
using Newtonsoft.Json;
using Ninject;

namespace NancyAPI.Controller
{
    [Route("api/fornecedor")]
    [ApiController]
    public class FornecedorController
    {
        private IFornecedorService _fornecedorService;

        public FornecedorController()
        {
            _fornecedorService = Startup.NINJECT.Get<IFornecedorService>();
        }

        [HttpPost]
        [Route("fisica")]
        public ActionResult<string> RegisterPessoaFisica(FornecedorFisicaDTO dto)
        {
            _fornecedorService.CreatePessoaFisica(dto);
            return "ok";
        }

        [HttpPost]
        [Route("juridica")]
        public ActionResult<string>RegisterPessoaJuridica(FornecedorJuridicaDTO dto)
        {
            _fornecedorService.CreatePessoaJuridica(dto);
            return "ok";
        }

        [HttpPost]
        [Route("search")]
        public ActionResult<string>SearchFilterFornecedor(FilterFornecedorDTO filter)
        {
            var result = new List<FornecedorFisicaDTO>();
            if(filter.Nome != null && filter.Date != DateTime.MinValue){
                result = _fornecedorService.FetchByDateAndNome(filter.Nome, filter.Date)
                .Select(p => new FornecedorFisicaDTO(p)).ToList();
            } else if(filter.Date != DateTime.MinValue){
                result = _fornecedorService.FetchByDate(filter.Date)
                .Select(p => new FornecedorFisicaDTO(p)).ToList();
            } else if(filter.Nome != null){
                result = _fornecedorService.FetchByNome(filter.Nome)
                .Select(p => new FornecedorFisicaDTO(p)).ToList();
            }
            return JsonConvert.SerializeObject(result);
        }


        [HttpGet]
        public ActionResult<string> GetAll()
        {
            return JsonConvert.SerializeObject(
                _fornecedorService.FetchAll().Select(p => new FornecedorFisicaDTO(p))
            );
        }
    }
}