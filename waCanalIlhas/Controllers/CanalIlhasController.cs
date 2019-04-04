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

        // GET v1/api/CanalIlhas/ObterListaCas
        [HttpGet]
        public ObterListaCasResponse ObterListaCas()
        {
            return _canalIlhasService.ObterListaCas();
        }

        // GET v1/api/CanalIlhas/ObterCas/int
        [HttpGet("{pObterCasRequest}")]
        public ObterCasResponse ObterCas(int pObterCasRequest)
        {
            return _canalIlhasService.ObterCas(pObterCasRequest);
        }

        // GET v1/api/CanalIlhas/ListaVideos
        [HttpGet]
        public ListaArquivosResponse ListaVideos()
        {
            return _canalIlhasService.ListaVideos();
        }

        // GET v1/api/CanalIlhas/ListaImagens
        [HttpGet]
        public ListaArquivosResponse ListaImagens()
        {
            return _canalIlhasService.ListaImagens();
        }

        // GET v1/api/CanalIlhas
        [HttpGet]
        public ObterPlayListResponse ObterPlayList()
        {
            return _canalIlhasService.ObterPlayList();
        }

        [HttpGet("{pObterPlayListParaEditRequest}")]
        public ObterPlayListParaEditResponse ObterPlayEdit(ObterPlayListParaEditRequest pObterPlayListParaEditRequest)
        {
            return _canalIlhasService.ObterPlayEdit(pObterPlayListParaEditRequest);
        }

        [HttpPost]
        public InserirPlayListResponse InserirPlayList([FromBody] InserirPlayListRequest pInserirPlayListRequest)
        {
            return _canalIlhasService.InserirPlayList(pInserirPlayListRequest);
        }

        [HttpDelete]
        public ExcluirPlayListResponse ExcluirPlayList(ExcluirPlayListRequest pExcluirPlayListRequest)
        {
            return _canalIlhasService.ExcluirPlayList(pExcluirPlayListRequest);
        }

        //[HttpGet]
        //public ObterPlayListParaEditResponse ObterPlayListParaEdit()
        //{
        //    return _canalIlhasService.ObterPlayListParaEdit();
        //}
    }
}