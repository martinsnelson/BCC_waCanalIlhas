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
        private readonly ICanalIlhasDAL _canalIlhasDAL;

        public CanalIlhasService(ICanalIlhasDAL canalIlhasDAL)
        {
            _canalIlhasDAL = canalIlhasDAL;
        }

        public ObterListaCasResponse ObterListaCas()
        {
            try
            {
                var lCas = _canalIlhasDAL.ObterListaCas();
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
                var cas = _canalIlhasDAL.ObterCas(pObterCasRequest);
                return new ObterCasResponse { Cas = cas };
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public ListaArquivosResponse ListaVideos()
        {
            try
            {
                var videos = _canalIlhasDAL.ListaVideos();
                return new ListaArquivosResponse { Arquivos = videos };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ListaArquivosResponse ListaImagens()
        {
            try
            {
                var imagens = _canalIlhasDAL.ListaImagens();
                return new ListaArquivosResponse { Arquivos = imagens };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObterPlayListResponse ObterPlayList()
        {
            try
            {
                var playList = _canalIlhasDAL.ObterPlayList();
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
                var inserirPlayList = _canalIlhasDAL.InserirPlayList(pInserirPlayListRequest);
                return new InserirPlayListResponse { Mensagem = MensagensService.SUCESSO };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ExcluirPlayListResponse ExcluirPlayList(ExcluirPlayListRequest pExcluirPlayListRequest)
        {
            try
            {
                var excluirPlayList = _canalIlhasDAL.ExcluirPlayList(pExcluirPlayListRequest);
                return new ExcluirPlayListResponse { Mensagem = MensagensService.SUCESSO };
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
