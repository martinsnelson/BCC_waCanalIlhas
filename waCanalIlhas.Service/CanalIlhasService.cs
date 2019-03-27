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

    }
}
