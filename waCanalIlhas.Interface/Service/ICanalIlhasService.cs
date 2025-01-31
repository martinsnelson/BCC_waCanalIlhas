﻿using waCanalIlhas.DTO.Request.CanalIlhas;
using waCanalIlhas.DTO.Response.CanalIlhas;

namespace waCanalIlhas.Interface.Service
{
    public interface ICanalIlhasService
    {
        ObterListaCasResponse ObterListaCas();
        ObterCasResponse ObterCas(int pObterCasRequest);
        ListaArquivosResponse ListaVideos();
        ListaArquivosResponse ListaImagens();
        ObterPlayListResponse ObterPlayList();
        ObterPlayListParaEditResponse ObterPlayEdit(ObterPlayListParaEditRequest pObterPlayListParaEditRequest);
        InserirPlayListResponse InserirPlayList(InserirPlayListRequest pInserirPlayListRequest);
        ExcluirPlayListResponse ExcluirPlayList(ExcluirPlayListRequest pExcluirPlayListRequest);
        //ObterPlayListParaEditResponse ObterPlayListParaEdit();
    }
}
