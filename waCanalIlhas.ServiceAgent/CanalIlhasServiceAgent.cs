﻿using waCanalIlhas.DTO.Request.CanalIlhas;
using waCanalIlhas.DTO.Response.CanalIlhas;

namespace waCanalIlhas.ServiceAgent
{
    public class CanalIlhasServiceAgent
    {

        public ObterListaCasResponse ObterListaCas()
        {
            return Http.Get<ObterListaCasResponse>("v1/api/CanalIlhas/ObterListaCas");
        }

        public ObterCasResponse ObterCas(ObterCasRequest pObterCasRequest)
        {
            return Http.Getp<ObterCasResponse>("v1/api/CanalIlhas/ObterCas", pObterCasRequest);
        }

        public ListaArquivosResponse ListaVideos()
        {
            return Http.Get<ListaArquivosResponse>("v1/api/CanalIlhas/ListaVideos");
        }

        public ListaArquivosResponse ListaImagens()
        {
            return Http.Get<ListaArquivosResponse>("v1/api/CanalIlhas/ListaImagens");
        }

        public ObterPlayListParaEditResponse Test()
        {
            return Http.Get<ObterPlayListParaEditResponse>("v1/api/CanalIlhas/Test");
        }

        public ObterPlayListResponse ObterPlayList()
        {
            return Http.Get<ObterPlayListResponse>("v1/api/CanalIlhas/ObterPlayList");
        }

        public ObterPlayListParaEditResponse ObterPlayListParaEdit(ObterPlayListParaEditRequest pObterPlayListParaEditRequest)
        {
            return Http.Getp<ObterPlayListParaEditResponse>("v1/api/CanalIlhas/ObterPlayListParaEdit", pObterPlayListParaEditRequest);
        }

        public ObterPlayListParaEditResponse ObterPlayEdit(ObterPlayListParaEditRequest pObterPlayListParaEditRequest)
        {
            return Http.Getp<ObterPlayListParaEditResponse>("v1/api/CanalIlhas/ObterPlayEdit", pObterPlayListParaEditRequest);
        }

        public InserirPlayListResponse InserirPlayList(InserirPlayListRequest pInserirPlayListRequest)
        {
            return Http.Post<InserirPlayListResponse>("v1/api/CanalIlhas/InserirPlayList", pInserirPlayListRequest);
        }

        public ExcluirPlayListResponse ExcluirPlayList(ExcluirPlayListRequest pExcluirPlayListRequest)
        {
            return Http.Delete<ExcluirPlayListResponse>("v1/api/CanalIlhas/ExcluirPlayList", pExcluirPlayListRequest);
        }

    }
}
