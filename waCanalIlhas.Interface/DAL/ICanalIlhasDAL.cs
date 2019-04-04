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
        List<PlayListDTO> ObterPlayListParaEdit();
        IEnumerable<PlayListDTO> ObterPlayList();
        IEnumerable<PlayListDTO> ObterPlayEdit(ObterPlayListParaEditRequest pObterPlayEdit);
        Int64 ExcluirPlayList(ExcluirPlayListRequest pExcluirPlayListRequest);
        Int64 InserirPlayList(InserirPlayListRequest pInserirPlayListRequest);
        //List<PlayListDTO> ObterPlayList();
        //Int64 ObterPlayList();        Int64 InserirPlayList(InserirPlayListRequest pInserirPlayListRequest);
    }
}
