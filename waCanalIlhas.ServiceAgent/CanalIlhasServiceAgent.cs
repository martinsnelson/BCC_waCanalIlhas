using waCanalIlhas.DTO.Request.CanalIlhas;
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
    }
}
