using System;
using System.Linq;
using waCanalIlhas.DTO.Request.CanalIlhas;
using waCanalIlhas.DTO.Response.CanalIlhas;
using waCanalIlhas.Interface.DAL;
using waCanalIlhas.Interface.Service;
using waCanalIlhas.Service.Messages;

namespace waCanalIlhas.Service
{
    public class CanalIlhasService : ICanalIlhasService
    {
        private readonly ICanalIlhasDAL _CanalIlhasDAL;

        public CanalIlhasService(ICanalIlhasDAL canalIlhasDAL)
        {
            _CanalIlhasDAL = canalIlhasDAL;
        }

        public ObterListaCasResponse ObterListaCas()
        {
            try
            {
                var lCas = _CanalIlhasDAL.ObterListaCas();
                return new ObterListaCasResponse { Cas = lCas, Mensagem = string.Format(MensagensService.NUMEROS_DE_REGISTROS, lCas.Count()) };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ObterCasResponse ObterCas(int pObterCasRequest)
        {
            try
            {
                var cas = _CanalIlhasDAL.ObterCas(pObterCasRequest);
                return new ObterCasResponse { Cas = cas };
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public ListaArquivosResponse ListaVideos()
        {
            try
            {
                var videos = _CanalIlhasDAL.ListaVideos();
                return new ListaArquivosResponse { Arquivos = videos };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ListaArquivosResponse ListaImagens()
        {
            try
            {
                var imagens = _CanalIlhasDAL.ListaImagens();
                return new ListaArquivosResponse { Arquivos = imagens };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ObterPlayListResponse ObterPlayList()
        {
            try
            {
                var playList = _CanalIlhasDAL.ObterPlayList();
                return new ObterPlayListResponse { PlayList = playList, Mensagem = string.Format(MensagensService.NUMEROS_DE_REGISTROS, playList.Count()) };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public InserirPlayListResponse InserirPlayList(InserirPlayListRequest pInserirPlayListRequest)
        {
            try
            {
                var inserirPlayList = _CanalIlhasDAL.InserirPlayList(pInserirPlayListRequest);
                return new InserirPlayListResponse { Mensagem = MensagensService.SUCESSO };
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
