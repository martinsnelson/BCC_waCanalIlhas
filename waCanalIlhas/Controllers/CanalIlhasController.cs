using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using waCanalIlhas.DTO.Request.CanalIlhas;
using waCanalIlhas.DTO.Response.CanalIlhas;
using waCanalIlhas.Interface.Service;

namespace waCanalIlhas.Controllers
{
    [Route("v1/api/[controller]/[action]")]
    [ApiController]
    public class CanalIlhasController : ControllerBase
    {
        private readonly ICanalIlhasService _canalIlhasService;
        public CanalIlhasController(ICanalIlhasService canalIlhasService)
        {
            _canalIlhasService = canalIlhasService;
        }

        // GET v1/api/CanalIlhas
        [HttpGet]
        public ObterListaCasResponse ObterListaCas()
        {
            return _canalIlhasService.ObterListaCas();
        }

        // GET v1/api/CanalIlhas/
        [HttpGet("{pObterCasRequest}")]
        public ObterCasResponse ObterCas(int pObterCasRequest)
        {
            return _canalIlhasService.ObterCas(pObterCasRequest);
        }
    }
}