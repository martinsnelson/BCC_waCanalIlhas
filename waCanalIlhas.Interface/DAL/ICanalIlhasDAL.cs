using System;
using System.Collections.Generic;
using waCanalIlhas.DTO.CanalIlhas;
using waCanalIlhas.DTO.Request.CanalIlhas;
using waCanalIlhas.DTO.Response.CanalIlhas;
using waCanalIlhas.DTO.Upload;

namespace waCanalIlhas.Interface.DAL
{
    public interface ICanalIlhasDAL
    {
        IEnumerable<CasDTO> ObterListaCas();
        CasDTO ObterCas(int pObterCasRequest);
        List<ArquivosDTO> ListaVideos();
        List<ArquivosDTO> ListaImagens();      
        IEnumerable<PlayListDTO> ObterPlayList();
        Int64 InserirPlayList(InserirPlayListRequest pInserirPlayListRequest);
        Int64 ExcluirPlayList(ExcluirPlayListRequest pExcluirPlayListRequest);
        //Int64 InserirPlayList(InserirPlayListRequest pInserirPlayListRequest);
    }
}
